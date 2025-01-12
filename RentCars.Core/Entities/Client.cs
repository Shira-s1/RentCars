using System.Xml.Linq;

namespace RentCars.Core.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int LicenseNumber { get; set; }//רשיון
        public string Address { get; set; }
        public string Email { get; set; }
        
        public DateTime DateOfBirth { get; set; }
        public Client(int id, string name, string phoneNumber, int LicenseNumber, string Address, string Email, DateTime dateOfBirth)//add
        {
            this.Id = id;
            this.Name = name;
            this.PhoneNumber = phoneNumber;
            this.LicenseNumber = LicenseNumber;
            this.Address = Address;
            this.Email = Email;
            this.DateOfBirth = dateOfBirth;
        }
        public Client()
        {
            
        }


      
        public override string ToString()//print the items
        {
            return "Id: " + Id + " "  + " User Name: " + Name + " " +
                "phoneNumber: " + PhoneNumber + " " + "LicenseNumber: " + LicenseNumber ;
        }

    }
}
