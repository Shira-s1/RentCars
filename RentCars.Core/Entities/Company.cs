
namespace RentCars.Core.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }

        
        public Company(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public Company()
        {
        }
    }
}