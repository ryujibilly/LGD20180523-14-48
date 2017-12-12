using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Threading;

namespace WitsTransmission.TCPUtil
{
    //要发信息数据结构，作为SendMessage函数的LParam参数
    public struct SendDataStruct
    {
        public IntPtr dwData;       //附加一些个人自定义标志信息,自己喜欢
        public int DataLength;      //信息的长度
        [MarshalAs(UnmanagedType.LPStr)]
        public string lpData;       //要发送的信息
    }
    /// <summary>
    /// 异步TCPServer工具类
    /// 实现数据的异步接收、发送
    /// @author futao
    /// </summary>
    public class AsynchronousTCPServer
    {
        //自定义的消息
        public const int USER = 0x500;
        public const int CONTENTMESSAGE = USER + 1;
        public const int SENDDATAMESSAGE = USER + 3;
        //消息发送API
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(

            IntPtr hWnd,        // 信息发住的窗口的句柄

            int Msg,            // 消息ID

            int wParam,         // 参数1

            ref SendDataStruct lParam // 参数2   [MarshalAs(UnmanagedType.LPTStr)]StringBuilder lParam

        );
        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        private static extern int FindWindow(string lpClassName, string lpWindowName);
        
        private String m_strIPAdress;
        private int m_nPort;
        //侦听给发送的客户端socket
        private Socket m_sendSocket;
        //发送侦听线程
        private Thread m_sendListenThread;
        //定义一个集合，存储客户端信息
        public Dictionary<string, Socket> m_clientSocketDic = new Dictionary<string, Socket> { };
        public Dictionary<string, Socket> getClientSocketDic()
        {
            return m_clientSocketDic;
        }
        // Thread signal.     
        public ManualResetEvent allDone = new ManualResetEvent(false);
        public AsynchronousTCPServer()
        {
        }
        //侦听多客户端，接收，发送
        public void StartListening(String strIpAdress,int nPort)
        {
            // Data buffer for incoming data.     
            byte[] bytes = new Byte[1024];
            // Establish the local endpoint for the socket.     
            // The DNS name of the computer     
            // running the listener is "host.contoso.com".     
            //IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
            //IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPAddress ipAddress = IPAddress.Parse(strIpAdress);
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, nPort);//如：“127.0.0.1:80”  
            // Create a TCP/IP socket.     
            Socket listener = new Socket(AddressFamily.InterNetwork,SocketType.Stream, ProtocolType.Tcp);
            // Bind the socket to the local     
            //endpoint and listen for incoming connections.     
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(100);
                while (true)
                {
                    // Set the event to nonsignaled state.     
                    allDone.Reset();
                    // Start an asynchronous socket to listen for connections.     
                    Console.WriteLine("Waiting for a connection...");
                    listener.BeginAccept(new AsyncCallback(AcceptCallback),listener);
                    // Wait until a connection is made before continuing.     
                    allDone.WaitOne();
                 }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine("\nPress ENTER to continue...");
            Console.Read();
        }
        public void AcceptCallback(IAsyncResult ar)
        {
            // Signal the main thread to continue.     
            allDone.Set();
            // Get the socket that handles the client request.     
            Socket listener = (Socket)ar.AsyncState;
            Socket handler = listener.EndAccept(ar);
            // Create the state object.     
            StateObject state = new StateObject();
            state.workSocket = handler;
            handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReadCallback), state);
        }
        public void ReadCallback(IAsyncResult ar)
        {
            String content = String.Empty;
            // Retrieve the state object and the handler socket     
            // from the asynchronous state object.     
            StateObject state = (StateObject)ar.AsyncState;
            Socket handler = state.workSocket;
            // Read data from the client socket.     
            int bytesRead = handler.EndReceive(ar);
            if (bytesRead > 0)
            {
                // There might be more data, so store the data received so far.     
                state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));
                // Check for end-of-file tag. If it is not there, read     
                // more data.     
                content = state.sb.ToString();
                if (content.IndexOf("<EOF>") > -1)
                {
                    // All the data has been read from the     
                    // client. 
                    // Echo the data back to the client.  
                    //Send(handler, content);
                }
                else
                {
                    // Not all data received. Get more.
                    //将content直接传递给Main_Form作解析处理
                    SendContent(content);
                    //发送完成后，移除已发送项
                    state.sb.Remove(0, state.sb.Length);
                    handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReadCallback), state);
                }
            }
        }
        //侦听多客户端，这些客户端用于接收server发送的数据
        public void StartListeningSend(String strIpAdress, int nPort)
        {
            try
            {
                // Create a TCP/IP socket.
                m_sendSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                // Bind the socket to the local 
                IPAddress ipAddress = IPAddress.Parse(strIpAdress);
                //endpoint and listen for incoming connections. 
                IPEndPoint localEndPoint = new IPEndPoint(ipAddress, nPort);//如：“127.0.0.1:80”  
                m_sendSocket.Bind(localEndPoint);
                //将套接字的侦听队列长度限制为20
                m_sendSocket.Listen(20);
                //创建一个侦听线程
                m_sendListenThread = new Thread(_sendListen);
                //启动线程   
                m_sendListenThread.Start(); 
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine("\nPress ENTER to continue...");
            Console.Read();
        }
        //发送侦听线程
        private void _sendListen()
        {
            Socket clientSocket;
            while (true)
            {
                try
                {
                    clientSocket = m_sendSocket.Accept();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    break;
                }
                //客户端网络结点号
                String clientEndPoint = clientSocket.RemoteEndPoint.ToString();
                m_clientSocketDic.Add(clientEndPoint, clientSocket);
            }
        }
        //发送数据给目标客户端，在SendConfig_Form中调用
        public void Send(Socket handler, String data)
        {
            // Convert the string data to byte data using ASCII encoding.     
            byte[] byteData = Encoding.ASCII.GetBytes(data);
            handler.Send(byteData);
        }
        
        private void SendContent(String str)
        {
            SendDataStruct sendDataStruct;
            sendDataStruct.dwData = (IntPtr)100;
            sendDataStruct.lpData = str;
            sendDataStruct.DataLength = str.Length + 1;
            //发送自定义消息给句柄为SendToHandle 的窗口
            SendMessage((IntPtr)FindWindow(null, "WitsTransmission"), CONTENTMESSAGE, 100, ref sendDataStruct);
            SendMessage((IntPtr)FindWindow(null, "Wits发送配置"), SENDDATAMESSAGE, 100, ref sendDataStruct);
        }
    }
}
