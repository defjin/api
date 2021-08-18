using Newtonsoft.Json;
using System;


namespace AddressGPSConvert
{
    public class ReturnParam
    {
        [JsonProperty]
        bool isSuccess { get; set; } = false;

        [JsonProperty]
        string x { get; set; } = string.Empty;

        [JsonProperty]
        string y { get; set; } = string.Empty;

        public ReturnParam()
        {
            isSuccess = false;
            x = "";
            y = "";
        }

        public ReturnParam(bool isSuccess, string x, string y) : this()
        {
            this.isSuccess = isSuccess;
            this.x = x;
            this.y = y;
        }
    }

    
}
