namespace Cars.ConsoleClient.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Cars.Models;

    public class CarJsonModel
    {
        public int Year { get; set; }

        public TransmissionType TransmissionType { get; set; }

        public string ManufacturerName { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        public DealerJsonModel Dealer { get; set; }
    }
}
