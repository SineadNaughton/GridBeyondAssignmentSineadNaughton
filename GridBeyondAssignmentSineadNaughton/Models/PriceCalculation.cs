using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GridBeyondAssignmentSineadNaughton.Models
{
    public class PriceCalculation
    {
        public decimal PriceAverage { get; set; }

        public decimal PriceMax { get; set; }

        public decimal PriceMin { get; set; }

        public string MostExpensiveSixtyMinutesPeriod { get; set; }
    }
}
