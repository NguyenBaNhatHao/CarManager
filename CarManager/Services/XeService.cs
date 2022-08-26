using Microsoft.AspNetCore.Components;
using CarManager.Models;
using CarManager.Data;
using CarManager.Dtos;

namespace CarManager.Services.XeService
{
    public class XeService : IXeService
    {
        public readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;
        public List<Xe> Xeservices { get; set; } = new List<Xe>();

        public XeService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
            _http.BaseAddress = new Uri(_navigationManager.BaseUri);
        }
        public async Task GetXeDetail()
        {
            var result = await _http.GetFromJsonAsync<List<Xe>>("api/XeManage");
            if (result != null)
            {
                Xeservices = result;
            }
        }
        public async Task CreateXe(Xe xe)
        {
            var result = await _http.PostAsJsonAsync("api/XeManage", xe);
            await SetXe(result);
        }
        private async Task SetXe(HttpResponseMessage result)
        {
            Console.WriteLine(result.StatusCode);
            _navigationManager.NavigateTo("CarManage");
        }
        public async Task UpdateXe(Xe xe)
        {
            var result = await _http.PutAsJsonAsync($"api/XeManage/{xe.Id}", xe);
            await SetXe(result);
        }
        public async Task<Xe> GetSingleXe(int id)
        {
            var result = await _http.GetFromJsonAsync<Xe>($"api/XeManage/{id}");
            if (result != null)
                return result;
            throw new Exception("Car not found!");
        }
        public async Task DeleteXe(int id)
        {
            var result = await _http.DeleteAsync($"api/XeManage/{id}");
            await SetXe(result);
        }
    }
}
