using System;
using System.IO;
using System.Net.Mime;
using System.Runtime.CompilerServices;

namespace Ecommerce
{
    public static class FileHandling
    {
        public static void Create()
        {
            // folder creation
            if (!Directory.Exists("Ecommerce"))
            {
                System.Console.WriteLine("creating a folder...");
                Directory.CreateDirectory("Ecommerce");
            }

            if (!File.Exists("Ecommerce/CustomerDetails.csv"))
            {
                System.Console.WriteLine("File is creating...");
                File.Create("Ecommerce/CustomerDetails.csv").Close();
            }

            if (!File.Exists("Ecommerce/ProductDetails.csv"))
            {
                System.Console.WriteLine("File is creating...");
                File.Create("Ecommerce/ProductDetails.csv").Close();
            }

            if (!File.Exists("Ecommerce/OrderDetails.csv"))
            {
                System.Console.WriteLine("File is creating...");
                File.Create("Ecommerce/OrderDetails.csv").Close();
            }
        }

        public static void WritetoCSV()
        {
            // For customerDetails
            string[] customers = new string[Operations.customerDetailList.Count];

            for (int i = 0; i < Operations.customerDetailList.Count; i++)
            {
                customers[i] = Operations.customerDetailList[i].CustomerID + "," + Operations.customerDetailList[i].CustomerName + "," + Operations.customerDetailList[i].City + "," + Operations.customerDetailList[i].MobileNumber + "," + Operations.customerDetailList[i].WalletBalance + "," + Operations.customerDetailList[i].EmailID;
            }
            File.WriteAllLines("Ecommerce/CustomerDetails.csv", customers);


            // For productDetails
            string[] products = new string[Operations.productDetailList.Count];
            for (int i = 0; i < Operations.productDetailList.Count; i++)
            {
                products[i] = Operations.productDetailList[i].ProductID + "," + Operations.productDetailList[i].ProductName + "," + Operations.productDetailList[i].Stock + "," + Operations.productDetailList[i].Price + "," + Operations.productDetailList[i].ShippingDuration;
            }
            File.WriteAllLines("Ecommerce/ProductDetails.csv", products);

            string[] orders = new string[Operations.orderDetailList.Count];
            for (int i = 0; i < Operations.orderDetailList.Count; i++)
            {
                orders[i] = Operations.orderDetailList[i].OrderID + "," + Operations.orderDetailList[i].CustomerID + "," + Operations.orderDetailList[i].ProductID + "," + Operations.orderDetailList[i].TotalPrice + "," + Operations.orderDetailList[i].PurchaseDate.ToString("dd/MM/yyyy") + "," + Operations.orderDetailList[i].Quantity + "," + Operations.orderDetailList[i].Status;
            }
            File.WriteAllLines("Ecommerce/OrderDetails.csv", orders);
        }

        public static void ReadfromCSV()
        {
            // for customerDetails
            string[] customers = File.ReadAllLines("Ecommerce/CustomerDetails.csv");
            foreach (string customer in customers)
            {
                CustomerDetails customerobj = new CustomerDetails(customer);
                Operations.customerDetailList.Add(customerobj);
            }

            //for ProductDetails
            string[] products = File.ReadAllLines("Ecommerce/ProductDetails.csv");
            foreach (string product in products)
            {
                ProductDetails product1 = new ProductDetails(product);
                Operations.productDetailList.Add(product1);
            }

            // for orderdetails
            string[] orders = File.ReadAllLines("Ecommerce/OrderDetails.csv");
            foreach (string order in orders)
            {
                OrderDetails order1 = new OrderDetails(order);
                Operations.orderDetailList.Add(order1);
            }

        }
    }
}