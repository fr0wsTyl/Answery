namespace Answery.Data.Models
{
    using Common.Models;

    public class Car : BaseModel<int>
    {
        public string Brand { get; set; }

        public string Color { get; set; }

        public decimal Price { get; set; }

        public string PlateNumber { get; set; }
    }
}
