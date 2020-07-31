using System;
using System.Collections.Generic;
using System.Text;

namespace RegionalCode.Entities
{
    class RegionalCode
    {
        public int Code { get; set; }
        public string Region { get; set; }

        public RegionalCode(int code, string region)
        {
            this.Code = code;
            this.Region = region;
        }

        public string GetStringForDictionary()
        {
            string s = ($"{Code}\t{Region}");
            return s;
        }
    }
}
