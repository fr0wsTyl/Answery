namespace Answery.Web.ViewModels
{
    using Data.Models;
    using Infrastructure.Mapping.MvcTemplate.Web.Infrastructure.Mapping;
    public class CarViewModel : IMapFrom<Car>
    {
        public string Brand { get; set; }

        public string Color { get; set; }
    }
}