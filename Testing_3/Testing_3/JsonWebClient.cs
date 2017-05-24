using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Testing_3
{
    public class JsonWebClient
    {
        public async Task<System.IO.TextReader> DoRequestAsync(WebRequest req)
        {
            var task = Task.Factory.FromAsync((cb, o) => ((HttpWebRequest)o).BeginGetResponse(cb, o), res => ((HttpWebRequest)res.AsyncState).EndGetResponse(res), req);
            var result = await task;
            var resp = result;
            var stream = resp.GetResponseStream();
            var sr = new System.IO.StreamReader(stream);
            return sr;
        }

        public async Task<System.IO.TextReader> DoRequestAsync(string url)
        {
            HttpWebRequest req = HttpWebRequest.CreateHttp(url);
#if WINDOWS_PHONE
            req.AllowReadStreamBuffering = true;
#endif
            var tr = await DoRequestAsync(req);
            return tr;
        }

        public async Task<Newtonsoft.Json.Linq.JObject> DoRequestJsonAsync(WebRequest req)
        {
            var ret = await DoRequestAsync(req);
            var response = await ret.ReadToEndAsync();
            return Newtonsoft.Json.JsonConvert.DeserializeObject(response) as Newtonsoft.Json.Linq.JObject;
        }

        public async Task<Newtonsoft.Json.Linq.JObject> DoRequestJsonAsync(string uri)
        {
            var ret = await DoRequestAsync(uri);
            var response = await ret.ReadToEndAsync();
            return Newtonsoft.Json.JsonConvert.DeserializeObject(response) as Newtonsoft.Json.Linq.JObject;
        }

        public async Task<T> DoRequestJsonAsync<T>(WebRequest req)
        {
            var ret = await DoRequestAsync(req);
            var response = await ret.ReadToEndAsync();
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(response);
        }

        public async Task<T> DoRequestJsonAsync<T>(string uri)
        {
            var ret = await DoRequestAsync(uri);
            var response = await ret.ReadToEndAsync();
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(response);
        }
    }
}
