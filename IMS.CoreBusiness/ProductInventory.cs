using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


/*
 * Create a many to many relationship table
 * */
namespace IMS.CoreBusiness
{
    public class ProductInventory
    {
        public int ProductId {  get; set; }
        [JsonIgnore]
        public Product? Product { get; set; } //Navigation property 
        public int InventoryId {  get; set; }
        [JsonIgnore]
        public Inventory? Inventory { get; set; }//Navigation property 
        public int InventoryQuantity {  get; set; }
    }
}
