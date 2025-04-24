// See https://aka.ms/new-console-template for more information

using MultithreadingConsoleApp;

var bankAccount = new BankAccount();

int iterations = 100;
var depositThread = new Thread(() =>
{
    for (int i = 0; i < iterations; i++)
    {
        bankAccount.Deposit(100);
    }
});
var withdrawalThread = new Thread(() =>
{
    for (int i = 0; i < iterations; i++)
    {
        bankAccount.Withdraw(50);
    }
});
depositThread.Start();
withdrawalThread.Start();
depositThread.Join();
withdrawalThread.Join();

Console.WriteLine($"Balance: {bankAccount.Balance}");