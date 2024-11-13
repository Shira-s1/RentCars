using RentCars.Enum;
using System.Xml.Linq;

namespace RentCars.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public CompanyE Cname { get; set; }//companyEnum
        public string Name { get; set; }
        public RentStatus Status { get; set; }
        public int Price { get; set; }
        public int LicensePlate { get; set; }//לוחית רישוי
        public int Model { get; set; }//שנה
       


        public Car(int id, CompanyE cname, string name, RentStatus status, int price, int model, int LicensePlate)
        {
            this.LicensePlate = LicensePlate;
            this.Id = id;
            this.Cname = cname;
            this.Name = name;
            this.Status = status;
            this.Price = price;
            this.Model = Model;
        }
        public int CalcSum(int price, int year) { return 0; }//מחיר יומי שיחושב לפי שנה וסוג רכב
        public override string ToString()
        {
            return "Id: " + Id + " " + "Company Name: " + Cname + " " + " User Name: " + Name + " " +
                "Status: " + Status + " " + "Price: " + Price + " " + "Model" + Model;
        }


    }
}
