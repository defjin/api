using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RestSharp;

namespace AddressGPSConvert.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetGPSLocationController : ControllerBase
    {
        private readonly ILogger<GetGPSLocationController> _logger;

        private readonly IConfiguration _configuration;

        public GetGPSLocationController(ILogger<GetGPSLocationController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet("")]
        public string Get()
        {
            return $"주소 -> GPS 좌표변환";
        }

        // 로깅 샘플
        //_logger.LogTrace("logging LogTrace ..");
        //    _logger.LogDebug("logging LogDebug ..");
        //    _logger.LogInformation("logging LogInformation ..");
        //    _logger.LogWarning("logging LogWarning ..");
        //    _logger.LogError("logging LogError ..");
        //    _logger.LogCritical("logging LogCritical ..");

        [HttpPost("naver")]
        public ReturnParam NaverGPS([FromBody] GPSRequest param)
        {
            var client = new RestClient($"https://naveropenapi.apigw.ntruss.com/map-geocode/v2/geocode?query={param.address}");
            client.Timeout = 5000; //-1 무제한 ms 단위
            var request = new RestRequest(Method.GET);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("X-NCP-APIGW-API-KEY-ID", _configuration["NAVER_API_KEY_ID"]) ;
            request.AddHeader("X-NCP-APIGW-API-KEY", _configuration["NAVER_API_KEY"]);
            IRestResponse response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var result = SimpleJson.DeserializeObject<NaverGPSResponse>(response.Content);
                if (result.meta.totalCount == 0)
                {
                    _logger.LogError("데이터가 없습니다.");
                    return new ReturnParam();
                }
                     
                else
                {
                    var x = result.addresses.FirstOrDefault().x;
                    var y = result.addresses.FirstOrDefault().y;
                    var res = new ReturnParam(true, x, y);
                    return res;
                }
            }
            else
            {
                _logger.LogError(response.StatusCode.ToString());
                _logger.LogError(response.ErrorMessage);
                _logger.LogError(response.Content);

                return new ReturnParam();
            }
        }

        [HttpPost("naver/all")]
        public string NaverGPSAll([FromBody] GPSRequest param)
        {
            var client = new RestClient($"https://naveropenapi.apigw.ntruss.com/map-geocode/v2/geocode?query={param.address}");
            client.Timeout = -1; //-1 무제한 ms 단위
            var request = new RestRequest(Method.GET);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("X-NCP-APIGW-API-KEY-ID", _configuration["NAVER_API_KEY_ID"]);
            request.AddHeader("X-NCP-APIGW-API-KEY", _configuration["NAVER_API_KEY"]);
            IRestResponse response = client.Execute(request);

            return response.Content;
        }

        #region 카카오 
        [HttpPost("kakao")]
        public ReturnParam KakaoGPS([FromBody] GPSRequest param)
        {
            var client = new RestClient($"https://dapi.kakao.com/v2/local/search/address.json?analyze_type=exact&page=1&size=10&query={param.address}");
            client.Timeout = 5000; //-1 무제한 ms 단위
            var request = new RestRequest(Method.GET);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", $"KakaoAK {_configuration["KAKAO_REST_API_KEY"]}");
            IRestResponse response = client.Execute(request);

            

        
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var result = SimpleJson.DeserializeObject<KakaoGPSResponse>(response.Content);
                if (result.meta.total_count == 0)
                {
                    _logger.LogError("데이터가 없습니다.");
                    return new ReturnParam();
                }
                else
                {
                    var x = result.documents.FirstOrDefault().x;
                    var y = result.documents.FirstOrDefault().y;
                    var res = new ReturnParam(true, x, y);
                    return res;
                }
            }
            else
            {
                _logger.LogError(response.StatusCode.ToString());
                _logger.LogError(response.ErrorMessage);
                _logger.LogError(response.Content);
                return new ReturnParam();
            }
        }

        [HttpPost("kakao/all")]
        public string KakaoGPSAll([FromBody] GPSRequest param)
        {
            var client = new RestClient($"https://dapi.kakao.com/v2/local/search/address.json?analyze_type=exact&page=1&size=10&query={param.address}");
            client.Timeout = -1; //-1 무제한 ms 단위
            var request = new RestRequest(Method.GET);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", $"KakaoAK {_configuration["KAKAO_REST_API_KEY"]}");
            IRestResponse response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return response.Content;
            else
            {
                _logger.LogError(response.ToString());
                _logger.LogError(response.StatusCode.ToString());
                _logger.LogError(response.ErrorMessage);
                _logger.LogError(response.Content);
                return "에러";
            }

        }

        #endregion
    }
}
