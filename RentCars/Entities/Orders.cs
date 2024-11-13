using System.Xml.Linq;

namespace RentCars.Entities
{
    public class Orders
    {
        public int NumOrder { get; set; }//מספר הזמנה
        public int ClientId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int CarId { get; set; }//מספר רישוי- לשנות שם

        //dalete
        //change
        //cala price 
        //פונקציה שמשתמשת בחישוב המחיר שנמצא ברכב וסוכמת את הכול לפי חישוב הימים

        public Orders(int numOrder, int clientId, DateTime dateFrom, DateTime dateTo, int carId)
        {
            this.NumOrder = numOrder;
            this.ClientId = clientId;
            this.DateFrom = dateFrom;
            this.DateTo = dateTo;
            this.CarId = carId;

        }
        public int CalcPrice(DateTime dateFrom, DateTime dateTo) {
            //להשתמש בפונקציה SUMPRICE במחלקת רכב כדי לחשב סכום כללי
            return 0;
        }
        public void Change(int numOrder, DateTime dateFrom, DateTime dateTo) { }
        public void Delete(int numOrder) { }
        public override string ToString() //print
        {
            return "Order Number: " + NumOrder + " " + "Client Id: " + ClientId + " " + "Date of renting : " + DateFrom + " " +
                "Return the car: " + DateTo + " " + "Car Id: " + CarId;
        }

    }
}
