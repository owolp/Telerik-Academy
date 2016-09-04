namespace Abstraction.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class Validator
    {
        public static void ValidateSideIsNotNegative(double value, string message)
        {
            if (value <= 0)
            {
                throw new ArgumentException(message);
            }
        }
    }
}
