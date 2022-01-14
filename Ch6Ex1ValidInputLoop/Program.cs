/*Max Swann
 * Chapter 6 Programming Exercise 1
 * March 23, 2020
 * Purpose: Design an application that loops through user inputs and calculates the total number
 * of failed inputs and successful inputs.
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch6Ex1ValidInputLoop
{
    class Ch6Ex1ValidInputLoop
    {
        static void Main(string[] args)
        {
            int userIntInput; //user string input after it is parsed to int
            int amtValidInputs = 0; //for total number valid inputs
            int amtInvalidInputs; //for total number of invalid inputs
            int amtOutOfRange = 0; //for total number of out of range inputs
            int amtNonNumerical = 0; //for total number of non-numerical inputs
            string stringInput; //string input of user input to be tested
            bool isInputing = true; //starts the while loop

            while(isInputing)
            {
                Console.Write("Enter a positve integer value less than 100 (-99 to quit): "); //gives instructions with siential to end the loop
                stringInput = Console.ReadLine();
                if (stringInput == "-99")//checks if the sinteial has been inputed
                { 
                    break;//exits the while loop. Not the best practice but keeps the sintial from being counted as invalid input
                }
 
                if(int.TryParse(stringInput, out userIntInput) == true)//checks to see if the user input is valid within the constraints
                {
                    if (userIntInput < 100 && userIntInput > 0)//checks to see if the user input is within the bounds of the valid input
                        amtValidInputs++; //adds to the total number of valid inputs
                    else
                        amtOutOfRange++; //adds to the total number of out of range inputs
                }
                else
                {
                    amtNonNumerical++; //adds to the total number of non numerical inputs
                }
            }

            amtInvalidInputs = amtOutOfRange + amtNonNumerical; //adds the amount of out of range and non numerical inputs to get total number of invalid inputs

            Console.WriteLine("\nResults:"); //console write lines to display the results
            Console.WriteLine("Amount of VALID inputs: {0}", amtValidInputs);
            Console.WriteLine("Amout of INVALID INPUTS:{0}", amtInvalidInputs);
            Console.WriteLine("\nAmount of OUT OF RANGE inputs: {0}", amtOutOfRange);
            Console.WriteLine("Amount of NON-NUMERICAL inputs: {0}", amtNonNumerical);

            Console.WriteLine("Press any key to end"); //insutructs the user on how to end the program
            Console.ReadKey(); //holds the program and information in the console until the user is ready to end the program
            
        }
    }
}
