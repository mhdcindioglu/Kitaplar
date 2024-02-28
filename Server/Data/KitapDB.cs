using Kitaplar.Shared.Model;
using Microsoft.EntityFrameworkCore;

namespace Kitaplar.Server.Data;

public class KitapDB : DbContext
{
    public KitapDB(DbContextOptions<KitapDB> options) : base(options)
    {

    }

    public DbSet<Kitap> Kitaplar { get; set; }
    public DbSet<Yazar> Yazarlar { get; set; }
}
