using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitaplar.Shared.Model;

public class Kitap
{
    public int ID { get; set; }

    public string Tanimi { get; set; } = default!;

    public Sinif Sinif { get; set; }

    public int YazarID { get; set; }
    public Yazar? Yazar { get; set; }

    public int? CikisYili { get; set; }

    public int SahifaAdedi { get; set; }

    public string? Konu { get; set; }
    public DateTime Tarih { get; set; } = DateTime.Now;

}

public enum Sinif { sinif1 = 0, sinif2 = 1, sinif3 = 2, }
