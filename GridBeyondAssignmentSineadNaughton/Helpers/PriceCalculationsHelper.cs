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
            //Order the list by date
            priceItems = priceItems.OrderBy(p => p.Timestamp).ToList();
            int mostExpensiveHourStartIndex = 0;
            decimal resultTop = 0;
            decimal currentResult =0;
            string result = "";

            if (priceItems.Count < 3)
            {
                result = "Not Enough Data";
            }
            else {
                for (int i = 0; i < priceItems.Count; i++)
                {
                    //check for out of range
                    if (priceItems.Count >= i + 3)
                    {
                        //If there are no more items within 60 minutes
                        if (priceItems[i + 1].Timestamp.Subtract(priceItems[i].Timestamp).TotalMinutes > 60)
                        {
                            if (priceItems[i].Price > resultTop)
                            {
                                resultTop = priceItems[i].Price;
                                string startTimeStamp = priceItems[i].Timestamp.ToString();
                                string endTimeStamp = priceItems[i].Timestamp.AddMinutes(60).ToString();
                                result = $"{startTimeStamp} to {endTimeStamp}";
                            }
                        }

                        //If the next item is within 60 minutes
                        else if (priceItems[i + 1].Timestamp.Subtract(priceItems[i].Timestamp).TotalMinutes <= 60)
                        {
                            currentResult = priceItems[i].Price + priceItems[i + 1].Price;
                            if (currentResult > resultTop)
                            {
                                string startTimeStamp = priceItems[i].Timestamp.ToString();
                                string endTimeStamp = priceItems[i + 1].Timestamp.ToString();
                                result = $"{startTimeStamp} to {endTimeStamp}";
                            }

                            //If the second next item is within 60 minutes add this to the list
                            if (priceItems[i + 2].Timestamp.Subtract(priceItems[i].Timestamp).TotalMinutes <= 30)
                            {
                                currentResult = priceItems[i].Price + priceItems[i + 1].Price + priceItems[i + 2].Price;
                                if (currentResult > resultTop)
                                {
                                    string startTimeStamp = priceItems[i].Timestamp.ToString();
                                    string endTimeStamp = priceItems[i + 2].Timestamp.ToString();
                                    result = $"{startTimeStamp} to {endTimeStamp}";
                                }
                            
                            }
                        }                                                         
                    }
                }
            }

            return result;
        }
    }
}
