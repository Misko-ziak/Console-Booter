using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
namespace Console_Booter.API
{
    class Functions
    {
        public static string MakeRequest(string requestUri, bool returnServerResponse)
        {
            try{
            WebRequest wr = WebRequest.Create(requestUri);
            WebResponse ServerResponse = wr.GetResponse();
            Stream stream = ServerResponse.GetResponseStream();
            StreamReader Streamreader = new StreamReader(stream);
            if (returnServerResponse)
            {
                return Streamreader.ReadToEnd();
            }
            return "";
            }catch{
                 return "";
            }
        }
    }
}
