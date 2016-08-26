namespace TradeAndTravel
{
    using System.Linq;

    public class InteractionManagerExtentions : InteractionManager
    {
        protected override Item CreateItem(string itemTypeString, string itemNameString, Location itemLocation, Item item)
        {
            switch (itemTypeString)
            {
                case "weapon":
                    return new Weapon(itemNameString, itemLocation);
                case "wood":
                    return new Wood(itemNameString, itemLocation);
                case "iron":
                    return new Iron(itemNameString, itemLocation);
                default:
                    return base.CreateItem(itemTypeString, itemNameString, itemLocation, item);
            }
        }

        protected override Location CreateLocation(string locationTypeString, string locationName)
        {
            switch (locationTypeString)
            {
                case "mine":
                    return new Mine(locationName);
                case "forest":
                    return new Forest(locationName);
                default:
                    return base.CreateLocation(locationTypeString, locationName);
            } 
        }

        protected override Person CreatePerson(string personTypeString, string personNameString, Location personLocation)
        {
            switch (personTypeString)
            {
                case "merchant":
                    return new Merchant(personNameString, personLocation);
                default:
                    return base.CreatePerson(personTypeString, personNameString, personLocation);
            }            
        }

        protected override void HandlePersonCommand(string[] commandWords, Person actor)
        {
            switch (commandWords[1])
            {
                case "gather":
                    HandleGatherInteraction(actor, commandWords[2]);
                    break;
                default:
                    base.HandlePersonCommand(commandWords, actor);
                    break;
            }
                    
        }

        private void HandleGatherInteraction(Person actor, string itemName)
        {
            if (actor.Location is IGatheringLocation)
            {
                var gatheringLocation = actor.Location as IGatheringLocation;
                if (actor.ListInventory().Any(i => i.ItemType == gatheringLocation.RequiredItem))
                {
                    this.AddToPerson(actor, gatheringLocation.ProduceItem(itemName));
                }
            }
            //if (actor.Location.LocationType == LocationType.Forest && actor.ListInventory().Any(i => i.ItemType == ItemType.Weapon))
            //{
            //    this.AddToPerson(actor, new Wood(itemName));
            //}

            //if (actor.Location.LocationType == LocationType.Mine && actor.ListInventory().Any(i => i.ItemType == ItemType.Armor))
            //{
            //    this.AddToPerson(actor, new Iron(itemName));
            //}
        }
    }
}