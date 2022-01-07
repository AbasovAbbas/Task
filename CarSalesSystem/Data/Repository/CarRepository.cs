using CarSalesSystem.Data.Abstract;
using CarSalesSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarSalesSystem.Data.Repository
{
    public class CarRepository : ICarRepository
    {

        private CarSalesDbContext _context;
        public CarRepository(CarSalesDbContext context)
        {
            _context = context;
        }

        public void InsertCar(Car car)
        {
            if(car == null)
            {
                throw new ArgumentNullException();
            }
            _context.Add(car);
        }
        public IEnumerable<Car> GetAllCars()
        {
           return _context.Cars.ToList();
        }

        public Car GetCarById(int id)
        {
            return _context.Cars.FirstOrDefault(x => x.Id == id);
        }
        
        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }

        public void UpdateCar(Car car)
        {
            _context.Update(car);
        }
    }
}
