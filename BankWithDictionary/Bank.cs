using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_BankWithDictionary
{
    class Bank
    {
        Dictionary<string, BankAccount> bank = new Dictionary<string, BankAccount>();
        string filename = null;
        FileIO file = null;
        public Dictionary<string, BankAccount>.ValueCollection BankAccounts
        {
            get
            {
                return bank.Values;
            }
        }

        public bool Add (string name, double balance, double interest)
        {
            BankAccount myAccount = new BankAccount(balance, interest, name);

            if (bank.ContainsKey(name))
            {
                return false;
            }
            bank.Add(name, myAccount);
            try
            {
                file.WriteAll(bank.Values.ToList<BankAccount>());
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public Bank(string path)
        {
            filename = path;
            file = new FileIO(filename);
            List<BankAccount> readData = file.ReadAll();
            foreach(BankAccount b in readData)
            {
                bank.Add(b.Name, b);
            }
        }
        
        public void Deposit(BankAccount ba, double amount)
        {
            ba.Deposit(amount);

        }

        public List<BankAccount> Find(string name)
        {
            List<BankAccount> founded = new List<BankAccount>();
            if (bank.ContainsKey(name))
            {
                founded.Add(bank[name]);
            }
            return founded;
        }

        public void Remove(BankAccount ba)
        {
            bank.Remove(ba.Name);
            try
            {
                file.WriteAll(bank.Values.ToList<BankAccount>());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Withdraw(BankAccount ba, double amount)
        {
            if (ba.Withdraw(amount))
            {
                try
                {
                    file.WriteAll(bank.Values.ToList<BankAccount>());
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return true;
            }
            return false;
        }
    }
}
