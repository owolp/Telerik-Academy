using System;

namespace DrunkenNumbers
{
    class DrunkenNumbers
    {
        static void Main()
        {
            int rounds = int.Parse(Console.ReadLine());

            int beersVladko = 0;
            int beersMitko = 0;

            for (int i = 0; i < rounds; i++)
            {

                var drunkenNumber = int.Parse(Console.ReadLine());
                drunkenNumber = Math.Abs(drunkenNumber);
                int drunkedNumberLength = drunkenNumber.ToString().Length;

                for (int v = 0; v < drunkedNumberLength / 2; v++)
                {
                    var digit = drunkenNumber % 10;
                    beersVladko += digit;
                    drunkenNumber /= 10;
                }


                if (drunkedNumberLength % 2 == 1)
                {
                    var digit = drunkenNumber % 10;
                    beersVladko += digit;
                    beersMitko += digit;
                    drunkenNumber /= 10;
                }

                for (int m = 0; m < drunkedNumberLength / 2; m++)
                {
                    var digit = drunkenNumber % 10;
                    beersMitko += digit;
                    drunkenNumber /= 10;
                }
            }

            if (beersMitko > beersVladko)
            {
                Console.WriteLine("M " + (beersMitko - beersVladko));
            }

            else if (beersVladko > beersMitko)
            {
                Console.WriteLine("V " + (beersVladko - beersMitko));
            }
            else
            {
                Console.WriteLine("No " + (beersMitko + beersVladko));
            }
        }
    }
}
