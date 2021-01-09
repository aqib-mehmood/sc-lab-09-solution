using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee_Shop_App
{
    public class Class1
    {
        private string cust_Name;

        private double cust_Balance;
        
        // class under test
        public const string Error1 = "Debit amount exceeds balance";
        public const string Error2 = "Debit amount less than zero";



        private bool shop_Close = false;



        private Class1()
        {
        }



        public Class1(string customerName, double balance)
        {
            cust_Name = customerName;
            cust_Balance = balance;
        }



        public string CustomerName
        {
            get { return cust_Name; }
        }



        public double Balance
        {
            get { return cust_Balance; }
        }

        public string Cust_Name { get => cust_Name; set => cust_Name = value; }
        public double Cust_Balance { get => cust_Balance; set => cust_Balance = value; }

        public void Debit(double amount)
        {
            if (shop_Close)
            {
                throw new Exception("Account frozen");
            }

            if (amount > cust_Balance)
            {
                throw new ArgumentOutOfRangeException("amount", amount, Error1);
            }



            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount", amount, Error2);
            }
            cust_Balance -= amount;
        }
        public void Credit(double amount)
        {
            if (shop_Close)
            {
                throw new Exception("Account frozen");
            }
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount");
            }
            cust_Balance += amount;
        }
        private void FreezeAccount()
        {
            shop_Close = true;
        }



        private void UnfreezeAccount()
        {
            shop_Close = false;
        }



        public static void Main()
        {
            CalltoActionMethod();
        }

        private static void CalltoActionMethod()
        {
            Class1 ba = new Class1("Mr. Bryan Walton", 11.99);
            ba.Credit(5.77);
            ba.Debit(11.22);
            Console.WriteLine("Current balance is ${0}", ba.Balance);
        }
    }
}
