namespace ConsoleApp85
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter the data to create the matrix 1:");
                MyMatrix matrix_1 = Input();
                Console.WriteLine("Enter the data to create the matrix 2:");
                MyMatrix matrix_2 = Input();
                Operations(matrix_1, matrix_2);
            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        static void Operations(MyMatrix matrix_1, MyMatrix matrix_2)
        {
            MyMatrix matrix_11 = matrix_1;
            MyMatrix matrix_12 = matrix_2;
            Console.WriteLine("Transposed matrix 1:");
            matrix_1.TransponeMe();
            matrix_1.PrintMatrix();
            Console.WriteLine("Transposed matrix 2:");
            matrix_2.TransponeMe();
            matrix_2.PrintMatrix();
            Console.WriteLine("Matrix multiplication: ");
            (matrix_11 * matrix_12).PrintMatrix();
            Console.WriteLine("Adding matrices: ");
            (matrix_11 + matrix_12).PrintMatrix();
        }
        static MyMatrix Input()
        {
            Console.WriteLine("Enter 1 if you want to create a copy of another MyMatrix.");
            Console.WriteLine("Enter 2 if you want to type a two-dimensional array (double[,]).");
            Console.WriteLine("Enter 3 if you want to enter a jagged array (double[][]).");
            Console.WriteLine("Enter 4 if you want to enter an array of strings.");
            Console.WriteLine("Enter 5 if you want to enter the matrix as one row.");
            MyMatrix originalMatrix;
            int choice = int.Parse(Console.ReadLine() ?? "0");

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter the dimension of the matrix you want to create for copying: ");
                    int rows1 = int.Parse(Console.ReadLine());
                    int cols1 = int.Parse(Console.ReadLine());

                    double[,] elements1 = new double[rows1, cols1];
                    Console.WriteLine("Enter the elements of the matrix: ");
                    for (int i = 0; i < rows1; i++)
                    {
                        for (int j = 0; j < cols1; j++)
                        {
                            elements1[i, j] = double.Parse(Console.ReadLine());
                        }
                    }
                    originalMatrix = new MyMatrix(elements1);
                    return originalMatrix;

                case 2:
                    Console.WriteLine("Enter the number of rows and columns: ");
                    int rows2 = int.Parse(Console.ReadLine());
                    int cols2 = int.Parse(Console.ReadLine());

                    double[,] elements2 = new double[rows2, cols2];
                    Console.WriteLine("Enter the elements of the matrix: ");
                    for (int i = 0; i < rows2; i++)
                    {
                        for (int j = 0; j < cols2; j++)
                        {
                            elements2[i, j] = double.Parse(Console.ReadLine());
                        }
                    }
                    originalMatrix = new MyMatrix(elements2);
                    return originalMatrix;

                case 3:
                    Console.WriteLine("Enter the number of rows: ");
                    int rows3 = int.Parse(Console.ReadLine());

                    double[][] jaggedArray = new double[rows3][];
                    for (int i = 0; i < rows3; i++)
                    {
                        Console.WriteLine($"Enter the number of columns for row {i + 1}: ");
                        int cols3 = int.Parse(Console.ReadLine());
                        jaggedArray[i] = new double[cols3];

                        Console.WriteLine($"Enter the elements for row {i + 1}: ");
                        for (int j = 0; j < cols3; j++)
                        {
                            jaggedArray[i][j] = double.Parse(Console.ReadLine());
                        }
                    }
                    originalMatrix = new MyMatrix(jaggedArray);
                    return originalMatrix;

                case 4:
                    Console.WriteLine("Enter the number of rows: ");
                    int rows4 = int.Parse(Console.ReadLine());

                    string[] stringArray = new string[rows4];
                    Console.WriteLine("Enter the lines (one at a time): ");
                    for (int i = 0; i < rows4; i++)
                    {
                        stringArray[i] = Console.ReadLine() ?? string.Empty;
                    }
                    originalMatrix = new MyMatrix(stringArray);
                    return originalMatrix;

                case 5:
                    Console.WriteLine("Enter the elements of the matrix with a space: ");
                    string input = Console.ReadLine();
                    string[] elementsString = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    int rows5 = int.Parse(elementsString[0]);
                    int cols5 = int.Parse(elementsString[1]);
                    double[,] elements5 = new double[rows5, cols5];

                    for (int i = 0; i < rows5; i++)
                    {
                        for (int j = 0; j < cols5; j++)
                        {
                            elements5[i, j] = double.Parse(elementsString[(i * cols5) + j + 2]); // +2, щоб пропустити розміри
                        }
                    }
                    originalMatrix = new MyMatrix(elements5);
                    return originalMatrix;

                default:
                    Console.WriteLine("Wrong choice. A classic matrix will be entered!");
                    double[,] elements6 = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
                    originalMatrix = new MyMatrix(elements6);
                    return originalMatrix;
            }
        }
    }
}
