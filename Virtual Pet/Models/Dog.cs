using System;
using System.Collections.Generic;
using System.Text;

namespace Virtual_Pet.Models
{
    //dog is a subclass of pet
    class Dog : Pet
    {
        //the public variables, both are to hold the players answers
        public string userIn;
        public string answer;

        //the private variables, used to start the dog off and to make sure the player doesnt break anything hopefully
        private Random ran;

        //used for the tryparses
        private int nul;
        private int index;

        //used to make sure that people dont give a bad answer
        private bool answerRight;
        private string[] breeds = { "Dalmation", "Retriever", "Corgi", "Beagle", "Husky", "Terrier" };


        //when a dog is made then this sets up a random one for them to pick
        public Dog()
        {

            ran = new Random();
            //the random number given here will determine their breed
            index = ran.Next(0, 5);
            breed = breeds[index];

            //this sets the check for good answers to false, its always set back to false after being set to true so it can be used again
            answerRight = false;
            nul = -1;

            //another random number is used to determine the dogs gender(player can change it anyway
            index = ran.Next(0, 2);
            if(index == 1)
            {
                gender = "male";
            }
            else
            {
                gender = "female";
            }
        }


        //the normal about method for a dog
        public override void About()
        {
            //calls the base about method for a pet
            base.About();

            //adds in the name of the dog, breed, and gender
            Console.WriteLine($"Name: {name}\nBreed: {breed}\nGender: {gender}");
        }


        //the about method for a dog that now has an owner
        public void About(string pet)
        {
            //calls the normal dog about method
            About();

            //adds in the owners name
            Console.WriteLine($"owner: {owner}");
        }


