using System;
using System.Collections.Generic;
using System.Text;

namespace ChallengeNubi.Domain.Models.MELI
{
    public class CurrencyConversion
    {

        public String currency_base { get; set; }
        public String currency_quote { get; set; }
        public double ratio { get; set; }
        public double rate { get; set; }
        public double inv_rate { get; set; }
        public DateTime creation_date { get; set; }
        public DateTime valid_until { get; set; }



    }
}
