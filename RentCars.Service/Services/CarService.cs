using Microsoft.EntityFrameworkCore;
using RentCars.Core.Entities;
using RentCars.Core.Enum;
using RentCars.Core.Interfaces;
using RentCars.Data;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Xml.Linq;


namespace RentCars.Service.Services
{
    public class CarService : ICarService
    {
        private readonly DataContext _dataContext;
        public CarService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<Car> GetCars() //מחזירה את רשימת הרכבים
        {
           return _dataContext.carList.Include(c => c.Cname).ToList();

        }


        public Car GetSearch(int id)// מחפשת רכב לפי מזהה
        {
            return _dataContext.carList.FirstOrDefault(f => f.Id == id);
        }

        public void AddCar(Car newCar)
        {
            // מוסיפה רכב חדש לרשימת הרכבים
            _dataContext.carList.Add(newCar);
            _dataContext.SaveChanges();
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
            _dataContext.SaveChanges();
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
            _dataContext.SaveChanges();
        }
    }


}
