using System;

namespace Garden
{
    class Garden
    {
        static void Main()
        {
            int seedsTomato = int.Parse(Console.ReadLine());
            int areaTomato = int.Parse(Console.ReadLine());
            int seedsCucumber = int.Parse(Console.ReadLine());
            int areaCucumber = int.Parse(Console.ReadLine());
            int seedsPotato = int.Parse(Console.ReadLine());
            int areaPotato = int.Parse(Console.ReadLine());
            int seedsCarrot = int.Parse(Console.ReadLine());
            int areaCarrot = int.Parse(Console.ReadLine());
            int seedsCabbage = int.Parse(Console.ReadLine());
            int areaCabbage = int.Parse(Console.ReadLine());
            int seedsBeans = int.Parse(Console.ReadLine());

            int area = 250;
            double amountTomato = 0.5;
            double amountCucumber = 0.4;
            double amountPotato = 0.25;
            double amountCarrot = 0.6;
            double amountCabbage = 0.3;
            double amountBeans = 0.4;

            double totalCost = seedsTomato * amountTomato + seedsPotato * amountPotato + seedsCucumber * amountCucumber + seedsCarrot * amountCarrot + seedsCabbage * amountCabbage + seedsBeans * amountBeans;

            int areaBeans = area - (areaCabbage + areaCarrot + areaCucumber + areaPotato + areaTomato);

            Console.WriteLine("Total costs: {0:F2}", totalCost);

            if (areaBeans > 0)
            {
                Console.WriteLine("Beans area: {0}", areaBeans);
            }
            else if (areaBeans == 0)
            {
                Console.WriteLine("No area for beans");
            }
            else if (areaBeans < 0)
            {
                Console.WriteLine("Insufficient area");
            }
        }
    }
}