//Take array of nums and move all '0' to the end
// All other numbers should be in their original position
//Cannot make a copy of the array or convert it

//Will use a Temp variable to store the i of '0' and swap i+1 with i
//Then swap the '0' with the last element
//Repeat until all '0's are at the end

// Func int[] MoveZeroes(int[] nums)  **************this fails because out of range because we can't do nums[i+1] when we're at the end
//  { 
//      int temp = nums.Length -1
//      for (int i = 0; i < nums.Length; i++)
//          if (nums[i] == 0)
//              temp = nums[i];
//              nums[i] = nums[i +1];
//              temp--;
//      return nums;
// 
//New approach just remove all the 0's in a for loop and assign 0 as the value of all positions after the last non 0

int[] numArray1 = { 0, 1, 0, 3, 12 };

int[] MoveZeroes(int[] nums)
{
    int temp = 0;//lagging pointer

    for (int i = 0; i < nums.Length; i++)//iterate entire array
    {
        if (nums[i] != 0)//find non zero
        {
            nums[temp] = nums[i];//assign non zero to the lagging pointer
            temp++;//move lagging pointer to the right
        }
    }

    while (temp < nums.Length)//lagging pointer is +1 from, the last non zero
    {
        nums[temp] = 0;//assign 0 to the lagging pointer
        temp++;//move lagging pointer to the right until it reaches the end of the array
    }
    return nums;
}

Console.WriteLine(string.Join(", ", MoveZeroes(numArray1)));