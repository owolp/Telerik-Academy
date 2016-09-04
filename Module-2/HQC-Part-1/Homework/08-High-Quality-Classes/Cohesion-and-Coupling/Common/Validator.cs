namespace CohesionAndCoupling.Common
{
    using System;

    public abstract class Validator
    {
        public static void ValidateIntRange(int value, int min, int max, string message)
        {
            if (value <= min || value >= max)
            {
                throw new ArgumentException(message);
            }
        }
    }
}
