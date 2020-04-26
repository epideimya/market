using System;
using System.Collections.Generic;
using System.Text;

namespace Market.Data.DataBaseModel
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string MarketingInfo { get; set; }
        public int SellerId { get; set; }
        public int ProductCategoryId { get; set; }
    }
}
