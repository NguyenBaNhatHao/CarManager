using CarManager.Models;
using CarManager.Data;
using CarManager.Dtos;

namespace CarManager.Services.XeService
{
    public interface IXeService
    {
        List<Xe> Xeservices { get; set; }

        Task GetXeDetail();
        Task CreateXe(Xe xe);
        Task UpdateXe(Xe xe);
        Task<Xe> GetSingleXe(int id);
        Task DeleteXe(int id);
    }
}
