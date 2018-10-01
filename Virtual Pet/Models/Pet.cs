using System;
using System.Collections.Generic;
using System.Text;

namespace Virtual_Pet.Models
{
    class Pet
    {
        //all of the public variables
        //the level of the pet
        public int level;

        //age of the pet
        public int age;

        //the points that the player holds
        public int points;

        //name of the pet
        public string name;

        //breed of the pet
        public string breed;

        //the name of the owner
        public string owner;

        //the gender of the pet
        public string gender;

        //a list of skills for the pet
        public List<string> skills;



        //all of the private variables
        //this random is for the class alone
        private Random ran = new Random();

        //the variable to hold the randomly picked number
        private int index;

        //an array of random names for the pet
        private string[] names = { "Sammy", "Fifi", "Jordan", "Sophie", "Stella", "Corky" };

        //when a pet is created this is immediately called
        public Pet()
        {

            //a new skill list is created to hold the skills of the pet
            skills = new List<string>();

            //a random number 
            index = ran.Next(0, 5);
            name = names[index];

            age = ran.Next(1, 5);
            level = age;
        }

        //The about method for pets
        public virtual void About()
        {
            //simply writes out the level of the pet and writes out the age as well
            Console.WriteLine($"Level: {level}\nAge: {age}");
        } 
            
    }
}
