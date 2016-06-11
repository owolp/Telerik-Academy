namespace MobileDevice
{
    using System;
    using System.Linq;

    public class GSMCallHistoryTest
    {
        public static void DisplayInformation()
        {
            double fixedPrice = 0.37;
            var smartphone = new Gsm("Fancy Phone", "Bulgaria");
            string separator = new string('=', 100);

            smartphone.AddCall(new Call(new DateTime(2015, 1, 18, 12, 01, 00), "+ 359 123 456 789", 60));
            smartphone.AddCall(new Call(new DateTime(2016, 2, 19, 13, 02, 00), "+ 359 876 543 210", 90));
            smartphone.AddCall(new Call(new DateTime(2017, 3, 20, 14, 03, 00), "+ 359 000 000 000", 10));

            Console.WriteLine("Call History Information:");

            foreach (var callHistoryItem in smartphone.CallHistoryInformation())
            {
                Console.WriteLine(callHistoryItem);
            }

            smartphone.CallHistoryInformation();

            Console.WriteLine(separator);
            Console.WriteLine("Total Price of Calls: {0} BGN", smartphone.TotalCallPrice(fixedPrice));
            Console.WriteLine(separator);

            Call longestCall = smartphone.CallHistory.OrderByDescending(x => x.Duration).First();

            smartphone.DeleteCall(longestCall);

            Console.WriteLine("Total Price after last call removed: {0} BGN", smartphone.TotalCallPrice(fixedPrice));
            Console.WriteLine(separator);
            Console.WriteLine("History cleared:");

            smartphone.ClearHistory();

            smartphone.CallHistoryInformation();

            Console.WriteLine(separator);
        }
    }
}