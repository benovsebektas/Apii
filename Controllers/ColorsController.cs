using FirstApiProject.DAL.EFCore;
using FirstApiProject.Entities.Dtos.Brands;
using FirstApiProject.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using FirstApiProject.Entities.Dtos.Colors;
using AutoMapper;

namespace FirstApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public ColorsController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetColorDto>>> GetColors()
        {
            if (_context.colors == null)
            {
                return NotFound();
            }
            var result = await _context.colors.ToListAsync();
            List<GetColorDto> getColorDtos = _mapper.Map<List<GetColorDto>>(result);

            return getColorDtos;
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetColorDto>> GetColor(int id)
        {
            if (_context.colors == null)
            {
                return NotFound();
            }
            var color = await _context.colors.FindAsync(id);

            if (color == null)
            {
                return NotFound();
            }
            GetColorDto result = _mapper.Map<GetColorDto>(color);
            return result;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutColor(int id, UpdateColorDto colordto)
        {
            if (!ColorExists(id))
            {
                return NotFound();
            }
            Color color = _mapper.Map<Color>(colordto);
            color.Name = "TEst";
            _context.colors.Update(color);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostColor([FromBody] CreateColorDto colordto)
        {
            Color color = _mapper.Map<Color>(colordto);
            color.Name = color.Name.Substring(0, 2);
            await _context.colors.AddAsync(color);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteColor(int id)
        {
            if (_context.colors == null)
            {
                return NotFound();
            }
            var color = await _context.colors.FindAsync(id);
            if (color == null)
            {
                return NotFound();
            }

            _context.colors.Remove(color);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ColorExists(int id)
        {
            return (_context.colors?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}