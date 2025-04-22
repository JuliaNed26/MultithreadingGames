// See https://aka.ms/new-console-template for more information

using MultithreadingConsoleApp;
var countdownService = new CountdownService();
Console.WriteLine("Write number to start countdoun from: ");
var countdownNumber = Console.ReadLine();

var countdownThread = new Thread(() => countdownService.PrintCountdown(countdownNumber));
Console.WriteLine(countdownThread.IsBackground);
Console.WriteLine(countdownThread.Priority);
countdownThread.Start();
Console.WriteLine("Press spacebar to start thread");