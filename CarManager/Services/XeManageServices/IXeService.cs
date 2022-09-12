using CarManager.Models;
using CarManager.Data;
namespace CarManager.Services.XeManageServices
{
    public interface IXeService
    {
        List<Xe> Xeservices { get; set; }
        Task GetXeDetail();
        Task<Xe> GetIdXe(int id);
        Task UpdateXe(int? id, Xe xe);
        Task CreateXe(Xe xe);
        Task DeleteXe(int id);
    }
}
