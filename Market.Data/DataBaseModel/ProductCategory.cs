using System;
using System.Collections.Generic;
using System.Text;

namespace Market.Data.DataBaseModel
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; } 
    }
}
