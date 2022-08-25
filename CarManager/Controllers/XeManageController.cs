using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarManager.Data;
using CarManager.Models;
using CarManager.Dtos.BusDto;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
namespace CarManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class XeManageController : ControllerBase
    {
        private readonly CarManageDbContext _context;
        public XeManageController(CarManageDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<XeDTO>>> GetXeDetail()
        {
            List<XeDTO> BvDTOs = new List<XeDTO>();
            var result = await (from xe in _context.tb_Xe
                                join tuyenduong in _context.tb_Tuyenduong on xe.TuyenDuongId equals tuyenduong.TuyenDuongId
                                select new
                                {
                                    XeId = xe.XeId,
                                    TenXe = xe.TenXe,
                                    Bienso = xe.BienSo,
                                    Taitrong = xe.TaiTrong,
                                    TuyenduongId = xe.TuyenDuongId,
                                    TuyenDuong = xe.TuyenDuong
                                }
                          ).ToListAsync();
            foreach (var item in result)
            {
                XeDTO bvdto = new XeDTO();
                bvdto.XeId = item.XeId;
                bvdto.TenXe = item.TenXe;
                bvdto.BienSo = item.Bienso;
                bvdto.TaiTrong = item.Taitrong;
                bvdto.TuyenDuongId = item.TuyenduongId;
                bvdto.tuyenDuong = item.TuyenDuong;
                
                BvDTOs.Add(bvdto);
            }
            if (BvDTOs != null)
                return Ok(BvDTOs);
            else
                return NotFound();
        }
    }
}
