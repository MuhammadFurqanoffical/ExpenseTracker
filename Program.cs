using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            ExpenseManager expenseManager = new ExpenseManager();

            while (true)
            {
                Console.WriteLine("\nExpense Tracker Application");
                Console.WriteLine("1. Add Expense");
                Console.WriteLine("2. View Expenses");
                Console.WriteLine("3. Delete Expense");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        expenseManager.AddExpense();
                        break;
                    case "2":
                        expenseManager.ViewExpenses();
                        break;
                    case "3":
                        expenseManager.DeleteExpense();
                        break;
                    case "4":
                        Console.WriteLine("Exiting application.");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }

    class ExpenseManager
    {
        private List<Expense> expenses;

        public ExpenseManager()
        {
            expenses = new List<Expense>();
        }

        public void AddExpense()
        {
            Console.Write("Enter expense description: ");
            string description = Console.ReadLine();

            Console.Write("Enter amount (PKR): ");
            if (decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                Console.Write("Enter category (e.g., Food, Travel, Utilities): ");
                string category = Console.ReadLine();

                Expense expense = new Expense(description, amount, category);
                expenses.Add(expense);
                Console.WriteLine("Expense added successfully.");
            }
            else
            {
                Console.WriteLine("Invalid amount. Please enter a valid number.");
            }
        }

        public void ViewExpenses()
        {
            if (expenses.Count == 0)
            {
                Console.WriteLine("No expenses recorded.");
                return;
            }

            Console.WriteLine("\nExpenses:");
            Console.WriteLine("------------------------------------");
            foreach (var expense in expenses)
            {
                Console.WriteLine(expense);
            }
        }

        public void DeleteExpense()
        {
            Console.Write("Enter the index of the expense to delete (starting from 0): ");
            if (int.TryParse(Console.ReadLine(), out int index) && index >= 0 && index < expenses.Count)
            {
                expenses.RemoveAt(index);
                Console.WriteLine("Expense deleted successfully.");
            }
            else
            {
                Console.WriteLine("Invalid index. Please try again.");
            }
        }
    }

    class Expense
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string Category { get; set; }

        public Expense(string description, decimal amount, string category)
        {
            Description = description;
            Amount = amount;
            Category = category;
        }

        public override string ToString()
        {
            return $"Description: {Description}, Amount: PKR {Amount}, Category: {Category}";
        }
    }
}