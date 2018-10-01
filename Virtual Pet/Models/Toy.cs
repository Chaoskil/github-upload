using System;
using System.Collections.Generic;
using System.Text;

namespace Virtual_Pet.Models
{

    //toy is a subclass of item since toy is an item
    class Toy : Item
    {

        //when the toy is created it needs to be given a string to determine what toy it will be
        public Toy(string type)
        {

            //this determins what toy it will be
            switch (type)
            {

                //if given the string "ball" then the toy will be a ball
                case "ball":

                    //sets the item name appropriately
                    name = "Rubber ball";

                    //gives a skill specific to the item
                    skill = "Track";

                    //sets how many times the item needs to be used before the skill is given
                    numberTillSkill = 5;

                    //sets the price of the item
                    price = 100;
                    break;

                //if given the string "rope" then the toy will be a rope
                case "rope":

                    //sets the item name appropriately
                    name = "Rope";

                    //gives a skill specific to the item
                    skill = "Tug";

                    //sets how many times the item needs to be used before the skill is given
                    numberTillSkill = 7;

                    //sets the price of the item
                    price = 200;
                    break;

                //if given the string "chew" then the toy will be a chew toy
                case "chew":

                    //sets the item name appropriately
                    name = "Chew Toy";

                    //gives a skill specific to the item
                    skill = "Strength";

                    //sets how many times the item needs to be used before the skill is given
                    numberTillSkill = 9;

                    //sets the price of the item
                    price = 300;
                    break;

                //if given the string "frisbee" then the toy will be a frisbee
                case "frisbee":

                    //sets the item name appropriately
                    name = "Frisbee";

                    //gives a skill specific to the item
                    skill = "Catch";

                    //sets how many times the item needs to be used before the skill is given
                    numberTillSkill = 11;

                    //sets the price of the item
                    price = 400;
                    break;

                //if given the string "sold" then the toy will be sold out
                case "sold":

                    //sets the name to sold out to tell the player they already bought the item
                    name = "SOLD OUT";

                    //sets the price to 0 to match
                    price = 0;
                    break;
            }
        }


        //The basic About for any Toy object, this is used to show what the toy is being sold in the store
        public void About()
        {

            //simply prints out the name of the item and the price of it directly underneath
            Console.WriteLine($"Toy: {name}\n Price: {price}");
        }



        //This About is basically the same as the one above but only prints out the item name
        public void About(string waste)
        {

            //Only prints the name of the item, mostly used when the player owns the item
            Console.WriteLine($"{name}");
        }


        //when this method is called the item will gain one use so the system can track how many times an item was used
        public void Used()
        {

            //only adds 1
            usage ++;
        }


        //This method will increase the amount of uses the item needs in order to give/level up the attached skill to the pet
        public void increaseSkillLearn()
        {

            //it always increases by 5
            numberTillSkill += 5;
        }


        //This method is used to check if the item has been used enough times to meet the required number to give a skill/level one up
        public string CheckUse()
        {

            //This is where the values of usage and numbertillskill are compared
            if(usage >= numberTillSkill)
            {

                //if they are the same or if usage is somehow higher than the method will return the items skill
                return skill;
            }
            else
            {

                //if usage is lower, than the method will return a "no"
                return "no";
            }
        }
    }
}
