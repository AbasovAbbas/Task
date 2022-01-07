using CarSalesSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarSalesSystem.Data.Abstract
{
    public interface ICarRepository
    {
        bool SaveChanges();
        IEnumerable<Car> GetAllCars();
        Car GetCarById(int id);
        void InsertCar(Car car);
        void UpdateCar(Car car);
    }
}
