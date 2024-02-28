using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitaplar.Shared.Model;

public class Yazar
{
    public int ID { get; set; }
    public string Adi { get; set; } = default!;
    public string Soyadi { get; set; } = default!;
    public int? DogumYili { get; set; }

    public List<Kitap> Kitaplar { get; set; } = [];
}
