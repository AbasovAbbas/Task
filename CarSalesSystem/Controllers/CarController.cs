using AutoMapper;
using CarSalesSystem.Data.Abstract;
using CarSalesSystem.Dtos;
using CarSalesSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarSalesSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarRepository _repo;
        private readonly IMapper _mapper;
        public CarController(ICarRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CarReadDto>> GetCars()
        {
            var items = _repo.GetAllCars();
            return Ok(_mapper.Map<IEnumerable<CarReadDto>>(items));
        }

        [HttpGet("{id}", Name = "GetCarById")]
        public ActionResult<CarReadDto> GetCarById(int id)
        {
            var item = _repo.GetCarById(id);
            if (item != null)
            {
                return Ok(_mapper.Map<Car>(item));
            }
            return NotFound();
        }
        [HttpPost]
        public ActionResult<CarReadDto> CreatePlatform(CarCreateDto carCreateDto)
        {
            var car = _mapper.Map<Car>(carCreateDto);
            _repo.CreateCar(car);
            _repo.SaveChanges();
            var platformReadDto = _mapper.Map<CarReadDto>(car);
            return CreatedAtRoute(nameof(GetCarById), new { platformReadDto.Id }, platformReadDto);
        }
    }
}