        //the big method within the dog class, when the player wants to change any of the dogs traits, basically make their own if they want
        public void Change(string determine)
        {

            //its mostly dominated by this switch statement
            switch (determine)
            {

                //if they want to change the dogs name
                case "name":

                        //the program asks the player to enter a new one
                        Console.WriteLine("Please enter a new name:");
                        userIn = Console.ReadLine();

                    //this is here in case the player doesnt answer in yes or no so the program loops the question till they do
                    while (answerRight == false)
                    {

                        //asks for a confirmation of what they entered
                        Console.WriteLine($"Are you sure you want to change their name from {name} to {userIn}?");
                        answer = Console.ReadLine();

                        //if they answer yes then it changes the trait
                        if (answer.ToLower() == "yes")
                        {
                            Console.WriteLine($"{name} is now {userIn}.");
                            name = userIn;

                            //sets answerright to true so the loop ends
                            answerRight = true;
                            Continue();
                        }

                        //if they answer no then the trait will be the same
                        else if (answer.ToLower() == "no")
                        {
                            Console.WriteLine($"{name} will still be {name}");

                            //ends the loop, if they want to change the name again they will have to start this process over again
                            answerRight = true;
                            Continue();
                        }

                        //if they give an answer the program doesnt like then this prints out
                        else
                        {
                            Console.WriteLine("Sorry, couldn't read that, please answer with yes or no.");

                            //in case answer right was true for some reason it makes sure the loop will go again since they gave a bad answer
                            answerRight = false;
                            Continue();
                        }
                    }

                    //resets the answer checker
                    answerRight = false;

                    break;

                case "age":

                    //this is here in case the player doesnt answer inside the age range the program wants or if they type in something thats not a number
                    while (answerRight == false)
                    {

                        //the program asks the player to enter a new one
                        Console.WriteLine("Please enter their age (from 1 - 5):");
                        userIn = Console.ReadLine();

                        //this is here to make sure they enter a number alone
                        if(Int32.TryParse(userIn, out nul) == true)
                        {

                            //if they do then the loop for a number will end
                            if(Int32.Parse(userIn) >= 1 && Int32.Parse(userIn) <= 5)
                            {
                                answerRight = true;
                            }

                            //if they enter a number thats out of range they get this, anything not 1-5
                            else
                            {
                                Console.WriteLine("Sorry that age is out of range.");
                                Continue();
                            }
                        }

                        //if they enter something thats not a number they will get this
                        else
                        {
                            Console.WriteLine("Sorry couldn't read that, please enter between 1-5.");
                            Continue();
                        }

                    }

                    //resets the answer checker
                    answerRight = false;

                    //this is here in case the player doesnt answer in yes or no so the program loops the question till they do
                    while (answerRight == false)
                    {

                        //asks for a confirmation of what they entered
                        Console.WriteLine($"Are you sure you want to change their age from {age} to {userIn}?");
                        answer = Console.ReadLine();

                        //if they answer yes then it changes the trait
                        if (answer.ToLower() == "yes")
                        {
                            Console.WriteLine($"{name} is now {userIn}.");
                            age = Int32.Parse(userIn);

                            //ajusts the dogs starting level to match its age
                            level = age;

                            //sets answerright to true so the loop ends
                            answerRight = true;
                            Continue();
                        }

                        //if they answer no then the trait will be the same
                        else if (answer.ToLower() == "no")
                        {
                            Console.WriteLine($"{name} will still be {age}");

                            //ends the loop, if they want to change the name again they will have to start this process over again
                            answerRight = true;
                            Continue();
                        }

                        //if they give an answer the program doesnt like then this prints out
                        else
                        {
                            Console.WriteLine("Sorry, couldn't read that, please answer with a yes or no.");

                            //in case answer right was true for some reason it makes sure the loop will go again since they gave a bad answer
                            answerRight = false;
                            Continue();
                        }
                    }

                    //resets the answer checker
                    answerRight = false;

                    break;

                case "gender":

                    //the program asks the player to enter a new one
                    Console.WriteLine("Please enter their gender:");
                    userIn = Console.ReadLine();

                    //this is here in case the player doesnt answer in yes or no so the program loops the question till they do
                    while (answerRight == false)
                    {

                        //asks for a confirmation of what they entered
                        Console.WriteLine($"Are you sure you want to change their gender from {gender} to {userIn}?");
                        answer = Console.ReadLine();

                        //if they answer yes then it changes the trait
                        if (answer.ToLower() == "yes")
                        {
                            Console.WriteLine($"{name} is now a {userIn}.");
                            gender = userIn;

                            //sets answerright to true so the loop ends
                            answerRight = true;
                            Continue();
                        }

                        //if they answer no then the trait will be the same
                        else if (answer.ToLower() == "no")
                        {
                            Console.WriteLine($"{name} will still be a {gender}");

                            //ends the loop, if they want to change the name again they will have to start this process over again
                            answerRight = true;
                            Continue();
                        }

                        //if they give an answer the program doesnt like then this prints out
                        else
                        {
                            Console.WriteLine("Sorry, couldn't read that, please answer with a yes or no.");

                            //in case answer right was true for some reason it makes sure the loop will go again since they gave a bad answer
                            answerRight = false;
                            Continue();
                        }
                    }

                    //resets the answer checker
                    answerRight = false;

                    break;

                case "breed":

                    //the program asks the player to enter a new one
                    Console.WriteLine("Please enter their breed:");
                    userIn = Console.ReadLine();

                    //this is here in case the player doesnt answer in yes or no so the program loops the question till they do
                    while (answerRight == false)
                    {

                        //asks for a confirmation of what they entered
                        Console.WriteLine($"Are you sure you want to change their breed from {breed} to {userIn}?");
                        answer = Console.ReadLine();

                        //if they answer yes then it changes the trait
                        if (answer.ToLower() == "yes")
                        {
                            Console.WriteLine($"{name} is now a {userIn}.");
                            breed = userIn;

                            //sets answerright to true so the loop ends
                            answerRight = true;
                            Continue();
                        }

                        //if they answer no then the trait will be the same
                        else if (answer.ToLower() == "no")
                        {
                            Console.WriteLine($"{name} will still be a {breed}");

                            //ends the loop, if they want to change the name again they will have to start this process over again
                            answerRight = true;
                            Continue();
                        }

                        //if they give an answer the program doesnt like then this prints out
                        else
                        {
                            Console.WriteLine("Sorry, couldn't read that, please answer with a yes or no.");

                            //in case answer right was true for some reason it makes sure the loop will go again since they gave a bad answer
                            answerRight = false;
                            Continue();
                        }
                    }

                    //resets the answer checker
                    answerRight = false;

                    break;
            }
        }

        //the continue method used in almost all classes
        public void Continue()
        {
            //gives a message to the user to press a button to continue
            Console.WriteLine("Press a button to continue...");
            Console.ReadKey();

            //clears the screen
            Console.Clear();

            //writes the players name and points at the top of the screen always
            Console.WriteLine($"Name: {owner}\nPoints: {points}");

            //gives a line in between the about write out and the rest of what prints out on the screen to look nice
            Console.WriteLine("-------------------------------\n");
        }
    }
}
