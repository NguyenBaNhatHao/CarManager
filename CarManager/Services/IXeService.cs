using CarManager.Models;
using CarManager.Data;
namespace CarManager.Services.XeService
{
    public interface IXeService
    {
        List<Xe> Xeservices { get; set; }

        Task GetXeDetail();
    }
}
