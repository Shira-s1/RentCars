using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace RentCars.Core.Entities
{
    public class Orders
    {
        [Key]
        public int NumOrder { get; set; }//מספר הזמנה
        public int ClientId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int CarId { get; set; }//מספר רישוי- לשנות שם
       
        public string CreditCardNumber { get; set; }//מספר אשראי

        public string PaymentMethod { get; set; }  // כרטיס אשראי / העברה בנקאית / תשלום אחר


        public Orders(int numOrder, int clientId, DateTime dateFrom, DateTime dateTo, int carId, string creditCardNumber, string paymentMethod)
        {
            this.NumOrder = numOrder;
            this.ClientId = clientId;
            this.DateFrom = dateFrom;
            this.DateTo = dateTo;
            this.CarId = carId;
            this.CreditCardNumber = creditCardNumber;
            this.PaymentMethod = paymentMethod;
        }

        public Orders()
        {
        }
        public override string ToString() //print
        {
            return "Order Number: " + NumOrder + " " + "Client Id: " + ClientId + " " + "Date of renting : " + DateFrom + " " +
                "Return the car: " + DateTo + " " + "Car Id: " + CarId;
        }

    }
}
