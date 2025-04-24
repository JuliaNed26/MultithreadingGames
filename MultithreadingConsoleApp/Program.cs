// See https://aka.ms/new-console-template for more information

using MultithreadingConsoleApp;
var countdownService = new CountdownService();
Console.WriteLine("Write number to start countdoun from: ");
var countdownNumber = Console.ReadLine();

var cancellationTokenSource = new CancellationTokenSource();
var token = cancellationTokenSource.Token;
var countdownThread1 = new Thread(() => countdownService.IncreaseLocalVariable(token));
var countdownThread2 = new Thread(() => countdownService.IncreaseLocalVariable(token));

countdownThread1.Name = "Thread 1";
countdownThread2.Name = "Thread 2";
countdownThread1.Priority = ThreadPriority.Highest;
countdownThread2.Priority = ThreadPriority.Normal;
countdownThread1.Start();
countdownThread2.Start();
cancellationTokenSource.CancelAfter(TimeSpan.FromSeconds(30));