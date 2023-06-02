using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace webapi
{
    public static class PreqinApiHelper
    {
        static readonly string API_BASE_URL = "https://api.preqin.com";
        public static bool IgnoreCertificateValidationErrors(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            // You can add custom logic here to validate or ignore specific certificate errors
            // For example, you can return true to ignore all certificate errors, but exercise caution when doing this
            return true;
        }
        public static string getToken(string _strApiKey, string _strUserName)
        {
            string w_strURL = API_BASE_URL + "/connect/token";
            string w_strToken = string.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(w_strURL);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded; charset=utf-8";
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/113.0.0.0 Safari/537.36";
            request.Accept = "*/*";
            request.AllowAutoRedirect = true;
            request.ServerCertificateValidationCallback += IgnoreCertificateValidationErrors;
            ServicePointManager.ServerCertificateValidationCallback += IgnoreCertificateValidationErrors;
            request.KeepAlive = true;
            // request.UseDefaultCredentials = true;
            // request.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            // request.Headers.Add("Accept-Encoding", "gzip, deflate, br");

            string w_strResponse = string.Empty;
            string w_strPostData = $"username={_strUserName}&apikey={_strApiKey}";
            byte[] w_bytePostData = Encoding.UTF8.GetBytes(w_strPostData);
            request.ContentLength = w_bytePostData.Length;
            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(w_bytePostData, 0, w_bytePostData.Length);
            }
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                Stream respStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(respStream);
                w_strResponse = reader.ReadToEnd();
            }

            MAuth w_mAuth = JsonConvert.DeserializeObject<MAuth>(w_strResponse);
            if (w_mAuth != null)
                w_strToken = w_mAuth.access_token;
            return w_strToken;
        }

        public static MInvestors getInvestors(List<string> _lstrFirmIDs, string _strToken)
        {
            List<MInvestor> w_lstmInvestors = new List<MInvestor>();
            string w_strParam = string.Empty;
            if (_lstrFirmIDs != null && _lstrFirmIDs.Count > 0)
            {
                w_strParam += "?FirmID=";
                w_strParam += _lstrFirmIDs[0];
                for (int i = 1; i < _lstrFirmIDs.Count; i++)
                {
                    w_strParam += $",{_lstrFirmIDs[i]}";
                }
            }

            string w_strURL = API_BASE_URL + "/api/Investor" + w_strParam;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(w_strURL);
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded; charset=utf-8";
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/113.0.0.0 Safari/537.36";
            request.Accept = "*/*";
            request.AllowAutoRedirect = true;
            request.ServerCertificateValidationCallback += IgnoreCertificateValidationErrors;
            ServicePointManager.ServerCertificateValidationCallback += IgnoreCertificateValidationErrors;
            request.KeepAlive = true;
            // request.UseDefaultCredentials = true;
            // request.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            // request.Headers.Add("Accept-Encoding", "gzip, deflate, br");
            request.Headers.Add("Authorization", $"Bearer {_strToken}");

            string w_strResponse = string.Empty;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                Stream respStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(respStream);
                w_strResponse = reader.ReadToEnd();
            }

            MInvestors w_mInvestors = JsonConvert.DeserializeObject<MInvestors>(w_strResponse);
            return w_mInvestors;
        }
    }
}
