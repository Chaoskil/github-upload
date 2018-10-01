using System;
using System.Collections.Generic;
using System.Text;

namespace Virtual_Pet.Models
{
    class Store
    {

        //all the public variables of store
        public int points;
        public string userIn;
        public string name;
        public Toy bought;
        public bool boughtToy;

        //all of the private variables
        private int nul;
        private bool answerRight;
        List<Toy> toys;

        //this initializes some variables once the store is made
        public Store()
        {
            nul = -1;
            toys = new List<Toy>();

            //the answerright makes sure answers are what the program wants
            answerRight = false;
            boughtToy = false;

            //adds 4 toys to the store
            toys.Add(new Toy("ball"));
            toys.Add(new Toy("rope"));
            toys.Add(new Toy("chew"));
            toys.Add(new Toy("frisbee"));
        }

        //the big method of store, it runs it but the whole buying part is done elsewhere
        public void runStore()
        {
            Continue();

            //makes sure the player doesnt give a bad answer
            while (answerRight == false)
            {

                //gives an intro to the store and presents the player with their options
                Console.WriteLine("Welcome to the Store!\nWhat would you like to do?\n\nBuy\n\nLeave");
                userIn = Console.ReadLine();
                Continue();

                //the switch that determines what happens after the player enters their decision
                switch (userIn.ToLower())
                {

                    //if they answer with buy then they are brought to the buy method
                    case "buy":

                        Buy();

                        //ends the loop
                        answerRight = true;
                        break;
                       
                    //if they answer with leave then they will leave the store
                    case "leave":

                        Console.WriteLine("See you!");

                        //ends the loop
                        answerRight = true;
                        Continue();

                        break;

                    //if they answer in a bad manner than the player gets stuck with this
                    default:

                        Console.WriteLine("Sorry couldn't reaad that, please enter buy or leave.");
                        Continue();

                        break;
                }
            }

            //resets the answer check
            answerRight = false;
        }


        //the buy method that checks what they want to buy and if they can
        public void Buy()
        {

            //makes sure that the answer they give is useable
            while (answerRight == false)
            {

                //gives them instructions for what to do
                Console.WriteLine("Choose what you want to buy!, (Enter 1, 2, 3, 4, or no thanks)");

                //prints out all of the toys with a border to seperate them
                for (int i = 0; i < 4; i++)
                {
                    Console.WriteLine("-------------------------------");
                    toys[i].About();
                }
                Console.WriteLine("-------------------------------");

                userIn = Console.ReadLine();

                //checks to make sure they answer with a number
                if (Int32.TryParse(userIn, out nul) == true)
                {

                    //if they do then it needs to be in range, this checks that
                    if (Int32.Parse(userIn) >= 1 && Int32.Parse(userIn) <= 4)
                    {

                        //makes sure the toy isnt already sold out
                        if(toys[Int32.Parse(userIn) - 1].name == "SOLD OUT")
                        {

                            //if  it is then they cant buy it
                            Console.WriteLine("Sorry that's sold out.");
                            Continue();
                        }

                        //if it isnt sold out then they can buy it only if they have enough points
                        else if (points >= toys[Int32.Parse(userIn)-1].price)
                        {
                            //this makes of copy of the toy to give to the players list of toys
                            bought = toys[Int32.Parse(userIn)-1];

                            //it also takes the points the player spent away from their point count
                            points -= bought.price;

                            //tells them that they bought the item
                            Console.WriteLine($"Congrats you bought {bought.name}!");

                            //replaces the toy they bought with a sold out
                            toys.Insert(Int32.Parse(userIn)-1, new Toy("sold"));
                            toys.RemoveAt(Int32.Parse(userIn));

                            //tells the game that a toy was bought
                            boughtToy = true;

                            //ends the loop
                            answerRight = true;
                            Continue();
                        }

                        //if they dont have enough points then this prints out
                        else
                        {
                            Console.WriteLine("Sorry you don't have enough points");
                            Continue();
                        }
                    }

                    //if they give a bad number this prints out
                    else
                    {
                        Console.WriteLine("Sorry that number is out of range.");
                        Continue();
                    }
                }

                //if they dont want to buy anything then the loop ends
                else if(userIn.ToLower() == "no thanks")
                {
                    Console.WriteLine("Come again!");

                    //ends the loop
                    answerRight = true;
                    Continue();
                }

                //if they just answer with gibberish this will happen
                else
                {
                    Console.WriteLine("Sorry couldn't read that, please answer with the given choices.");
                    Continue();
                }
            }

            //resets the answer checker
            answerRight = false;

        }

        //gives all remaining points back to the player
        public int returnPoints()
        {
            return points;
        }

        //returns the toy that was just bought
        public Toy giveToy()
        {
            boughtToy = false;
            return bought;
        }

        public void Continue()
        {
            //gives a message to the user to press a button to continue
            Console.WriteLine("Press a button to continue...");
            Console.ReadKey();

            //clears the screen
            Console.Clear();

            //prints out a little hud for the player and their points on the screen
            Console.WriteLine($"Name: {name}\nPoints: {points}");
            Console.WriteLine("-------------------------------\n");
        }


    }
}
