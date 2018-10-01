using System;
using System.Collections.Generic;
using System.Text;

namespace Virtual_Pet.Models
{
    class Run
    {
        //all of the variables in run
        string userIn;
        bool answerRight;
        int nul;

        //all of the class objects being created
        Store theStore;
        Player User;
        List<Dog> List;
        Dog playerDog;

        //things that need to be set up before the player does anything
        public Run()
        {

            //creates a store, a player, and a list of dogs for them to choose
            theStore = new Store();
            User = new Player();
            List = new List<Dog>();

            //adds three dogs to the list
            List.Add(new Dog());
            List.Add(new Dog());
            List.Add(new Dog());

            //sets the answer checker variables
            answerRight = false;
            nul = -1;
        }

        //the main methid of the run class that dictates the game set up stuff
        public void Play()
        {

            //introduces the game
            Console.WriteLine("Hello this is a Virtual Dog game!\n");
            Continue();

            //calls the namechange method within the player class
            User.nameChange();

            //gives the chosen player name to the store for later
            theStore.name = User.name;

            //makes sure to loop the question if they dont answer well
            while (answerRight == false)
            {

                //asks which dog they would like to adopt
                Console.WriteLine("\nNow choose your dog, (Enter 1, 2, or 3)");

                //prints out the list of dogs and gives each a border
                for(int i = 0; i < 3; i++)
                {
                    Console.WriteLine("-------------------------------");
                    List[i].About();
                }
                Console.WriteLine("-------------------------------");

                userIn = Console.ReadLine();

                //makes sure they enter a number alone
                if (Int32.TryParse(userIn, out nul) == true)
                {

                    //makes sure the number is within the range of 1-3
                    if (Int32.Parse(userIn) >= 1 && Int32.Parse(userIn) <= 3)
                    {
                        answerRight = true;
                    }

                    //if the number is out of that range then the player gets this message
                    else
                    {
                        Console.WriteLine("Sorry that number is out of range.");
                        Continue();
                    }
                }

                //if they enter in something other than a number they get this
                else
                {
                    Console.WriteLine("Sorry couldn't read that, please enter the number of the dog.");
                    Continue();
                }

            }

            //resets the answer checker
            answerRight = false;

            //the playerdog makes a copy of the player choesen dog so that it can be used throughout the program
            playerDog = List[(Int32.Parse(userIn)-1)];

            //tells the player the dog they adopted
            Console.WriteLine($"Congrats you adopted {playerDog.name}!");

            //sets the dogs owner to the player name
            playerDog.owner = User.name;

            //sets the point value throughout the program
            setPoints();

            Continue();

            //makes sure a good answer is given
            while (answerRight == false)
            {

                //prints out the player owned dogs information on screen
                Console.WriteLine("-------------------------------");
                playerDog.About("owned");
                Console.WriteLine("-------------------------------");

                //asks the user if they want to change any traits(make their own dog basically)
                Console.WriteLine($"Would you like to change any traits of {playerDog.name}? (enter name, age, gender, breed, or no)");
                userIn = Console.ReadLine();

                //if they want to change the name then it calls the change class within dog and gives it the string name
                if (userIn.ToLower() == "name")
                {
                    playerDog.Change("name");

                    //also sets the new name in player class
                    User.setPetName(playerDog.name);
                }

                //same thing but for age
                else if (userIn.ToLower() == "age")
                {
                    playerDog.Change("age");
                }

                //same thing but for gender
                else if (userIn.ToLower() == "gender")
                {
                    playerDog.Change("gender");
                }

                //same thing but for breed
                else if (userIn.ToLower() == "breed")
                {
                    playerDog.Change("breed");
                }

                //if they say no then the dog edit will end
                else if (userIn.ToLower() == "no")
                {
                    Console.WriteLine($"{playerDog.name} will remain the same.");

                    //stops the loop
                    answerRight = true;
                    Continue();
                }

                //if they enter in something that the program doesnt like
                else
                {
                    Console.WriteLine("Sorry couldn't read that, please enter the trait to change or no.");
                    Continue();
                }
            }

            //sets the pets name in the player class
            User.setPetName(playerDog.name);

            //resets the answer check
            answerRight = false;

            //calls the life method in run
            Life();

        }

