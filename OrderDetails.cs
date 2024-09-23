using System;


namespace Ecommerce
{
    public class OrderDetails
    {
        private static int s_orderID = 1000;
        public string OrderID { get; }
        public string CustomerID { get; set; }
        public string ProductID { get; set; }
        public int TotalPrice { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int Quantity { get; set; }

        public OrderStatus Status { get; set; }

        public OrderDetails(string customerID, string productId, int totalPrice, DateTime purchaseDate, int quantity, OrderStatus status)
        {
            s_orderID++;
            OrderID = "OID" + s_orderID;
            CustomerID = customerID;
            ProductID = productId;
            TotalPrice = totalPrice;
            PurchaseDate = purchaseDate;
            Quantity = quantity;
            Status = status;
        }

        
        // This contructor is used for ReadfromCSV method
        public OrderDetails(string orders)
        {
            string[] values = orders.Split(",");
            s_orderID = int.Parse(values[0].Remove(0, 3));
            OrderID = values[0];
            CustomerID = values[1];
            ProductID = values[2];
            TotalPrice = int.Parse(values[3]);
            PurchaseDate = DateTime.ParseExact(values[4],"dd/MM/yyyy",null);
            Quantity = int.Parse(values[5]);
            Status = Enum.Parse<OrderStatus>(values[6]);
        }


    }
}