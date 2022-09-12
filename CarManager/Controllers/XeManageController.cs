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
                                    Id = xe.Id,
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
                bvdto.Id = item.Id;
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
        [HttpPost]
        public async Task<ActionResult<List<Xe>>> CreateSinhVien(Xe xe)
        {
            _context.tb_Xe.Add(xe);
            await _context.SaveChangesAsync();

            return Ok(xe);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Xe>>> DeleteXe(int id)
        {
            var dbXe = await _context.tb_Xe.FirstOrDefaultAsync(sh => sh.Id == id);
            if (dbXe == null)
                return NotFound("Sorry, but no student for you. :/");

            _context.tb_Xe.Remove(dbXe);
            await _context.SaveChangesAsync();

            return Ok(dbXe);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Xe>>> GetXeId(int id)
        {
            var xe = await _context.tb_Xe.FirstOrDefaultAsync(sh => sh.Id == id);
            if(xe == null)
            {
                return NotFound("no bus here");
            }
            return Ok(xe);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Xe>>> UpdateXe(Xe xe, int id)
        {
            var dbXe = await _context.tb_Xe
                .FirstOrDefaultAsync(sh => sh.Id == id);
            if (dbXe == null)
                return NotFound("Sorry, but no hero for you. :/");
            dbXe.XeId = xe.XeId;
            dbXe.TenXe = xe.TenXe;
            dbXe.BienSo = xe.BienSo;
            dbXe.TaiTrong = xe.TaiTrong;
            dbXe.TuyenDuongId = xe.TuyenDuongId;
            await _context.SaveChangesAsync();

            return Ok(xe);
        }
    }
}
