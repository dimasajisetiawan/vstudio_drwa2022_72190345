using Microsoft.AspNetCore.Mvc;
using Uts_Drwa.Models;

namespace Uts_Drwa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuruController : ControllerBase
    {
        private GuruContext _context;

        public GuruController(GuruContext context)
        {
            this._context = context;
        }

        // GET: api/kelas
        [HttpGet]
        public ActionResult<IEnumerable<GuruItem>> GetGuruItem()
        {
            _context = HttpContext.RequestServices.GetService(typeof(GuruContext)) as GuruContext;
            return _context.GetAllGuru();
        }

        //Get : api/kelas/{id}
        [HttpGet("{nip}", Name = "Get")]
        public ActionResult<IEnumerable<GuruItem>> GetGuruItem(String nip)
        {
            _context = HttpContext.RequestServices.GetService(typeof(GuruContext)) as GuruContext;
            return _context.GetGuru(nip);
        }

        [HttpPost]
        public ActionResult<GuruItem> AddGuru(
            [FromForm] string rfid, [FromForm] string nip, [FromForm] string nama, [FromForm] string alamat, [FromForm] int status)
        {
            GuruItem gi = new GuruItem();
            gi.rfid = rfid;
            gi.nip = nip;
            gi.nama = nama;
            gi.alamat = alamat;
            gi.status = status;

            _context = HttpContext.RequestServices.GetService(typeof(GuruContext)) as GuruContext;
            return _context.AddGuru(gi);

        }
    }
}
