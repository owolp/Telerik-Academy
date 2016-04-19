using System;

namespace CoffeeMachine
{
    class CoffeeMachine
    {
        static void Main()
        {
            double c05 = double.Parse(Console.ReadLine());
            double c10 = double.Parse(Console.ReadLine());
            double c20 = double.Parse(Console.ReadLine());
            double c50 = double.Parse(Console.ReadLine());
            double c1 = double.Parse(Console.ReadLine());
            double amountDeveloper = double.Parse(Console.ReadLine());
            double pricePerDrink = double.Parse(Console.ReadLine());

            double moneyMachine = c05 * 0.05 + c10 * 0.10 + c20 * 0.20 + c50 * 0.50 + c1 * 1;

            double change = amountDeveloper - pricePerDrink;
            double moneyMachineAfterChange = moneyMachine - change;

            if (change > moneyMachine)
            {
                Console.WriteLine("No {0:F2}", Math.Abs(moneyMachineAfterChange));
            }
            else if (amountDeveloper >= pricePerDrink)
            {
                Console.WriteLine("Yes {0:F2}", moneyMachineAfterChange);
            }
            else if (pricePerDrink > amountDeveloper)
            {
                Console.WriteLine("More {0:F2}", pricePerDrink - amountDeveloper);
            }

        }
    }
}
