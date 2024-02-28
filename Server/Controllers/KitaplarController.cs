using Kitaplar.Client.Pages;
using Kitaplar.Shared.Model;
using Microsoft.AspNetCore.Mvc;

namespace Kitaplar.Server.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class KitaplarController : ControllerBase
    {
        static List<Kitap> _Kitaplar = [];

        public KitaplarController()
        {
            _Kitaplar = [
                new Kitap { ID = 1, Tanimi = "Kitap1", Sinif = Sinif.sinif1, YazarID = 1, CikisYili = 1995, SahifaAdedi = 521, Konu = "Konu1", },
                new Kitap { ID = 2, Tanimi = "Kitap2", Sinif = Sinif.sinif1, YazarID = 2, CikisYili = 1998, SahifaAdedi = 252, Konu = "Konu2", },
                new Kitap { ID = 3, Tanimi = "Kitap3", Sinif = Sinif.sinif1, YazarID = 2, CikisYili = 2003, SahifaAdedi = 326, Konu = "Konu3", },
                new Kitap { ID = 4, Tanimi = "Kitap4", Sinif = Sinif.sinif1, YazarID = 1, CikisYili = 2021, SahifaAdedi = 125, Konu = "Konu4", },
                new Kitap { ID = 5, Tanimi = "Kitap5", Sinif = Sinif.sinif1, YazarID = 2, CikisYili = 2025, SahifaAdedi = 401, Konu = "Konu5", },
                new Kitap { ID = 6, Tanimi = "Kitap6", Sinif = Sinif.sinif1, YazarID = 3, CikisYili = 1985, SahifaAdedi = 201, Konu = "Konu6", },
            ];
        }

        [HttpGet("All")]
        public async Task<List<Kitap>> Kitaplar()
        {
            var result = await Task.FromResult(_Kitaplar);
            return result;
        }

        [HttpGet("Search/{search}")]
        public async Task<Kitap[]> Kitaplar(string search)
        {
            var result = await Task.FromResult(_Kitaplar.Where(x => x.Tanimi.Contains(search)).ToArray());
            return result;
        }

        [HttpGet("KitaplarByYazarID")]
        public async Task<Kitap[]> KitaplarByYazarID(int id)
        {
            var result = await Task.FromResult(_Kitaplar.Where(kitap => kitap.YazarID == id).ToArray());
            return result;
        }

        [HttpPost]
        public async Task<ActionResult> Ekleme(Kitap kitap)
        {
            _Kitaplar.Add(kitap);
            return Ok();
        }
        [HttpPut]
        public async Task<ActionResult> Update(Kitap kitap)
        {
            var kitapInDb = _Kitaplar.FirstOrDefault(x=>x.ID == kitap.ID);
            if (kitapInDb != null)
                kitapInDb = kitap;
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Sil(int id)
        {
            var kitapInDb = await Task.FromResult(_Kitaplar.FirstOrDefault(x => x.ID == id));
            if (kitapInDb == null)
                return NotFound();

            _Kitaplar.Remove(kitapInDb);
            return Ok();
        }
    }
}
