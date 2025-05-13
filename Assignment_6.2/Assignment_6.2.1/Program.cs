//take an array and push individual ins into a stack
//pop the stack last element of the stack
//print the stack

int[] arr = [2, 4, 6, 8, 10, 12, 14, 16, 18, 20];
int top = arr.Length; // assign the length of the array to the top value

Stack<int> intStack = new Stack<int>();//stack to hold ints from array. 

foreach (var myNums in arr)
{
    intStack.Push(myNums); // push individual numbers from the array into the stack
}

intStack.Pop();
top--; //decrement the top value to match the stack size

foreach (var number in intStack)
{
    Console.WriteLine(string.Join(", ", number));
}
Console.WriteLine($"The top value is: {top}" );//this gives the current size of the stack
intStack.Pop();
top--;
Console.WriteLine($"The top value is: {top}" ); // we cannot use top as an index in a stack like we can in an array :(