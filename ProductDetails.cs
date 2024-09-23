using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce
{
    public class ProductDetails
    {
        private static int s_productID = 2000;
        public string ProductID { get; }
        public string ProductName { get; set; }
        public int Stock { get; set; }
        public int Price { get; set; }
        public int ShippingDuration { get; set; }

        public ProductDetails(string productName, int stock, int price, int shippingDuration)
        {
            s_productID++;
            ProductID = "PID" + s_productID;
            ProductName = productName;
            Stock = stock;
            Price = price;
            ShippingDuration = shippingDuration;
        }


        // This contructor is used for ReadfromCSV method
        public ProductDetails(string products)
        {
            string[] values = products.Split(",");
            s_productID = int.Parse(values[0].Remove(0, 3));
            ProductID = values[0];
            ProductName = values[1];
            Stock = int.Parse(values[2]);
            Price = int.Parse(values[3]);
            ShippingDuration = int.Parse(values[4]);
        }
    }
}