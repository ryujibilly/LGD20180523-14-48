using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Protocols;

namespace WebService.realdbws
{
    public class realdbsoapHeader : SoapHeader
    {
            public string user = string.Empty;
            public string password = string.Empty;
            public realdbsoapHeader()
            {

            }
            public realdbsoapHeader(string username, string passwd)
            {
                this.user = username;
                this.password = passwd;
            }
        }
}