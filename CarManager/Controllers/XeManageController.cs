using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarManager.Data;
using CarManager.Models;
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
        public async Task<ActionResult<List<Xe>>> GetXeDetail()
        {

            var resutl = await _context.tb_xe.ToListAsync();
            return Ok(resutl);
        }
    }
}
