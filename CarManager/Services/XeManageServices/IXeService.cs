using CarManager.Models;
using CarManager.Data;
namespace CarManager.Services.XeManageServices
{
    public interface IXeService
    {
        List<Xe> Xeservices { get; set; }
        Task GetXeDetail();
        Task CreateXe(Xe xe);
    }
}
