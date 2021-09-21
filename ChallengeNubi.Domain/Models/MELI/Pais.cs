using System;
using System.Collections.Generic;
using System.Text;

namespace ChallengeNubi.Domain.Models.MELI
{
    public class Pais
    {
        public String Id { get; set; }
        public String Name { get; set; }
        public String Locale { get; set; }
        public String Currency_id { get; set; }
        public String Decimal_separator { get; set; }
        public String Thousands_separator { get; set; }
        public String Time_zone { get; set; }
        public GeoInformation Geo_information { get; set; }
        public List<Estado> states { get; set; }     
    
    }
}
