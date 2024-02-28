using Kitaplar.Client.Pages;
using Kitaplar.Server.Data;
using Kitaplar.Shared.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kitaplar.Server.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class KitaplarController(KitapDB db) : ControllerBase
    {
        [HttpGet("All")]
        public async Task<List<Kitap>> Kitaplar()
        {
            var result = await db.Kitaplar.ToListAsync();
            return result;
        }

        [HttpGet("Kitap/{id}")]
        public async Task<Kitap?> Kitap(int id)
        {
            var result = await db.Kitaplar.FirstOrDefaultAsync(x => x.ID == id);
            return result;
        }

        [HttpGet("Search/{search}")]
        public async Task<Kitap[]> Kitaplar(string search)
        {
            var result = await db.Kitaplar.Where(x => x.Tanimi.Contains(search)).ToArrayAsync();
            return result;
        }

        [HttpGet("KitaplarByYazarID")]
        public async Task<Kitap[]> KitaplarByYazarID(int id)
        {
            var result = await db.Kitaplar.Where(kitap => kitap.YazarID == id).ToArrayAsync();
            return result;
        }

        [HttpPost]
        public async Task<ActionResult> Ekleme(Kitap kitap)
        {
            try
            {
                await db.Kitaplar.AddAsync(kitap);
                await db.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpPut]
        public async Task<ActionResult> Update(Kitap kitap)
        {
            var kitapInDb = await db.Kitaplar.FirstOrDefaultAsync(x => x.ID == kitap.ID);
            if (kitapInDb == null)
                return NotFound();

            kitapInDb.Tanimi = kitap.Tanimi;
            kitapInDb.YazarID = kitap.YazarID;
            kitapInDb.CikisYili = kitap.CikisYili;
            kitapInDb.Tarih = kitap.Tarih;
            kitapInDb.Konu = kitap.Konu;
            kitapInDb.SahifaAdedi = kitap.SahifaAdedi;
            kitapInDb.Sinif = kitap.Sinif;

            db.Kitaplar.Update(kitapInDb);
            await db.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Sil(int id)
        {
            var kitapInDb = await db.Kitaplar.FirstOrDefaultAsync(x => x.ID == id);
            if (kitapInDb == null)
                return NotFound();

            db.Kitaplar.Remove(kitapInDb);
            await db.SaveChangesAsync();
            return Ok();
        }
    }
}
