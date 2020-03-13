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



        public string GetMostExpensiveSixtyMinutesPeriod(List<PriceItem> priceItems)
        {
            //Ensure Ordered by date
            priceItems = priceItems.OrderBy(p => p.Timestamp).ToList();

            //Set varibales to store the highes result, the result of current set, and return string
            decimal topResultSet = 0;
            decimal currentResultSet = 0;
            string resultMessage = "";

            //Count items in loop
            int priceItemLength = priceItems.Count;
            int currentIndex = 0;

            if(priceItems.Count == 0)
            {
                resultMessage = "Not Enough Data";
            }
            else {
                //Loop everything in the list 
                //Check if either one item alone or in combination with the two items next to it (if they are within the timeframe) are the most expensive
                foreach (PriceItem priceItem in priceItems)
                {
                    //check if current item by itself is more than topResult so far
                    if (priceItem.Price > topResultSet)
                    {
                        topResultSet = priceItem.Price;
                        resultMessage = $"{priceItem.Timestamp.ToString()} to {priceItem.Timestamp.AddMinutes(60).ToString()}";
                    }

                    //Check if there is at least two more items in the list and if they are within 60 minutes
                    if ((priceItemLength > currentIndex + 2) && (IsWithinSixtyMinutes(priceItem.Timestamp, priceItems[currentIndex + 2].Timestamp)))
                    {
                        currentResultSet = priceItem.Price + priceItems[currentIndex + 1].Price + priceItems[currentIndex + 2].Price;
                        if (currentResultSet > topResultSet)
                        {
                            topResultSet = currentResultSet;
                            resultMessage = $"{priceItem.Timestamp.ToString()} to {priceItem.Timestamp.AddMinutes(60).ToString()}";
                        }
                    }
                    //Check if there is at least one more item in the list and if the next item is within 60 minutes
                    else if ((priceItemLength > currentIndex + 1) && (IsWithinSixtyMinutes(priceItem.Timestamp, priceItems[currentIndex + 1].Timestamp)))
                    {
                        currentResultSet = priceItem.Price + priceItems[currentIndex + 1].Price;
                        if (currentResultSet > topResultSet)
                        {
                            topResultSet = currentResultSet;
                            resultMessage = $"{priceItem.Timestamp.ToString()} to {priceItem.Timestamp.AddMinutes(60).ToString()}";                         
                        }
                    }
                    //increment current index
                    currentIndex++;
                }
            }

            return resultMessage;
        }

        //Check if an item is within 60 minutes of another
        private bool IsWithinSixtyMinutes(DateTime firstDate, DateTime secondDate)
        {
            bool result = false;
            result = secondDate.Subtract(firstDate).TotalMinutes <= 60;
            return result;
        }                                       
    }
}
