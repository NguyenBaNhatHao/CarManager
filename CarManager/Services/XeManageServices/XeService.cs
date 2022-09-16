﻿using Microsoft.AspNetCore.Components;
using CarManager.Models;
using CarManager.Data;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;
using CarManager.Dtos.BusDto;

namespace CarManager.Services.XeManageServices
{
    public class XeService : IXeService
    {
        public readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;
        public List<XeReadDTO> Xeservices { get; set; } = new List<XeReadDTO>();
        public XeService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
            _http.BaseAddress = new Uri(_navigationManager.BaseUri);
        }
        public async Task GetXeDetail()
        {
            var result = await _http.GetFromJsonAsync<List<XeReadDTO>>("api/xemanage");
            if (result != null)
            {
                Xeservices = result;
            }
        }
        private async Task SetXe(HttpResponseMessage result)
        {
            Console.WriteLine(result.StatusCode);
            _navigationManager.NavigateTo("CarManage");
        }

        public async Task CreateXe(Xe xe)
        {
            var resutl = await _http.PostAsJsonAsync("api/xemanage", xe);
            await SetXe(resutl);
        }

        public async Task DeleteXe(int id)
        {
            var result = await _http.DeleteAsync($"api/XeManage/{id}");
            await SetXe(result);
        }

        public async Task<Xe> GetIdXe(int id)
        {
            var resutl = await _http.GetFromJsonAsync<Xe>($"api/xemanage/{id}");
            if(resutl == null)
            {
                throw new Exception("not found bus");
            }
            return resutl;
        }

        public async Task UpdateXe(int? id, Xe xe)
        {
            var resutl = await _http.PutAsJsonAsync($"api/xemanage/{id}",xe);
            await SetXe(resutl);
        }
    }
}
