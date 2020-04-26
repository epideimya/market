using System;
using System.Collections.Generic;
using System.Text;

namespace Market.Data.DataBaseModel
{
    public class Order
    {
        public int Id { get; set; }
        public int SellerId { get; set; }
        public int PurchaseId { get; set; }
        public bool IsPaid { get; set; }
        public bool IsSent { get; set; }
    }
}

