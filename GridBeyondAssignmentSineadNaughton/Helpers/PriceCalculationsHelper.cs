using GridBeyondAssignmentSineadNaughton.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GridBeyondAssignmentSineadNaughton.Helpers
{
    public class PriceCalculationsHelper
    {      
        //Calculate
        public PriceCalculation GetPriceCalculation(List<PriceItem> priceItems)
        {
            PriceCalculation priceCalculation = new PriceCalculation();
            priceCalculation.PriceMin = GetMinPrice(priceItems);
            priceCalculation.PriceMax = GetMaxPrice(priceItems);
            priceCalculation.PriceAverage = GetAvgPrice(priceItems);
            priceCalculation.MostExpensiveSixtyMinutesPeriod = GetMostExpensiveSixtyMinutesPeriod(priceItems);

            return priceCalculation;
        }
        //Min
        public decimal GetMinPrice(List<PriceItem> priceItems)
        {
            decimal minPrice =0;
            minPrice = priceItems.Min(x => x.Price);
            minPrice = Decimal.Round(minPrice, 2);
            return minPrice;
        }

        //Max
        public decimal GetMaxPrice(List<PriceItem> priceItems)
        {
            decimal maxPrice = 0;
            maxPrice = priceItems.Max(x => x.Price);
            maxPrice = Decimal.Round(maxPrice, 2);
            return maxPrice;
        }

        //Average
        public decimal GetAvgPrice(List<PriceItem> priceItems)
        {
            decimal avgPrice = 0;
            avgPrice = priceItems.Average(x => x.Price);
            avgPrice = Decimal.Round(avgPrice, 2);
            return avgPrice;
        }

        //MostExpensiveHour
        public string GetMostExpensiveSixtyMinutesPeriod(List<PriceItem> priceItems)
        {
            string MostExpensiveSixtyMinutesPeriod = "";

            return MostExpensiveSixtyMinutesPeriod;
        }
    }
}
