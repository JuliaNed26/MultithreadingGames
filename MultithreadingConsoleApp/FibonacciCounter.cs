namespace MultithreadingConsoleApp;

public class FibonacciCounter
{
    private List<int> _fibonacciSequence;

    public FibonacciCounter()
    {
        _fibonacciSequence = [0, 1];
    }

    public void PrintFibonacciSequence(int maxNumber)
    {
        var thread = new Thread(() => CountFibonacci(0, 1, maxNumber));
        thread.Start();
        thread.Join();
        foreach (var num in _fibonacciSequence)
        {
            Console.WriteLine(num);
        }
    }

    private void CountFibonacci(int firstNum, int secondNum, int maxNum)
    {
        while (true)
        {
            if (secondNum > maxNum)
            {
                return;
            }

            _fibonacciSequence.Add(firstNum + secondNum);
            var firstNum1 = firstNum;
            firstNum = secondNum;
            secondNum = firstNum1 + secondNum;
        }
    }
}