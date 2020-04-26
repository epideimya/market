using System;
using System.Collections.Generic;
using System.Text;

namespace Market.Data.DataBaseModel
{
    public class ProductImage
    {
        public int Id { get; set; }
        public string URL { get; set; }
        public int ProductId { get; set; }
    }
}
