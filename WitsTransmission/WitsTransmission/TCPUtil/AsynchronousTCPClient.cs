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
    /// <summary>
    /// 异步TCPClient工具类
    /// 实现数据的异步接收、发送
    /// @author futao
    /// </summary>
    public class AsynchronousTCPClient
    {
        //自定义的消息
        public const int USER = 0x500;
        public const int CONTENTMESSAGE = USER + 1;
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
        // The ipAdress and port number for the remote device.     
        private static String strIPAdress;
        private static int nPort;
        // ManualResetEvent instances signal completion.     
        private static ManualResetEvent connectDone = new ManualResetEvent(false);
        private static ManualResetEvent sendDone = new ManualResetEvent(false);
        private static ManualResetEvent receiveDone = new ManualResetEvent(false);
        public AsynchronousTCPClient()
        {
        }
        // The response from the remote device.     
        private static String response = String.Empty;
        public void StartClient(String strIPAdress,int nPort)
        {
            // Connect to a remote device.     
            try
            {
                // Establish the remote endpoint for the socket.     
                // The name of the     
                // remote device is "host.contoso.com".     
                //IPHostEntry ipHostInfo = Dns.Resolve("user");
                //IPAddress ipAddress = ipHostInfo.AddressList[0];
                IPAddress ipAddress = IPAddress.Parse(strIPAdress);
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, nPort);
                // Create a TCP/IP socket.     
                Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                // Connect to the remote endpoint.     
                client.BeginConnect(remoteEP, new AsyncCallback(ConnectCallback), client);
                connectDone.WaitOne();
                // Send test data to the remote device.     
                Send(client, "This is a test<EOF>");
                sendDone.WaitOne();
                // Receive the response from the remote device.     
                Receive(client);
                receiveDone.WaitOne();
                // Write the response to the console.     
                Console.WriteLine("Response received : {0}", response);
                // Release the socket.     
                client.Shutdown(SocketShutdown.Both);
                client.Close();
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        private void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.     
                Socket client = (Socket)ar.AsyncState;
                // Complete the connection.     
                client.EndConnect(ar);
                Console.WriteLine("Socket connected to {0}", client.RemoteEndPoint.ToString());
                // Signal that the connection has been made.     
                connectDone.Set();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        private void Receive(Socket client)
        {
            try
            {
                // Create the state object.     
                StateObject state = new StateObject();
                state.workSocket = client;
                // Begin receiving the data from the remote device.     
                client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReceiveCallback), state);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        private void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the state object and the client socket     
                // from the asynchronous state object.     
                StateObject state = (StateObject)ar.AsyncState;
                Socket client = state.workSocket;
                String content = String.Empty;
                // Read data from the remote device.     
                int bytesRead = client.EndReceive(ar);
                if (bytesRead > 0)
                {
                    // There might be more data, so store the data received so far.     

                    state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));
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
                        //收到一次，发送一次
                        SendContent(content);
                        //发送完成后，移除已发送项
                        state.sb.Remove(0, state.sb.Length);
                        // Get the rest of the data.     
                        client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReceiveCallback), state);

                    }
                }
                /*else
                {
                    // All the data has arrived; put it in response.     
                    if (state.sb.Length > 1)
                    {
                        response = state.sb.ToString();
                    }
                    // Signal that all bytes have been received.     
                    receiveDone.Set();
                }*/
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        private void Send(Socket client, String data)
        {
            // Convert the string data to byte data using ASCII encoding.     
            byte[] byteData = Encoding.ASCII.GetBytes(data);
            // Begin sending the data to the remote device.     
            client.BeginSend(byteData, 0, byteData.Length, 0, new AsyncCallback(SendCallback), client);
        }
        private void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.     
                Socket client = (Socket)ar.AsyncState;
                // Complete sending the data to the remote device.     
                int bytesSent = client.EndSend(ar);
                Console.WriteLine("Sent {0} bytes to server.", bytesSent);
                // Signal that all bytes have been sent.     
                sendDone.Set();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private void SendContent(String str)
        {
            SendDataStruct sendDataStruct;
            sendDataStruct.dwData = (IntPtr)100;
            sendDataStruct.lpData = str;
            sendDataStruct.DataLength = str.Length + 1;
            //发送自定义消息给句柄为SendToHandle 的窗口
            SendMessage((IntPtr)FindWindow(null, "WitsTransmission"), CONTENTMESSAGE, 100, ref sendDataStruct);
        }
    }
}
