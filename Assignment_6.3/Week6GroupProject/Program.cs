// take a matrix and reshape it into new dimensions
// the order of values in the new matrix should be in the same order as the original input matrix
// new matrix dimensions are requested by the user 
// if the reshape operation is not possible, return the original matrix

// first check if the new dimensions are possible
// if input matrix size != requested row * col return original matrix
// create new matrix - jagged array
// newMatrix[][] = new int[desiredRows][empty];
// for (int i = 0; i < desiredRows; i++)
//  {
//     newMatrix[i] = new int[desiredCols]; 
//  }


int[][] MatrixReshape(int[][] inputMatrix, int desiredRowCount, int desiredColCount)
{
    int requiredSize = desiredRowCount * desiredColCount;
    
    if (requiredSize != inputMatrix.Length * inputMatrix[0].Length)
    {
        return inputMatrix;
    }

    int[][] newMatrix = new int[desiredRowCount][]; 
    for (int i = 0; i < desiredRowCount; i++)
    {
        newMatrix[i] = new int[desiredColCount]; //creates the columns for each row
    }// this is an empty array with the desired number of columns and rows

    int row = 0; //start at 0,0
    int col = 0;
    int inputRowCount = inputMatrix.Length;

    for(int i = 0; i < inputRowCount; i++) // one row at a time and hit each column per row
    {
        for(int j = 0; j < inputMatrix[i].Length; j++)// go through the entire column of the row
        {
            newMatrix[row][col] = inputMatrix[i][j]; // copy the values from the input matrix to the new matrix
            col++; // move to the next column

            if(col == desiredColCount)// if we have reached the end of the row
            {
                col = 0; //reset the column
                row++; // move to the next row
            }
        }
    }
    return newMatrix;
}

static void PrintMatrix(int[][] matrix)
{
    for (int i = 0; i < matrix.Length; i++)
    {
        for (int j = 0; j < matrix[i].Length; j++)
        {
            Console.Write(matrix[i][j] + " ");
        }
        Console.WriteLine();
    }
    Console.WriteLine(); // Extra line for better readability
}

int[][] testMatrix = new int[][]
{
    [1, 2],
    [3, 4]
};
int rowTest = 1;
int colTest = 4;

PrintMatrix(MatrixReshape(testMatrix, rowTest, colTest));
