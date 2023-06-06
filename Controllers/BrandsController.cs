using FirstApiProject.DAL.EFCore;
using FirstApiProject.Entities.Dtos.Cars;
using FirstApiProject.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using FirstApiProject.Entities.Dtos.Brands;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using AutoMapper;

namespace FirstApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public BrandsController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetBrandDto>>> GetBrands()
        {
            if (_context.brands == null)
            {
                return NotFound();
            }
            var result = await _context.brands.ToListAsync();
            List<GetBrandDto> getBrandDtos = _mapper.Map<List<GetBrandDto>>(result);

            return getBrandDtos;
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetBrandDto>> GetBrand(int id)
        {
            if (_context.brands == null)
            {
                return NotFound();
            }
            var brand = await _context.brands.FindAsync(id);

            if (brand == null)
            {
                return NotFound();
            }
            GetBrandDto result = _mapper.Map<GetBrandDto>(brand);
            return result;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBrand(int id, UpdateBrandDto branddto)
        {
            if (!BrandExists(id))
            {
                return NotFound();
            }
            Brand brand = _mapper.Map<Brand>(branddto);
            brand.Name = "TEst";
            _context.brands.Update(brand);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostBrand([FromBody] CreateBrandDto branddto)
        {
            Brand brand = _mapper.Map<Brand>(branddto);
           brand.Name = brand.Name.Substring(0, 2);
            await _context.brands.AddAsync(brand);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            if (_context.brands == null)
            {
                return NotFound();
            }
            var brand = await _context.brands.FindAsync(id);
            if (brand == null)
            {
                return NotFound();
            }

            _context.brands.Remove(brand);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BrandExists(int id)
        {
            return (_context.brands?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
