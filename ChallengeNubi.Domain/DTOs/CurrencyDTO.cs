using System;
using System.Collections.Generic;
using System.Text;

namespace ChallengeNubi.Domain.DTOs
{
    public class CurrencyDTO
    {
        public String id { get; set; }
        public String symbol { get; set; }
        public String description { get; set; }
        public int decimal_places { get; set; }
        public double toDolar { get; set; }
    }
}
