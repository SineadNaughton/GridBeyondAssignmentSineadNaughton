using System;
using System.ComponentModel.DataAnnotations;

namespace GridBeyondAssignmentSineadNaughton
{
    public class PriceItem
    {
        public DateTime Timestamp { get; set; }

        public decimal Price { get; set; }

        [Key]
        public int Id { get; set; }

    }
}
