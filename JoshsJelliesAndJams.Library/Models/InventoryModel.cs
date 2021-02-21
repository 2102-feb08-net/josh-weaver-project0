using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoshsJelliesAndJams.Library.Models
{
    public class InventoryModel
    {
        public int StoreID { get; set; }
        public List<ProductModel> Products { get; set; }
    }
}
