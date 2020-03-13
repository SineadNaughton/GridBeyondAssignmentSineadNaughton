using GridBeyondAssignmentSineadNaughton.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GridBeyondAssignmentSineadNaughton.Services
{
    public class PriceItemsService
    {
        //Add
        public void Add(PriceItem priceItem)
        {
            //create a data context and add an item
            using PriceItemsContext dataContext = new PriceItemsContext();
            List<PriceItem> priceItems = GetAll();
            bool exists = false;

            //check if there is already an entry for this time
            foreach (PriceItem pI in priceItems)
            {
                if (pI.Timestamp.Equals(priceItem.Timestamp))
                {
                    exists = true;
                }
            }
            if (!exists)
            {
                dataContext.PriceItems.Add(priceItem);
                dataContext.SaveChanges();
            }
        }

        //Get
        public List<PriceItem> GetAll()
        {
            using PriceItemsContext dataContext = new PriceItemsContext();
            var priceItems = dataContext.PriceItems.ToList();
            priceItems = priceItems.OrderBy(p => p.Timestamp).ToList();
            return priceItems;
        }
    }
}
