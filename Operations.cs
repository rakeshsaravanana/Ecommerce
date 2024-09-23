using System;
using System.Collections.Generic;

namespace Ecommerce
{
    public static class Operations
    {

        public static List<CustomerDetails> customerDetailList = new List<CustomerDetails>();
        public static List<ProductDetails> productDetailList = new List<ProductDetails>();
        public static List<OrderDetails> orderDetailList = new List<OrderDetails>();

        public static CustomerDetails loggedCustomer;

        public static void MainMenu()
        {
            try
            {
                bool flag = true;
                do
                {
                    System.Console.WriteLine("*****Main Menu*******");
                    System.Console.WriteLine("Select options\n1.CustomerRegistration\n2.Login\n3.Exit:");
                    System.Console.WriteLine("Enter the option:");
                    int option = int.Parse(Console.ReadLine());
                    switch (option)
                    {
                        case 1:
                            {
                                //CustomerRegistration()
                                CustomerRegistration();
                                break;
                            }
                        case 2:
                            {
                                // Login()
                                Login();
                                break;
                            }
                        case 3:
                            {
                                //Exit
                                flag = false;
                                break;
                            }
                    }

                }
                while (flag);

            }
            catch (Exception ex)
            {

                System.Console.WriteLine(ex.Message);
            }
        }

        public static void CustomerRegistration()
        {
            try
            {
                System.Console.WriteLine("****Customer Registration******");
                System.Console.WriteLine("Enter your Name:");
                string name = Console.ReadLine();
                System.Console.WriteLine("Enter your city:");
                string city = Console.ReadLine();
                System.Console.WriteLine("Enter your MobileNumber:");
                long mobileNumber = long.Parse(Console.ReadLine());
                System.Console.WriteLine("Enter the amount to add in wallet:");
                int walletBalance = int.Parse(Console.ReadLine());
                System.Console.WriteLine("Enter your emailID:");
                string emailID = Console.ReadLine();
                CustomerDetails customer = new CustomerDetails(name, city, mobileNumber, walletBalance, emailID);
                customerDetailList.Add(customer);

                System.Console.WriteLine($"You have registered successfully.Your customerID is {customer.CustomerID}");

            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }

        }
        public static void Login()
        {
            try
            {
                bool flag = true;
                do
                {
                    System.Console.WriteLine("*****Login******");
                    System.Console.WriteLine("Enter your CustomerID:");
                    string customerID = Console.ReadLine().ToUpper();
                    foreach (CustomerDetails customer in customerDetailList)
                    {
                        if (customer.CustomerID == customerID)
                        {
                            flag = false;
                            loggedCustomer = customer;
                            System.Console.WriteLine("Login Successfully!");
                            SubMenu();
                            break;

                        }
                    }
                    if (flag)
                    {
                        System.Console.WriteLine("Invalid CustomerID!");
                    }


                }
                while (flag);


            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }

        }

