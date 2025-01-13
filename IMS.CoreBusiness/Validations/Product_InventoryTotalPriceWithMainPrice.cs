using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.CoreBusiness.Validations
{
    public class Product_InventoryTotalPriceWithMainPrice:ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var product = validationContext.ObjectInstance as Product;
            if (product is not null)
            {
                
            }
            return base.IsValid(value, validationContext);
        }

        private double TotalInventoryCost(Product product)
        {
            if (product is null || product.ProductInventories == null) return 0;
            return product.ProductInventories.Sum(x => x.Inventory?.Price * x.InventoryQuantity ?? 0);
        }

        private bool ValidatePricing(Product product)
        {
            if (product.ProductInventories is null || product.ProductInventories.Count <= 0) return true;
            if (TotalInventoryCost(product) > product.Price) return false;
            return true;
        }
    }
}
