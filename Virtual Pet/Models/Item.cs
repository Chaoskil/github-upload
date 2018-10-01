using System;
using System.Collections.Generic;
using System.Text;

namespace Virtual_Pet.Models
{
    class Item
    {

        //all of the variable for an item
        //the name of the item
        public string name;

        //the skill that the item carries
        public string skill;

        //the price of the item
        public int price;

        //how many times the item was used
        public int usage;

        //the amount of time before 
        public int numberTillSkill;

        //happens as soon as an item is made
        public Item()
        {
            //sets usage to 0
            usage = 0;
        }

    }
}
