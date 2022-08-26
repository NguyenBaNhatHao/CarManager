using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarManager.Data;
using CarManager.Models;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using CarManager.Dtos;

namespace QuanLySVTT.Controllers
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
        public async Task<ActionResult<List<Xe>>> GetXeDetail()
        {

            List<XeDTO> xeDTOs = new List<XeDTO>();
            var result = await (from xe in _context.tb_xe
                                join TuyenDuong in _context.TuyenDuong on xe.TuyenDuongId equals TuyenDuong.TuyenDuongId
                                select new
                                {
                                    Id = xe.Id,
                                    XeId = xe.XeId,
                                    tenxe = xe.TenXe,
                                    bienso = xe.BienSo,
                                    taitrong = xe.TaiTrong,
                                    tuyenduongId = xe.TuyenDuongId,
                                    tuyenduong = xe.TuyenDuong
                                }
                          ).ToListAsync();
            foreach (var item in result)
            {
                XeDTO xedto = new XeDTO();
                xedto.Id = item.Id;
                xedto.XeId = item.XeId;
                xedto.TenXe = item.tenxe;
                xedto.TuyenDuong = item.tuyenduong;
                xedto.TuyenDuongId = item.tuyenduongId;
                xedto.BienSo = item.bienso;
                xedto.TaiTrong = item.taitrong;
                xeDTOs.Add(xedto);
            }
            if (xeDTOs != null)
                return Ok(xeDTOs);
            else
                return NotFound();
        }
        [HttpPost("create")]
        public ActionResult<XeDTO> CreateXe(Xe xe)
        {
            _context.tb_xe.Add(xe);
            _context.SaveChanges();
            return Ok(xe);
        }
    }
}
