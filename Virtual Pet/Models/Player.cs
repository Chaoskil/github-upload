using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virtual_Pet.Models
{
    class Player
    {
        //all of the public variables
        public string name;
        public string petName;
        public string userIn;
        public string answer;
        public int points;
        public List<Toy> ownedToys = new List<Toy>();

        //all of the private variables
        private bool answerRight;
        private int nul;

        //sets the base player to these traits, the name can be changed
        public Player()
        {
            name = "Stanley";
            points = 100;
            nul = -1;
        }

        //this lets the player change their name
        public void nameChange()
        {

            //will loop the name change until they change it, they can just put it back to Stanley if they want the default
            while (answerRight == false)
            {

                //asks if they would like to enter a name
                Console.WriteLine($"Hello {name}, would you like to change your name?");
                answer = Console.ReadLine();

                //if they say yes then they will be able to change their name
                if (answer.ToLower() == "yes")
                {

                    //makes sure that the player at some point confirms a new name
                    while (answerRight == false)
                    {

                        //asks for the new name
                        Console.WriteLine("\nWhat is your new name?");
                        userIn = Console.ReadLine();

                        //makes sure they would like to confirm that name
                        Console.WriteLine($"\nAre you sure you want to change your name to {userIn}?");
                        answer = Console.ReadLine();

                        //if they say yes than the name will be changed to what they entered
                        if (answer.ToLower() == "yes")
                        {
                            Console.WriteLine($"Your name is now {userIn}.");
                            name = userIn;

                            //ends the inner loop
                            answerRight = true;
                            Continue();
                        }

                        //if they say no then the name will stay the same
                        else if(answer.ToLower() == "no")
                        {

                            //makes sure the inner loop repeats
                            answerRight = false;
                            Continue();
                        }

                        //if they answer with something that the computer couldnt understand then they get this
                        else
                        {
                            Console.WriteLine("Sorry, couldn't read that, please enter yes or no.");

                            //makes sure the inner loop repeats
                            answerRight = false;
                            Continue();
                        }

                    }

                    //ends the loop
                    answerRight = true;

                }

                //if they say no then they will be left with the last entered name
                else if (answer.ToLower() == "no")
                {
                    Console.WriteLine($"You will still be {name}");

                    //ends the loop
                    answerRight = true;
                    Continue();
                }

                //if they type in something bad then they will get this back
                else
                {
                    Console.WriteLine("Sorry, couldn't read that, please enter yes or no.");

                    //makes sure that the loop will loop
                    answerRight = false;
                    Continue();
                }
            }

            //resets the answer check
            answerRight = false;
        }

        //the play method for the player and their pet
        public void Play()
        {
            Continue();

            //if they have no toys to choose from then they get this message
            if (ownedToys.Count == 0)
            {
                Console.WriteLine("You don't have any toys!");
                Continue();
            }

            //if they do have some toys then play will actually start
            else
            {

                //makes sure that they will have to pick a toy
                while (answerRight == false)
                {

                    //asks the player which one they want to use
                    Console.WriteLine("What toy do you wan't to use?");

                    //prints out the toys and their information while putting borders in between them
                    for (int i = 0; i < ownedToys.Count; i++)
                    {
                        Console.WriteLine("-------------------------------");
                        Console.Write($"{i+1}. ");
                        ownedToys[i].About("");
                    }
                    Console.WriteLine("-------------------------------");

                    userIn = Console.ReadLine();

                    //checks to see if they entered a number only or not
                    if (Int32.TryParse(userIn, out nul) == true)
                    {

                        //if they enter in a number within the range of the toys
                        if (Int32.Parse(userIn) >= 1 && Int32.Parse(userIn) <= ownedToys.Count)
                        {
                            //ends the loop
                            answerRight = true;

                            //tells the player that they used the toy
                            Console.WriteLine($"You used {ownedToys[Int32.Parse(userIn)-1].name} to play with {petName}.");

                            //calls the used method within the toy 
                            ownedToys[Int32.Parse(userIn) - 1].Used();

                            //tells the player how many times they have used the toy
                            Console.WriteLine($"You used {ownedToys[Int32.Parse(userIn)-1].name} {ownedToys[Int32.Parse(userIn) - 1].usage} times.");

                            Continue();

                        }

                        //if they enter in a number out of the range of toys
                        else
                        {
                            Console.WriteLine("Sorry that number is out of range.");

                            //makes sure to repeat the loop
                            answerRight = false;
                            Continue();
                        }
                    }

                    //if they enter in something other than a number
                    else
                    {
                        Console.WriteLine("Sorry couldn't read that, please enter the number of the toy you want to use.");

                        //makes sure to repeat the loop;
                        answerRight = false;
                        Continue();
                    }

                }
            }

            //resets the answer checker
            answerRight = false;
        }

        //sets the pets name in the player class to the name of the pet in the run class
        public void setPetName(string _petname)
        {
            petName = _petname;
        }

        public void Continue()
        {
            //gives a message to the user to press a button to continue
            Console.WriteLine("Press a button to continue...");
            Console.ReadKey();

            //clears the screen
            Console.Clear();

            //adds a small hud of the player name and points they have
            Console.WriteLine($"Name: {name}\nPoints: {points}");
            Console.WriteLine("-------------------------------");
        }
    }
}
