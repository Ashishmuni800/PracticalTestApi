using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string? ProductName { get; set; }
        public string? ProductFile { get; set; }
        public string? ProductType { get; set; }
        public decimal? ProductSize { get; set; }
        public decimal? Quantity { get; set; }
        public int NumberOfOrders { get; set; }
    }
}
