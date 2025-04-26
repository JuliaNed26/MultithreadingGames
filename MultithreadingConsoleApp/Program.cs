// See https://aka.ms/new-console-template for more information

using MultithreadingConsoleApp;

var threadSafeQueue = new SafeQueue<int>();

int iterations = 100;
var consumerThread = new Thread(() =>
{
    for (int i = 0; i < iterations; i++)
    {
        Console.WriteLine(threadSafeQueue.Dequeue());    
    }
});
var producerThread = new Thread(() =>
{
    for (int i = 0; i < iterations; i++)
    {
        threadSafeQueue.Enqueue(i);
    }
});
consumerThread.Start();
producerThread.Start();
producerThread.Join();
consumerThread.Join();