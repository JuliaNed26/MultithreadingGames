// See https://aka.ms/new-console-template for more information

using MultithreadingConsoleApp;
var countdownService = new CountdownService();
Console.WriteLine("Write number to start countdoun from: ");
var countdownNumber = Console.ReadLine();

var countdownTask = new Task(() => countdownService.PrintCountdown(countdownNumber));
countdownTask.Start();
Console.WriteLine("Press spacebar to start thread");
try
{
    countdownTask.Wait();
}
catch (AggregateException exceptionThrownByTask)
{
    exceptionThrownByTask.Handle(ex =>
    {
        if (ex is ArgumentOutOfRangeException)
        {
            Console.WriteLine(ex.Message);
        }
        return ex is ArgumentOutOfRangeException;
    });
}