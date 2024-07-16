using RestSharp;
using System.Threading.Tasks;

namespace AttendanceMachineSimulator
{
	public class RestClientHelper
	{
        private readonly RestClient _client;

        public RestClientHelper(string baseUrl)
        {
            _client = new RestClient(baseUrl);
        }
        //http://www.mzdbl.cn/yinyue/mx/index.html
        public async Task<RestResponse> GetAsync(string endpoint)
        {
            var request = new RestRequest(endpoint, Method.Get);
            return await _client.ExecuteAsync(request);
        }

        public async Task<RestResponse> PostAsync(string endpoint, object body)
        {
            var request = new RestRequest(endpoint, Method.Post);
            request.AddJsonBody(body);
            return await _client.ExecuteAsync(request);
        }

        public async Task<RestResponse> PutAsync(string endpoint, object body)
        {
            var request = new RestRequest(endpoint, Method.Put);
            request.AddJsonBody(body);
            return await _client.ExecuteAsync(request);
        }

        public async Task<RestResponse> DeleteAsync(string endpoint)
        {
            var request = new RestRequest(endpoint, Method.Delete);
            return await _client.ExecuteAsync(request);
        }
    }
}
