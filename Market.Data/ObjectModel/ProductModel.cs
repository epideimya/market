using Market.Data.DataBaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Market.Data.ObjectModel
{
    public class ProductModel : Product

    {
        public List<ProductImage> Images { get; set; }
        public Seller ProductSeller { get; set; }
        public ProductCategory Category { get; set; }
        public List<ProductAttributeModel> Attributes { get; set; }
    }
}
