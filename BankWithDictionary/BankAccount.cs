using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_BankWithDictionary
{
    class BankAccount
    {
        private double balance;
        private double interestRate;
        private string name;

        public double InterestRate
        {
            get{
                return interestRate;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public BankAccount(double balance, double interestRate, string name)
        {
            this.balance = balance;
            this.interestRate = interestRate;
            this.name = name;
        }
        public BankAccount(string Line)
        {
            string[] parts = Line.Split(';');
            this.name = parts[0];
            this.balance = double.Parse(parts[1]);
            this.interestRate = double.Parse(parts[2]);
        }

        public string ToStringForFile()
        {
            return name + ";" + balance + ";" + interestRate;
        }

        public void Deposit(double amount)
        {
            balance += amount;
        }

        public override string ToString()
        {
            return name + " ~ account holds " + balance + " €";
        }

        public bool Withdraw (double amount)
        {
            if(amount > balance)
            {
                return false;
            }
            balance -= amount;
            return true;
        }

    }
}
