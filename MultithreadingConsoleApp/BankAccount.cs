namespace MultithreadingConsoleApp;

public class BankAccount
{
    private static readonly object _locker = new();

    public long Balance { get; private set; }

    public void Deposit(long sum)
    {
        lock (_locker)
        {
            Balance += sum;
        }
    }

    public void Withdraw(long sum)
    {
        lock (_locker)
        {
            Balance -= sum;
        }
    }
}