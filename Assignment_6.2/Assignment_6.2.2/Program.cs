//take an array and get the product of all the elements except for array[i]
// iterate over the array and return the products at each index.
// exclude i from the product

// int[] inputArray = {1,2,3,4,5};
// for int i = 0; i < array.length; i++
//  {
// 	    array[i] = array[i -1] * array[i +1]} and so on until we get multiple all array nums together
//            //need to account for edge cases because of the array[i -1] and array[i +1] will not always exist
//          can write if statements to account for edge cases
//  return outputArray; **********this will not work. need to have 2 loops that calculate the products of the elements to the left and right of each position.

int[] inputArray = {1,2,3,4,5};

 int[] ProductExceptSelf(int[] nums) 
{
    int n = nums.Length;
    int[] answer = new int[n];
    
    // First pass: Calculate products of all elements to the left of each position
    answer[0] = 1; // No elements to the left of first position
    for (int i = 1; i < n; i++) 
    {
        answer[i] = answer[i-1] * nums[i-1];
    }
    
    // Second pass: Multiply by products of all elements to the right
    int suffix = 1;
    for (int i = n-1; i >= 0; i--) 
    {
        answer[i] *= suffix;
        suffix *= nums[i];
    }
    
    return answer;
}
Console.WriteLine($"For array {string.Join(", ", inputArray)}, the product of all elements except itself is:");

 Console.WriteLine(string.Join(", ", ProductExceptSelf(inputArray)));
 /*int n = nums.Length;
 int[] answer = new int[n];

 ans[0] = 1; // No elements to the left of first position
 
 for (int i = 1; i < n; i++) 
 {
     answer[i] = answer[i-1] * nums[i-1];
     filling in the array with the products of the elements to the left of each position
 }

 nums[] = {1 2 3 4 }

 ans[i] = prefix
 prefix *= nums[i]

 so starting with i = 1 start the iteration at ans[1] instead of 0 since we assigned ans[0] = 1
 
 ans[0] = 1 so array is {1*, 0, 0, 0}

 ans[1 (2)] = ans[1-1 (1)] * nums[1 - 1 (1)] = 1 so answer[] is {1, 1*, 0, 0} 

 ans[2 (3)] = ans[2-1 (1)] * nums[2 - 1 (2)} = 2 so answer[] is {1, 1, 2*, 0}

 ans[3 (4)] = ans[3-1 (2)} * nums[3 - 1 (3)} = 6 so answer[] is {1, 1, 2, 6*}

 then the second loop is:

 int suffix = 1;
 for (int i = n - 1; i >= 0; i--)
 {
     answer[i] *= suffix;
     suffix *= nums[i];
     filling in the array with the products of the elements to the right of each position multiplied by the products of the elements to the left of each position
 }

 return answer;

 so starting with i = n-1

 ans[3 (6)] = 6 * suffix(1) = 6
 suffix (1) = 1 * nums[3 (4)} = 4

 ans[2 (2)] = 2 * suffix (4) = 8
 suffix (4) = 4 * nums[2 (3) = 12

 ans[1 (1) = 1 * suffix(12) = 12
 suffix(12) = 12 * nums[1 (2)] = 24

 ans[0 (1) = 1 * suffix (24) = 24
 suffix (24) = 24 * nums[0 (1)] = 24
 */

