using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GridBeyondAssignmentSineadNaughton.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GridBeyondAssignmentSineadNaughton.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PriceItemController : ControllerBase
    {
        [Route("/api/priceitems")]
        [HttpGet]
        public IEnumerable<PriceItem> GetAllItems()
        {
            return new List<PriceItem>() { new PriceItem() { Id=1, Price=2.44m, Timestamp=new DateTime()} };
        }

        [Route("/api/priceitems/calculations")]
        [HttpGet]
        public PriceCalculation GetPriceCalculation()
        {
            return new PriceCalculation() { MostExpensiveSixtyMinutesPeriod="", PriceAverage=2.40m, PriceMax=4.00m, PriceMin=1.00m};
        }
    }
}
