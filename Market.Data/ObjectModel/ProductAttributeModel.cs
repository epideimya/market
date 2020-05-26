using System;
using System.Collections.Generic;
using System.Text;

namespace Market.Data.ObjectModel
{
    public class ProductAttributeModel 
    {
        public int TeamplateAttributeId { get; set; }
        public string TeamplateAttributeName { get; set; }
        public int ValueAttributeId { get; set; }
        public string Value { get; set; }
    }
}
