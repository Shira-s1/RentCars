using RentCars.Core.Entities;
using RentCars.Core.Enum;
using RentCars.Core.Interfaces;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using RentCars.Srevice.Services;


namespace RentCars.Srevice.Services
{
    public class CarService
    {
        private readonly IDataContext _dataContext;
            public CarService(IDataContext dataContext) 
        { _dataContext = dataContext; }
        //    public int CalcSum(int price, int year, int cntDats, CompanyE cname)//מחיר כללי  
        //    {
        //        int sum = price;
        //        if (year > 2023)
        //        {
        //            sum += 200;
        //        }
        //        foreach (CompanyE company in CompanyE.GetValues(typeof(CompanyE)))
        //        {
        //            if ((int)company > 15)
        //            {
        //                sum += 1000;
        //            }
        //        }
        //        sum += (cntDats * 250);
        //        return sum;
        //    }

        //    public bool UpdateCar(int id, Car updatedCar) // עדכון רכב קיים
        //    {
        //        var carToUpdate = _dataContext.carList.FirstOrDefault(c => c.Id == id);
        //        if (carToUpdate == null)
        //            return false;
        //        carToUpdate.Cname = updatedCar.Cname;
        //        carToUpdate.Name = updatedCar.Name;
        //        carToUpdate.Status = updatedCar.Status;
        //        carToUpdate.Price = updatedCar.Price;
        //        carToUpdate.LicensePlate = updatedCar.LicensePlate;
        //        carToUpdate.Model = updatedCar.Model;
        //        return true;
        //    }

        //    public void ChangeStatus(int status, Car c)
        //    {
        //        var car = _dataContext.carList.FirstOrDefault(car => car.Id == c.Id);
        //        if(car ==null) 
        //            return;
        //        car.Status = (RentStatus)status;
        //    }


        //public CarsController(IDataContext context)
        //{
        //    _dataContext = context;
        //}

        private readonly CarService _carService;
        public List<Car> GetCars() //מחזירה את רשימת הרכבים
        {
            return _dataContext.carList;
        }


        public Car Search(int id)// מחפשת רכב לפי מזהה
        {
            return _dataContext.carList.FirstOrDefault(f => f.Id == id);
        }

        public void AddCar(Car newCar)
        {
            // מוסיפה רכב חדש לרשימת הרכבים
            _dataContext.carList.Add(newCar);
        }


        public void UpdateCar(Car updatedCar)
        {
            Car existingCar = _dataContext.carList.FirstOrDefault(car => car.Id == updatedCar.Id);
            if (existingCar != null)
            {
                existingCar.Model = updatedCar.Model;
                existingCar.LicensePlate = updatedCar.LicensePlate;
                existingCar.Id = updatedCar.Id;
                existingCar.Cname = updatedCar.Cname;
                existingCar.Name = updatedCar.Name;
                existingCar.Status = updatedCar.Status;
                existingCar.Price = updatedCar.Price;
              
            }
            else
            {
                throw new Exception("Car not found");
            }
        }

        public void Delete(int id)
        {
            Car carToDelete = _dataContext.carList.FirstOrDefault(car => car.Id == id);
            if (carToDelete != null)
            {
                _dataContext.carList.Remove(carToDelete); // מסירה את הרכב מהרשימה
            }

            else
            {
                throw new Exception("Car not found");
            }
        }
    }


}
