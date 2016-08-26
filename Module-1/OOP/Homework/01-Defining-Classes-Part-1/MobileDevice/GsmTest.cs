namespace MobileDevice
{
    public class GsmTest
    {
        // fields
        public static readonly Gsm[] MobilePhones =
            {
        new Gsm("OnePlus One", "OnePlus", 100, "NA", new Display(5, 1000000), new Battery(BatteryType.LiIon, 100, 50)),
        new Gsm("OnePlus Two", "OnePlus", 200, "NA", new Display(5.5, 1000000), new Battery(BatteryType.LiIon, 200, 150)),
        new Gsm("OnePlus Three", "OnePlus", 300, "NA", new Display(6, 1000000), new Battery(BatteryType.LiIon, 300, 250)),
            };
    }
}