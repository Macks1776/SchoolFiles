/*Max Swan
 *CIST2341
 *March 3, 2020
 *Purpose: class for a program to create new objects with methods 
*/
using System;

namespace Project4MoneyClass
{
    class Money
    {
        private int dollars;
        private int cents;
        private decimal fullAmount;

        //Constructors
        public Money()//default constructor
        {

        }

        public Money(int dollarsUser, int centsUser)//allows the class to be made with two ints for dollars and cents
        {
            dollars = dollarsUser;
            cents = centsUser;
        }

        public Money(decimal amount)//allows the class to be made with a single value to represent dollars and cents
        {
            fullAmount = amount;
            dollars = (int)(amount * 100) / 100;
            cents = (int)((amount * 100) % 100);
        }

        //Properties for data members
        public int Dollars //return or set dollars
        {
            get
            {
                return dollars;
            }
            set
            {
                dollars = value;
            }
        }

        public int Cents //return or set cents
        {
            get
            {
                return cents;
            }
            set
            {
                cents = value;
            }
        }

        public decimal FullAmount //return or set fullAmount
        {
            get
            {
                return fullAmount;
            }
            set
            {
                fullAmount = value;
            }
        }

        //Methods
        public void IncrementMoney(decimal amount) //adds the user given value to the stored value
        {
            decimal newValue;
            decimal dollarAmount;

            dollarAmount = ConvertToOneNumber();
            newValue = dollarAmount + amount;
            GetNewDollarsAndCents(newValue);
        }

        public void DecrementMoney(decimal amount) //subtracts the user given value from the stored value
        {
            decimal newValue;
            decimal dollarAmount;

            dollarAmount = ConvertToOneNumber();
            newValue = dollarAmount - amount;
            GetNewDollarsAndCents(newValue);
        }

        public decimal ConvertToOneNumber()//takes seprate int values for dollars and cents, combines them for one number representing the full amount
        {
            decimal dollarAmount;

            dollarAmount = dollars + (cents / 100.0m);
            return dollarAmount;
        }

        public void GetNewDollarsAndCents(decimal newValue)//takes a decmial value representing the full dollar amount and converts it to separate ints for dollars and cents
        {
            dollars = (int)(newValue * 100) / 100;
            cents = (int)((newValue * 100) % 100);
        }

        public string GetCoins(int dollars, int cents)//takes the dollar and cents and breaks it down into individual coins
        {
            int quarters;
            int dimes;
            int nickles;
            int pennies;
            int leftOver;

            quarters = cents / 25;
            leftOver = cents % 25;
            dimes = leftOver / 10;
            leftOver = leftOver % 10;
            nickles = leftOver / 5;
            pennies = leftOver % 5;

            return "Dollars: " + dollars +
                    "\nQuarters: " + quarters +
                    "\nDimes: " + dimes +
                    "\nNickles: " + nickles +
                    "\nPennies: " + pennies;
        }

        public override string ToString()//overrides the ToString method to make it formatted for currancy
        {
            return ConvertToOneNumber().ToString("C");
        }

    }
}
