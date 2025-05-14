using Assignment_6._3._1;

LinkedListQueue<string> customerQueue = new LinkedListQueue<string>();

customerQueue.Enqueue("John");
customerQueue.Enqueue("Jane");
customerQueue.Enqueue("Jill");
int queueCount = customerQueue.Count;


Console.WriteLine("\nCurrent caller queue is: ");
foreach (var caller in customerQueue)
{
    Console.WriteLine(caller);
}
Console.WriteLine($"Current queue count is: {queueCount}\n");

string removedCustomer = customerQueue.Dequeue();
queueCount--;

Console.WriteLine("-------------Served a customer-------------\n");

Console.WriteLine("Current caller queue is: ");
foreach (var caller in customerQueue)
{
    Console.WriteLine(caller);
}
Console.WriteLine($"\n{removedCustomer} was served and removed from the queue. ");

Console.WriteLine($"Current queue count is: {queueCount}\n");