using System.Xml.Linq;

namespace RentCars.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int LicenseNumber { get; set; }//רשיון

        public Client(int id, string name, string phoneNumber, int LicenseNumber)//add
        {
            this.Id = id;
            this.Name = name;
            this.PhoneNumber = phoneNumber;
            this.LicenseNumber = LicenseNumber;

        }
       
        
        
        //3 cars options
        public override string ToString()//print the items
        {
            return "Id: " + Id + " "  + " User Name: " + Name + " " +
                "phoneNumber: " + PhoneNumber + " " + "LicenseNumber: " + LicenseNumber ;
        }

    }
}
