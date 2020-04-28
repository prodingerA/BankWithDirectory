using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;            

namespace _12_BankWithDictionary
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string filename = @"..\..\bankAccounts.txt";
        public MainWindow()
        {
            InitializeComponent();
            myBank = new Bank(filename);
            ListboxBank.ItemsSource = myBank.BankAccounts;
            
        }
        Bank myBank;
        BankAccount selected;
        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if(TextBoxAmount.Text == "" || TextBoxName.Text == "" || TextBoxInterest.Text == "")
            {
                MessageBox.Show("Please make sure to fill in everything");
            }
            else
            {
                try
                {
                    string name = TextBoxName.Text;
                    double amount = double.Parse(TextBoxAmount.Text);
                    double interest = double.Parse(TextBoxInterest.Text);
                    if (amount < 0)
                    {
                        MessageBox.Show("You have to enter a positive amount");
                    }
                    else if(interest < 0)
                    {
                        MessageBox.Show("You have to enter a positive interest");
                    }
                    else
                    {

                        bool check = myBank.Add(name, amount, interest);
                        if (check)
                        {
                            ListboxBank.Items.Refresh();
                        }
                        else
                        {
                            MessageBox.Show("Your bankaccount already exists you have to choose a other name");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ButtonFind_Click(object sender, RoutedEventArgs e)
        {
            if(TextBoxName.Text == "")
            {
                MessageBox.Show("Please enter a bankaccount name");
            }
            else
            {
                try
                {
                    string name = TextBoxName.Text;
                    List<BankAccount> sorted = new List<BankAccount>();
                    sorted = myBank.Find(name);
                    ListboxBank.ItemsSource = sorted;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ButtonShowAll_Click(object sender, RoutedEventArgs e)
        {
            ListboxBank.ItemsSource = myBank.BankAccounts;
        }

        private void ButtonDeposit_Click(object sender, RoutedEventArgs e)
        {
            if(TextBoxAmount.Text == "")
            {
                MessageBox.Show("You have to enter a amount to deposit");
            }
            else
            { 
                    double amount = double.Parse(TextBoxAmount.Text);
                    if(amount < 0)
                    {
                        MessageBox.Show("You have to enter a positive amount");
                    }
                    else if(selected == null)
                    {
                        MessageBox.Show("You have to select a BankAccount");
                    }
                    else
                    {
                        myBank.Deposit(selected, amount);
                        ListboxBank.Items.Refresh();
                    }
            }
        }


        private void ListboxBank_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selected = new BankAccount(1, 0, "a");
            selected = (BankAccount)ListboxBank.SelectedItem;
        }

        private void ButtonWithdraw_Click(object sender, RoutedEventArgs e)
        {

            if (TextBoxAmount.Text == "")
            {
                MessageBox.Show("You have to enter a amount to withdraw");
            }
            else
            {
                try
                {
                    double amount = double.Parse(TextBoxAmount.Text);
                    if (amount < 0)
                    {
                        MessageBox.Show("You have to enter a positive amount");
                    }
                    else if (selected == null)
                    {
                        MessageBox.Show("You have to select a BankAccount");
                    }
                    else
                    {
                        bool check = myBank.Withdraw(selected, amount);
                        if (check)
                        {
                            ListboxBank.Items.Refresh();
                        }
                        else
                        {
                            MessageBox.Show("You can't withdraw more money than you have");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if(selected == null)
            {
                MessageBox.Show("Make sure to select a bankaccount to delete");
            }
            else
            {
                try
                {
                    myBank.Remove(selected);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
                ListboxBank.Items.Refresh();
            }
        }
    }
}
