using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;        
using System.Linq.Expressions;

namespace _12_BankWithDictionary
{
    class FileIO
    {
        string path = "";

        public FileIO(string path)
        {
            this.path = path;
        }

        public List<BankAccount> ReadAll()
        {
            List<BankAccount> myBankAccounts = new List<BankAccount>();

            if (File.Exists(this.path))
            {
                StreamReader reader = new StreamReader(this.path);
                try
                {
                    string line = reader.ReadLine();

                    while (line != null)
                    {
                        BankAccount myAccount = new BankAccount(line);
                        myBankAccounts.Add(myAccount);
                        line = reader.ReadLine();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    reader.Close();
                }
            }
            return myBankAccounts;
        }
        public void WriteAll(List<BankAccount> myBankAccounts)
        {
            StreamWriter writer = new StreamWriter(this.path, false);
            try
            {
                foreach (BankAccount b in myBankAccounts)
                {
                    writer.WriteLine(b.ToStringForFile());
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                writer.Close();
            }
        }
    }
}
