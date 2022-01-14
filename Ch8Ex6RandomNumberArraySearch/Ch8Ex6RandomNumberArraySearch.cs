/* Raymond Swann
 * CIST 2341 C# I
 * April 26, 2020
 * Purpose: Create a tow-dimentional array with user defined rows and columns then populate the table with random numbers.
 *          The program then searches the table and returns the largest number.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch8Ex6RandomNumberArraySearch
{
    class Ch8Ex6RandomNumberArraySearch
    {
        static void Main(string[] args)
        {
            string userInput;

            int userRow;
            int userColumn;
            int largestNumber = -1;

            Random rnd = new Random(); //initalizes the C# random class

            Console.WriteLine("This program creates a table containing random numbers, " +
                "you will input the number of rows and columns and the program will populate the table with random numbers " +
                "between 0 and 100. The program will then search through the table and return the largest number stored. \n");

            Console.Write("Enter the number of ROWS: ");//insturcts the user to enter the number of rows
            userInput = Console.ReadLine();//saves the user's input for number of rows as a string
            while(int.TryParse(userInput, out userRow) == false)//converts the user input into an int and loops back in case they do not enter a valid number
            {
                Console.WriteLine("That was not a whole number. \nPlease enter a whole number.");
                Console.Write("Enter the number of ROWS: ");
                userInput = Console.ReadLine();
            }

            Console.Write("Enter the number of COLUMNS: ");//insturcts the user to enter the number of columns
            userInput = Console.ReadLine();//saves the user's input for the number of columns as a string
            while (int.TryParse(userInput, out userColumn) == false)//converts the user input into an int and loops back in case they do not enter a valid number
            {
                Console.WriteLine("That was not a whole number. \nPlease enter a whole number.");
                Console.Write("Enter the number of COLUMNS: ");
                userInput = Console.ReadLine();
            }

            int[,] randomNumberTable = new int[userRow, userColumn];//creates a two dimentional array using the user defined number of rows and columns

            for(int r = 0; r < randomNumberTable.GetLength(0); r++)//loops through each row of the table
            {
                for (int c = 0; c < randomNumberTable.GetLength(1); c++)//loops through each column of the table
                {
                    randomNumberTable[r, c] = rnd.Next(0, 101);//assigns a random number to each cell in the table
                                                                //the random class is not inclusive so 101 only inputs numbers betwen 0 and 100
                }
            }

            foreach (int num in randomNumberTable)//looks through each number in the table
            {
                if (num > largestNumber)//assigns the value of the cell to largest number if it is larger than the previous largest number
                    largestNumber = num;
            }

            Console.Write("\nColumn\t");
            for (int colNum = 1; colNum <= randomNumberTable.GetLength(1); colNum++)
            {
                Console.Write(colNum + "\t");
            }
            Console.WriteLine();

            for (int r = 0; r < randomNumberTable.GetLength(0); r++)//loop to write the contents of the array to the console in a table form
            {
                int rowNum = r + 1;
                
                Console.Write("Row {0}:\t", rowNum);
                for(int c = 0; c < randomNumberTable.GetLength(1); c++)
                {
                    Console.Write(randomNumberTable[r, c] + "\t", r);
                }

                Console.WriteLine();
            }

            for (int r = 0; r < randomNumberTable.GetLength(0); r++)//loop to find the location of the largest number in the array
            {
                for (int c = 0; c < randomNumberTable.GetLength(1); c++)
                {
                    if (randomNumberTable[r, c] == largestNumber)
                    {
                        Console.WriteLine("\nThe largest number is " + largestNumber);
                        Console.WriteLine("Location: Row {0} Column {1}", ++r, ++c);
                        r--;
                        c--;
                    }
                }
            }

            Console.WriteLine("\nPress any key to end...");//tells the user how to end the program
            Console.ReadKey();//holds the information in the console until the user presses a key and then closes it
        }
    }
}
