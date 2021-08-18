using System;
using System.Collections.Generic;

namespace AddressGPSConvert
{
    public class NaverGPSResponse
    {
        public string status { get; set; } = string.Empty;

        public MetaData meta { get; set; } = new MetaData();
        public List<Address> addresses { get; set; } = new List<Address>();

        public string errorMessage { get; set; } = string.Empty;
    }

    public class MetaData
    {
        public int totalCount { get; set; } = 0;

        public int page { get; set; } = 0;

        public int count { get; set; } = 0;
    }

    public class Address
    {
        public string roadAddress { get; set; } = string.Empty;

        public string jibunAddress { get; set; } = string.Empty;

        public string englishAddress { get; set; } = string.Empty;

        public List<AddressElement> addressElements { get; set; } = new List<AddressElement>();

        public string x { get; set; } = string.Empty;

        public string y { get; set; } = string.Empty;

        public double distance { get; set; } = 0;
    }

    public class AddressElement
    {
        public List<string> types { get; set; } = new List<string>();

        public string longName { get; set; } = string.Empty;

        public string shortName { get; set; } = string.Empty;

        public string code { get; set; } = string.Empty;
    }
}
