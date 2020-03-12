using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GridBeyondAssignmentSineadNaughton.Helpers;
using GridBeyondAssignmentSineadNaughton.Models;
using GridBeyondAssignmentSineadNaughton.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GridBeyondAssignmentSineadNaughton.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PriceItemController : ControllerBase
    {
        PriceItemsService priceItemsService = new PriceItemsService();

        [Route("/api/priceitems")]
        [HttpGet]
        public IEnumerable<PriceItem> GetAllItems()
        {
            List<PriceItem> priceItems = priceItemsService.GetAll();
            return priceItems;
        }

        [Route("/api/priceitems")]
        [HttpPost]
        public List<PriceItem> GetAllItems(PriceItem priceItem)
        {
            priceItemsService.Add(priceItem);
            List<PriceItem> priceItems = priceItemsService.GetAll();
            return priceItems;
        }

        [Route("/api/priceitems/calculations")]
        [HttpGet]
        public PriceCalculation GetPriceCalculation()
        {
            List<PriceItem> priceItems = priceItemsService.GetAll();
            PriceCalculationsHelper priceCalculationsHelper = new PriceCalculationsHelper();
            PriceCalculation priceCalculation = priceCalculationsHelper.GetPriceCalculation(priceItems);
            return priceCalculation;
        }
    }
}
