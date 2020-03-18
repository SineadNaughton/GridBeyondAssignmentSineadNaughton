using GridBeyondAssignmentSineadNaughton.Data;
using System.Collections.Generic;
using System.Linq;

namespace GridBeyondAssignmentSineadNaughton.Services
{
    public class PriceItemsService
    {
        //Add a PriceItem to DB
        public void Add(PriceItem priceItem)
        {
            //create a data context and get all items
            using PriceItemsContext dataContext = new PriceItemsContext();
            List<PriceItem> priceItems = GetAll();
            bool exists = false;

            //This only allows one entry for a specific timestamp 
            foreach (PriceItem pI in priceItems)
            {
                if (pI.Timestamp.Equals(priceItem.Timestamp))
                {
                    exists = true;
                }
            }
            //If it doesn't exist add the item
            if (!exists)
            {
                dataContext.PriceItems.Add(priceItem);
                dataContext.SaveChanges();
            }
        }

        //Get
        public List<PriceItem> GetAll()
        {
            //Get all items from DB and order by timestamp
            using PriceItemsContext dataContext = new PriceItemsContext();
            var priceItems = dataContext.PriceItems.ToList();
            priceItems = priceItems.OrderBy(p => p.Timestamp).ToList();
            return priceItems;
        }
    }
}