        public static void SubMenu()
        {
            try
            {
                bool flag = true;
                do
                {
                    System.Console.WriteLine("*****Sub Menu******");
                    System.Console.WriteLine("Select options\n1.Purchase\n2.OrderHistory\n3.CancelOrder\n4.WalletBalance\n5.WalletRecharge\n6.Exit:");
                    System.Console.WriteLine("Enter the options:");
                    int option = int.Parse(Console.ReadLine());
                    switch (option)
                    {
                        case 1:
                            {
                                //Purchase();
                                Purchase();
                                break;
                            }
                        case 2:
                            {
                                //OrderHistory()
                                OrderHistory();
                                break;
                            }
                        case 3:
                            {
                                //CancelOrder()
                                CancelOrder();
                                break;
                            }
                        case 4:
                            {
                                //WalletBalance()
                                WalletBalance();
                                break;
                            }
                        case 5:
                            {
                                //WalletRecharge()
                                WalletRecharge();
                                break;
                            }
                        case 6:
                            {
                                flag = false;
                                break;
                            }
                    }

                }
                while (flag);


            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }

        public static void Purchase()
        {
            try
            {
                foreach (ProductDetails product in productDetailList)
                {
                    System.Console.WriteLine($"ProductID : {product.ProductID} | ProdcutName : {product.ProductName} | Stock : {product.Stock} | Price : {product.Price} | ShippingDuration : {product.ShippingDuration}");

                }
                System.Console.WriteLine("Enter the productID to purchase:");
                string productID = Console.ReadLine().ToUpper();
                bool flag = true;
                foreach (ProductDetails product1 in productDetailList)
                {
                    if (product1.ProductID == productID)
                    {
                        flag = false;
                        System.Console.WriteLine("Enter the quantity of products you need?:");
                        int quantityCount = int.Parse(Console.ReadLine());
                        if (product1.Stock >= quantityCount)
                        {
                            int deliveryCharge = 50;
                            int totalAmount = (quantityCount * product1.Price) + deliveryCharge;
                            if (loggedCustomer.WalletBalance >= totalAmount)
                            {
                                loggedCustomer.DeductBalance(totalAmount);
                                product1.Stock -= quantityCount;
                                OrderDetails order = new OrderDetails(loggedCustomer.CustomerID, product1.ProductID, totalAmount, DateTime.Now, quantityCount, OrderStatus.Ordered);
                                orderDetailList.Add(order);

                                System.Console.WriteLine($"Order placed Successfully.OrderID is {order.OrderID}");
                                System.Console.WriteLine($"Your ordered will be delivered on {order.PurchaseDate.AddDays(product1.ShippingDuration)}");

                            }
                            else
                            {
                                System.Console.WriteLine("Insufficient Balance.Please recharge your wallet and do the purchase again");
                            }

                        }

                        else
                        {
                            System.Console.WriteLine($"Required count not available.Current availability is {product1.Stock}");
                        }

                    }
                }
                if (flag)
                {
                    System.Console.WriteLine("Invalid ProductID!");
                }



            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }

        }
        public static void OrderHistory()
        {
            try
            {
                bool flag = true;
                foreach (OrderDetails order in orderDetailList)
                {
                    if (loggedCustomer.CustomerID == order.CustomerID)
                    {
                        flag = false;
                        System.Console.WriteLine($"OrderID : {order.OrderID} | CustomerID : {order.CustomerID} | ProductID : {order.ProductID} | TotalPrice : {order.TotalPrice} | PurchaseDate : {order.PurchaseDate} | Quantity : {order.Quantity} | OrderStatus : {order.Status}");
                    }
                }
                if (flag)
                {
                    System.Console.WriteLine("You have no Order History.Please make a purchase.");
                }

            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }

        }
        public static void CancelOrder()
        {
            try
            {
                System.Console.WriteLine("*****Cancel Order******");
                foreach (OrderDetails order in orderDetailList)
                {
                    if (order.CustomerID == loggedCustomer.CustomerID && order.Status == OrderStatus.Ordered)
                    {
                        System.Console.WriteLine($"OrderID : {order.OrderID} | CustomerID : {order.CustomerID} | ProductID : {order.ProductID} | TotalPrice : {order.TotalPrice} | PurchaseDate : {order.PurchaseDate} | Quantity : {order.Quantity} | OrderStatus : {order.Status} ");
                    }
                }
                bool flag = true;
                System.Console.WriteLine("Enter the ordereID is cancel the order:");
                string orderID = Console.ReadLine().ToUpper();

                // Already order cancelled condition.
                foreach (OrderDetails order1 in orderDetailList)
                {
                    if (order1.OrderID == orderID && order1.Status == OrderStatus.Cancelled)
                    {
                        flag = false;
                        System.Console.WriteLine("You have no orders to cancel!.");
                        break;
                    }

                }

                if (flag)
                {
                    //checking with orderID to cancel.
                    foreach (OrderDetails order2 in orderDetailList)
                    {
                        if (order2.OrderID == orderID)
                        {
                            flag = false;
                            foreach (ProductDetails product in productDetailList)
                            {
                                if (product.ProductID == order2.ProductID)
                                {
                                    product.Stock += order2.Quantity;
                                    loggedCustomer.WalletRecharge(order2.TotalPrice);
                                    order2.Status = OrderStatus.Cancelled;
                                    System.Console.WriteLine($"{order2.OrderID} is cancelled Successfully.");
                                    break;
                                }
                            }
                        }
                    }
                    if (flag)
                    {
                        System.Console.WriteLine("Invalid OrderID!");
                    }

                }




            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }

        }
        public static void WalletBalance()
        {
            try
            {
                System.Console.WriteLine("*****Wallet Balance*****");
                System.Console.WriteLine($"Your WalletBalance is {loggedCustomer.WalletBalance}");

            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }

        }
        public static void WalletRecharge()
        {
            try
            {
                System.Console.WriteLine("******Wallet Recharge********");
                System.Console.WriteLine("Do you want to recharge your wallet:1.Yes 2.No:");
                int option = int.Parse(Console.ReadLine());
                if (option == 1)
                {
                    System.Console.WriteLine("Enter the amount to recharge your wallet:");
                    int amount = int.Parse(Console.ReadLine());
                    loggedCustomer.WalletRecharge(amount);
                    System.Console.WriteLine($"Your updated WalletBalance is {loggedCustomer.WalletBalance}");
                }


            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }

        }


        public static void DefaultData()
        {
            customerDetailList.Add(new CustomerDetails("Ravi", "chennai", 9887773888, 50000, "ravi@gmail.com"));
            customerDetailList.Add(new CustomerDetails("Raja", "chennai", 9887773999, 60000, "raja@gmail.com"));


            productDetailList.Add(new ProductDetails("Mobile(Samsung)", 10, 10000, 3));
            productDetailList.Add(new ProductDetails("Tablet(Lenovo)", 5, 15000, 2));
            productDetailList.Add(new ProductDetails("Camara(Sony)", 3, 20000, 4));
            productDetailList.Add(new ProductDetails("iphone", 5, 50000, 6));
            productDetailList.Add(new ProductDetails("Laptop(Lenovo)", 3, 40000, 3));
            productDetailList.Add(new ProductDetails("HeadPhones(Boat)", 5, 1000, 2));

            orderDetailList.Add(new OrderDetails("CID3001", "PID2001", 20000, DateTime.Now, 2, OrderStatus.Ordered));
            orderDetailList.Add(new OrderDetails("CID3002", "PID2003", 40000, DateTime.Now, 2, OrderStatus.Ordered));





        }
    }
}