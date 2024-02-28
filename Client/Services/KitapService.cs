using Kitaplar.Shared.Model;
using System.Net.Http.Json;
using System.Text.Json;

namespace Kitaplar.Client.Services;

public class KitapService(HttpClient Client) : IKitapService
{

    public async Task<Kitap[]> Kitaplar()
    {
        try
        {
            var response = await Client.GetAsync("/api/kitaplar/All");
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Kitap[]>(content, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }) ?? [];
            return result;
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public async Task<Kitap?> Kitap(int id)
    {
        try
        {
            var response = await Client.GetAsync($"/api/kitaplar/Kitap/{id}");
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Kitap?>(content, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            return result;
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task Ekleme(Kitap kitap)
    {
        try
        {
            var response = await Client.PostAsJsonAsync("/api/kitaplar", kitap);
            if (!response.IsSuccessStatusCode)
                throw new Exception(response.StatusCode.ToString());
            var content = await response.Content.ReadAsStringAsync();
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public async Task Update(Kitap kitap)
    {
        try
        {
            var response = await Client.PutAsJsonAsync("/api/kitaplar", kitap);
            if (!response.IsSuccessStatusCode)
                throw new Exception(response.StatusCode.ToString());
            var content = await response.Content.ReadAsStringAsync();
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public async Task Sil(int id)
    {
        try
        {
            var response = await Client.DeleteAsync("/api/kitaplar/" + id);
            if (!response.IsSuccessStatusCode)
                throw new Exception(response.StatusCode.ToString());
            var content = await response.Content.ReadAsStringAsync();
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}

public interface IKitapService
{
    Task<Kitap[]> Kitaplar();
    Task<Kitap?> Kitap(int id);
    Task Ekleme(Kitap kitap);
    Task Update(Kitap kitap);
    Task Sil(int id);
}
