// See https://aka.ms/new-console-template for more information

using MultithreadingConsoleApp;

var threadSafeQueue = new SafeQueue<int>();

// Mutex always should be disposed! Othervise it'll block other threads or will cause MutexAbandonedException called
using var mutex = new Mutex(false, "NamedMutex");

// will try to acquire thread for one millisecond. If it still used by another thread - returns false
while (!mutex.WaitOne(TimeSpan.FromMilliseconds(1)))
{
    Console.WriteLine("Another instance of app is running!");
}

int iterations = 100000;
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

// release Mutex
mutex.ReleaseMutex();