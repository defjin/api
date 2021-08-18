using System;
using System.Collections.Generic;

namespace AddressGPSConvert
{
    public class KakaoGPSResponse
    {
        public KakaoMetaData meta { get; set; } = new KakaoMetaData();
        public List<KakaoDocument> documents { get; set; } = new List<KakaoDocument>();
    }

    public class KakaoMetaData
    {
        public bool is_end { get; set; } = default;

        public int pageable_count { get; set; } = 0;

        public int total_count { get; set; } = 0;
    }

    public class KakaoDocument
    {
        public KakaoAddress address { get; set; } = new KakaoAddress();

        public string address_name { get; set; } = string.Empty;

        public string address_type { get; set; } = string.Empty;

        public KakaoRoadAddress road_address { get; set; } = new KakaoRoadAddress();

        public string x { get; set; } = string.Empty;

        public string y { get; set; } = string.Empty;

    }

    public class KakaoAddress
    {
        public string address_name { get; set; } = string.Empty;

        public string b_code { get; set; } = string.Empty;

        public string h_code { get; set; } = string.Empty;

        public string main_address_no { get; set; } = string.Empty;

        public string mountain_yn { get; set; } = string.Empty;

        public string region_1depth_name { get; set; } = string.Empty;

        public string region_2depth_name { get; set; } = string.Empty;

        public string region_3depth_h_name { get; set; } = string.Empty;

        public string region_3depth_name { get; set; } = string.Empty;

        public string x { get; set; } = string.Empty;

        public string y { get; set; } = string.Empty;
    }

    public class KakaoRoadAddress
    {
        public string address_name { get; set; } = string.Empty;

        public string building_name { get; set; } = string.Empty;

        public string main_building_no { get; set; } = string.Empty;

        public string region_1depth_name { get; set; } = string.Empty;

        public string region_2depth_name { get; set; } = string.Empty;

        public string region_3depth_name { get; set; } = string.Empty;

        public string road_name { get; set; } = string.Empty;

        public string sub_building_no { get; set; } = string.Empty;

        public string underground_yn { get; set; } = string.Empty;

        public string x { get; set; } = string.Empty;

        public string y { get; set; } = string.Empty;

        public string zone_no { get; set; } = string.Empty;
    }
}
