using RentCars.Enum;

namespace RentCars.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public RentStatus status { get; set; }
        public int Price { get; set; }
        public int Year { get; set; }
    }
}
