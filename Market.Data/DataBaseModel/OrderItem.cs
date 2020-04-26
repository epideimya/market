using System;
using System.Collections.Generic;
using System.Text;

namespace Market.Data.DataBaseModel
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public int OrderId { get; set; }
    }
}
