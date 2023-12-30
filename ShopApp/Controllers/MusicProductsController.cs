using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopApp.Models;

namespace ShopApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicProductsController : ControllerBase
    {
        private readonly ShopAppContext _context;

        public MusicProductsController(ShopAppContext context)
        {
            _context = context;
        }

        // GET: api/MusicProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MusicProduct>>> GetMusicProducts()
        {
          if (_context.MusicProducts == null)
          {
              return NotFound();
          }
            return await _context.MusicProducts.ToListAsync();
        }

        // GET: api/MusicProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MusicProduct>> GetMusicProduct(int id)
        {
          if (_context.MusicProducts == null)
          {
              return NotFound();
          }
            var musicProduct = await _context.MusicProducts.FindAsync(id);

            if (musicProduct == null)
            {
                return NotFound();
            }

            return musicProduct;
        }

        // PUT: api/MusicProducts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMusicProduct(int id, MusicProduct musicProduct)
        {
            if (id != musicProduct.AlbumId)
            {
                return BadRequest();
            }

            _context.Entry(musicProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MusicProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/MusicProducts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MusicProduct>> PostMusicProduct(MusicProduct musicProduct)
        {
          if (_context.MusicProducts == null)
          {
              return Problem("Entity set 'ShopAppContext.MusicProducts'  is null.");
          }
            _context.MusicProducts.Add(musicProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMusicProduct", new { id = musicProduct.AlbumId }, musicProduct);
        }

        // DELETE: api/MusicProducts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMusicProduct(int id)
        {
            if (_context.MusicProducts == null)
            {
                return NotFound();
            }
            var musicProduct = await _context.MusicProducts.FindAsync(id);
            if (musicProduct == null)
            {
                return NotFound();
            }

            _context.MusicProducts.Remove(musicProduct);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MusicProductExists(int id)
        {
            return (_context.MusicProducts?.Any(e => e.AlbumId == id)).GetValueOrDefault();
        }
    }
}
