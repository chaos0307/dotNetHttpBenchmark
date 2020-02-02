using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using RestSharp;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace dotNetHttpBenchmarkCore
{
    //[ShortRunJob]
    //[NativeMemoryProfiler]
    [MemoryDiagnoser]
    [SimpleJob(RuntimeMoniker.Net472)]
    [SimpleJob(RuntimeMoniker.NetCoreApp31)]
    [MarkdownExporter]
    //[StopOnFirstError]
    public class HttpBenchmark
    {
        private readonly static HttpClient s_client = new HttpClient();
        private string _api;
        public HttpBenchmark()
        {
            _api = "http://localhost/SampleApi/";
        }

        [Benchmark]
        public void Get_WebRequest() => ExecuteWebRequest(_api + "SampleGet", string.Empty, method: "GET");

        [Benchmark]
        public Task Get_HttpClientAsync() => ExecuteHttpClient(_api + "SampleGet", HttpMethod.Get);
        [Benchmark]
        public async Task Get_WebClientAsync()
        {
            using (var webClient = new WebClient())
            {
                var stream = await webClient.OpenReadTaskAsync(_api + "SampleGet");
                using (var reader = new StreamReader(stream))
                {
                    var result = reader.ReadToEnd();
                }
            }
        }
        [Benchmark]
        public async Task Get_RestSharpAsync()
        {
            var restClient = new RestClient(_api + "SampleGet");
            var getRequest = new RestRequest(Method.GET);
            var response = await restClient.ExecuteAsync(getRequest);
        }
        [Benchmark]
        public void Post_WebRequest() => ExecuteWebRequest(_api + "SamplePost", string.Empty);

        [Benchmark]
        public Task Post_HttpClientAsync() => ExecuteHttpClient(_api + "SamplePost", HttpMethod.Post);


        [Benchmark]
        public async Task Post_WebClientAsync()
        {
            using (var webClient = new WebClient())
            {
                NameValueCollection nameValueCollection = new NameValueCollection();
                var response = await webClient.UploadValuesTaskAsync(_api + "SamplePost", "POST", nameValueCollection);
                var responseString = UnicodeEncoding.UTF8.GetString(response);
            }
        }

        [Benchmark]
        public async Task Post_RestSharpAsync()
        {
            var restClient = new RestClient(_api + "SamplePost");
            var getRequest = new RestRequest(Method.POST);
            var response = await restClient.ExecuteAsync(getRequest);
        }
        private void ExecuteWebRequest(string pUrl, string pReq, string method = "POST", string contentType = "application/json", int timeout = -1)
        {
            string result;

            WebRequest request = WebRequest.Create(pUrl);
            request.Method = method;
            request.ContentType = contentType;
            if (timeout > 0)
                request.Timeout = timeout;

            if (method == "POST")
            {
                byte[] requestBytes = Encoding.UTF8.GetBytes(pReq);
                request.ContentLength = requestBytes.Length;

                using (var requestStream = request.GetRequestStream())
                {
                    using (var writer = new StreamWriter(requestStream))
                    {
                        writer.Write(pReq);
                        writer.Flush();
                        writer.Close();
                    }
                }
            }
            using (var response = request.GetResponse())
            {
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    result = reader.ReadToEnd();
                    reader.Close();
                }
                response.Close();
            }
        }

        private async Task ExecuteHttpClient(string pUrl, HttpMethod httpMethod)
        {
            using (var req = new HttpRequestMessage(httpMethod, pUrl))
            {
                var httpResponseMessage = await s_client.SendAsync(req);
                httpResponseMessage.EnsureSuccessStatusCode();
                var responseString = await httpResponseMessage.Content.ReadAsStringAsync();
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<HttpBenchmark>();
        }
    }
}
