using Kitaplar.Client.Services;
using Kitaplar.Shared.Model;
using Microsoft.AspNetCore.Components;
using System.ComponentModel;

namespace Kitaplar.Client.Pages
{
    public partial class Kitaplar1
    {
        [Inject] public IKitapService KitapService { get; set; } = default!;

        List<Kitap> _Kitapler = [];
        Kitap? kitap { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await Fill();
        }

        async Task Fill()
        {
            var k = (await KitapService.Kitaplar()).ToList();
            _Kitapler = k;
        }

        async Task Sil(Kitap kitap)
        {
            try
            {
                await KitapService.Sil(kitap.ID);
                await Fill();
            }
            catch (Exception ex)
            {

            }
        }

        async Task OnSave()
        {
            if (kitap!.ID == 0)
                await KitapSrv.Ekleme(kitap);
            else
                await KitapSrv.Update(kitap!);
            kitap = null;
            await Fill();
        }
        void Ekle()
        {
            kitap = new Kitap();
        }

        void Update(Kitap kitap)
        {
            this.kitap = kitap;
        }

        void Close() => kitap = null;
    }
}
