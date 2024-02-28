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
        void Ekle() => NavMngr.NavigateTo("/Kitapler/Ekleme");
    }
}
