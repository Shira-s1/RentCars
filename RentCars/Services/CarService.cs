using RentCars.Entities;
using RentCars.Enum;
using RentCars.Interfaces;

namespace RentCars.Services
{
    public class CarService 
    {
        private readonly IDataContext _dataContext; 
        public CarService(IDataContext dataContext) { _dataContext = dataContext; }
        public int CalcSum(int price, int year, int cntDats, CompanyE cname)//מחיר כללי  
        {
            int sum = price;
            if (year > 2023)
            {
                sum += 200;
            }
            foreach (CompanyE company in CompanyE.GetValues(typeof(CompanyE)))
            {
                if ((int)company > 15)
                {
                    sum += 1000;
                }
            }
            sum += (cntDats * 250);
            return sum;
        }

        public bool UpdateCar(int id, Car updatedCar) // עדכון רכב קיים
        {
            var carToUpdate = _dataContext.carList.FirstOrDefault(c => c.Id == id);
            if (carToUpdate == null)
                return false;
            carToUpdate.Cname = updatedCar.Cname;
            carToUpdate.Name = updatedCar.Name;
            carToUpdate.Status = updatedCar.Status;
            carToUpdate.Price = updatedCar.Price;
            carToUpdate.LicensePlate = updatedCar.LicensePlate;
            carToUpdate.Model = updatedCar.Model;
            return true;
        }

        public void ChangeStatus(int status, Car c)
        {
            var car = _dataContext.carList.FirstOrDefault(car => car.Id == c.Id);
            if(car ==null) 
                return;
            car.Status = (RentStatus)status;
        }
    }
}
