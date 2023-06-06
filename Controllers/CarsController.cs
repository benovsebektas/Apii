using AutoMapper;
using FirstApiProject.DAL.EFCore;
using FirstApiProject.Entities;
using FirstApiProject.Entities.Dtos.Brands;
using FirstApiProject.Entities.Dtos.Cars;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace FirstApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public CarsController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCarDto>>> GetCars()
        {
            if (_context.cars == null)
            {
                return NotFound();
            }
            var result = await _context.cars.ToListAsync();
            List<GetCarDto> getCarDtos = _mapper.Map<List<GetCarDto>>(result);

            return getCarDtos;
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetCarDto>> GetCar(int id)
        {
            if (_context.cars == null)
            {
                return NotFound();
            }
            var car = await _context.cars.FindAsync(id);

            if (car == null)
            {
                return NotFound();
            }
            GetCarDto result = _mapper.Map<GetCarDto>(car);
            return result;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCar(int id, UpdateCarDto cardto)
        {
            if (!CarExists(id))
            {
                return NotFound();
            }
            Car car = _mapper.Map<Car>(cardto);
            car.Description = "hbdsbshb";
            _context.cars.Update(car);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostCar([FromBody] CreateCarDto cardto)
        {
            Car car = _mapper.Map<Car>(cardto);
            car.Description = car.Description.Substring(0, 2);
            await _context.cars.AddAsync(car);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            if (_context.cars == null)
            {
                return NotFound();
            }
            var car = await _context.cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            _context.cars.Remove(car);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarExists(int id)
        {
            return (_context.cars?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

