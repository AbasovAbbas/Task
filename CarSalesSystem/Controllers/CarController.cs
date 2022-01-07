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
            var car = _repo.GetCarById(id);
            if (car != null)
            {
                return Ok(_mapper.Map<Car>(car));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<CarReadDto> CreateCar(CarCreateDto carCreateDto)
        {
            var car = _mapper.Map<Car>(carCreateDto);
            _repo.InsertCar(car);
            _repo.SaveChanges();
            var platformReadDto = _mapper.Map<CarReadDto>(car);
            return CreatedAtRoute(nameof(GetCarById), new { platformReadDto.Id }, platformReadDto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCar(int id, CarUpdateDto carUpdateDto)
        {
            try
            {
                if (carUpdateDto == null)
                {
                    return BadRequest();
                }

                var car = _repo.GetCarById(id);
                if (car == null)
                {
                    return NotFound();
                }

                _mapper.Map(carUpdateDto, car);
                _repo.UpdateCar(car);
                _repo.SaveChanges();

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCar(int id)
        {
            try
            {
                var car = _repo.GetCarById(id);
                if(car == null)
                {
                    return NotFound();
                }

                _repo.RemoveCar(car);
                _repo.SaveChanges();
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
            
        }
    }
}
