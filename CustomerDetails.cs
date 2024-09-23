using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce
{
    public class CustomerDetails
    {
        private static int s_customerID = 3000;
        public string CustomerID { get; }
        public string CustomerName { get; set; }
        public string City { get; set; }
        public long MobileNumber { get; set; }
        private int s_walletBalance;
        public int WalletBalance { get { return s_walletBalance; } }

        public string EmailID { get; set; }

        public CustomerDetails(string customerName, string city, long mobileNumber, int walletBalance, string emailID)
        {
            s_customerID++;
            CustomerID = "CID" + s_customerID;
            CustomerName = customerName;
            City = city;
            MobileNumber = mobileNumber;
            s_walletBalance = walletBalance;
            EmailID = emailID;
        }



        // This contructor is used for ReadfromCSV method
        public CustomerDetails(string customer)
        {
            string[] values = customer.Split(",");

            s_customerID = int.Parse(values[0].Remove(0, 3));
            CustomerID = values[0];
            CustomerName = values[1];
            City = values[2];
            MobileNumber = long.Parse(values[3]);
            s_walletBalance = int.Parse(values[4]);
            EmailID = values[5];
        }


        public void WalletRecharge(int amount)
        {
            s_walletBalance += amount;
        }

        public void DeductBalance(int amount)
        {
            s_walletBalance -= amount;
        }

    }
}