using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeAndTravel
{
    class Program
    {
        static void Main(string[] args)
        {
            // TO DO:
            /*
•	Implement a “craft” command
o	A Person can craft items, provided he has some items in his inventory
o	A Person should be able to craft Weapons and Armor
o	Crafting an Armor requires that the Person has Iron in his inventory
	Results in adding an Armor item in the Person’s inventory
o	Crafting a Weapon requires that the Person has Iron and Wood in his inventory
o	Syntax: Joro craft newItemName - gathers an item, naming it newItemName if the Person Joro has the necessary 

             */

            var engine = new Engine(new InteractionManagerExtentions());
            engine.Start();
        }
    }
}
