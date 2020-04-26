using System;
using System.Collections.Generic;
using System.Text;

namespace Market.Data.DataBaseModel
{
    public class ProductAttributeValue
    {
        public int Id { get; set; }
        public int ProductAttributeId { get; set; }
        public int ProductId { get; set; }
        public string Value { get; set; }
    }
}
