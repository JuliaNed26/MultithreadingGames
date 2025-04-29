// See https://aka.ms/new-console-template for more information

using var semaphore = new SemaphoreSlim(3, 3);

var threads = Enumerable.Range(0, 10)
    .Select(i =>
    {
        var thread = new Thread(SimulateDatabaseConnection)
        {
            Name = i.ToString()
        };
        thread.Start();
        return thread;
    })
    .ToList();

foreach (var thread in threads)
{
    thread.Join();
}


void SimulateDatabaseConnection()
{
    semaphore.Wait();
    Console.WriteLine($"Thread {Thread.CurrentThread.Name} connected to database");
    Thread.Sleep(2000);
    semaphore.Release();
    Console.WriteLine($"Thread {Thread.CurrentThread.Name} disconnected from database");
}