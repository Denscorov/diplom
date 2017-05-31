using Microsoft.Phone.Reactive;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Cryptography.Certificates;
using Windows.Web.Http;
using Windows.Web.Http.Filters;

namespace Testing_3
{
    public class HttpRequestSend
    {
        Uri uri;

        public HttpRequestSend(string ip, string address)
        {
            uri = new Uri(ip + address, UriKind.Absolute);
        }


        public async Task<T> GetRequestJsonAsync<T>()
        {
            var ret = await GetRequestAsync(uri);
            var response = await ret.ReadToEndAsync();
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(response);
        }

        async Task<System.IO.TextReader> DoRequestAsync(WebRequest req)
        {
            var task = Task.Factory.FromAsync((cb, o) => ((HttpWebRequest)o).BeginGetResponse(cb, o), res => ((HttpWebRequest)res.AsyncState).EndGetResponse(res), req);
            var result = await task;
            var resp = result;
            var stream = resp.GetResponseStream();
            var sr = new System.IO.StreamReader(stream);
            return sr;
        }

        async Task<System.IO.TextReader> GetRequestAsync(Uri url)
        {
            HttpWebRequest req = HttpWebRequest.CreateHttp(url);
            req.Method = "GET";
            req.AllowReadStreamBuffering = true;
            var tr = await DoRequestAsync(req);
            return tr;
        }

        public async Task<WebResponse> PostRequestAsync(string data)
        {
            HttpWebRequest req = WebRequest.CreateHttp(uri);
            req.Credentials = CredentialCache.DefaultCredentials;
            req.Method = "POST";
            req.ContentType = "application/json";
            Stream dataStream = await req.GetRequestStreamAsync();
            var b = Encoding.UTF8.GetBytes(data);
            dataStream.Write(b,0,b.Length);
            dataStream.Close();
            return await req.GetResponseAsync();
        }

        public async Task<string> PostRequest(string data)
        {
            HttpClient client = new HttpClient();
            var content = new HttpStringContent(data);
            content.Headers.ContentType = new Windows.Web.Http.Headers.HttpMediaTypeHeaderValue("application/json");
            var response = await client.PostAsync(uri, content);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
