using CarManager.Models;
using CarManager.Data;
using CarManager.Dtos.BusDto;

namespace CarManager.Services.XeManageServices
{
    public interface IXeService
    {
        List<XeReadDTO> Xeservices { get; set; }
        List<GheDTO> Gheservices { get; set; }
        Task GetXeDetail();
        Task<Xe> GetIdXe(int id);
        Task UpdateXe(int? id, Xe xe);
        Task UpdateGhe(int? id, Xe xe);
        Task CreateXe(Xe xe);
        Task DeleteXe(int id);
        Task GetGheDetail();
    }
}