        //this is the game method, its set aside so that if the program were to use files then there could be an easy way to implement save data
        public void Life()
        {

            //makes sure a good answer is given
            while (answerRight == false)
            {

                //asks the player what they would like to do
                Console.WriteLine($"What would you like to do now?\n\nShop\n\nPlay with {playerDog.name}\n\nQuit");
                userIn = Console.ReadLine();

                //determines what happens depending on the player answer
                switch (userIn.ToLower())
                {

                    //if they want to go to the shop then it runs from the store class
                    case "shop":

                        //gives the store the current amount of points that the player has
                        theStore.points = User.points;

                        //runs the store from its class
                        theStore.runStore();

                        //once they are done with the store if they had bought something this will happen
                        if(theStore.boughtToy == true)
                        {

                            //the game takes the remaining points from the store and updates the players points
                            User.points = theStore.returnPoints();

                            //adds the newly bought toy to the players list of toys
                            User.ownedToys.Add(theStore.giveToy());
                        }

                        //sets the points of the player throught the program again
                        setPoints();
                        break;

                        //if they want to play with their dog then this will run
                    case "play":

                        //calls the play method within the player class
                        User.Play();

                        //goes through all of the players toys after the method is finished
                        for(int i = 0; i < User.ownedToys.Count; i++)
                        {

                            //checks to see if the toy has been used enough times for a skill to be earned
                            if (User.ownedToys[i].CheckUse() == "no")
                            {
                                //if no then this text will print out to inform the player
                                Console.WriteLine($"{playerDog.name} didn't learn anything from {User.ownedToys[i]} this time");
                                Continue();
                            }

                            //if it has been used enough times then this will happen
                            else
                            {

                                //if the dog has skills already
                                if (playerDog.skills.Count > 0)
                                {

                                    //goes through all current skills
                                    for (int j = 0; j < playerDog.skills.Count; j++)
                                    {

                                        //if the skill the dog has matches with the one connected to the current toy
                                        if(playerDog.skills[j] == User.ownedToys[i].CheckUse())
                                        {

                                            //the skill will level up and the player will recieve 100 points
                                            Console.WriteLine($"{playerDog.name}'s skill {User.ownedToys[i].CheckUse()} leveled up!");
                                            Console.WriteLine($"{playerDog.name} leveled up!\n you earned 100 points!");

                                            //adds more to the skill counter number so it can level up again
                                            User.ownedToys[i].increaseSkillLearn();

                                            //adds a level to the player dog
                                            playerDog.level = playerDog.level + 1;

                                            //adds the points for the user
                                            User.points += 100;

                                            //sets the points throughout the program again
                                            setPoints();
                                            Continue();
                                        }

                                    }                                     
                                }

                                //if they dont know the skill then this runs
                                else
                                {

                                    //it informs the player that the dog just learned a new skill and they earned points
                                    Console.WriteLine($"{playerDog.name} learned the skill {User.ownedToys[i].CheckUse()}!");
                                    Console.WriteLine($"{playerDog.name} leveled up!\n you earned 100 points!");

                                    //does the same as the first set, increases all these things and seets the points across the game
                                    User.ownedToys[i].increaseSkillLearn();
                                    playerDog.skills.Add(User.ownedToys[i].skill);
                                    playerDog.level = playerDog.level + 1;
                                    User.points += 100;
                                    setPoints();
                                    Continue();
                                }
                            }
                        }
                        break;

                        //if they enter quit then the loop will break and the application begins closing
                    case "quit":

                        answerRight = true;
                        break;

                        //if they answer with anything the program doesnt want then the player gets this
                    default:
                        Console.WriteLine("Sorry couldn't read that, please answer with shop, play, or quit.");
                        Continue();

                        break;
                }

            }

            //when the application closes the player gets this
            Continue();
            Console.WriteLine("See you later!");
            Continue();
        }
        

        public void Continue()
        {
            //gives a message to the user to press a button to continue
            Console.WriteLine("Press a button to continue...");
            Console.ReadKey();

            //clears the screen
            Console.Clear();

            //adds a small hud with the player name and points earned
            Console.WriteLine($"Name: {User.name}\nPoints: {User.points}");
            Console.WriteLine("-------------------------------\n");
        }

        //sets all other points variables in other classes with the hud attachment
        public void setPoints()
        {
            playerDog.points = User.points;
            theStore.points = User.points;
        }

    }
}
