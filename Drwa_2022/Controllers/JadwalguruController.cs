using Drwa_2022.Models;
using Microsoft.AspNetCore.Mvc;

namespace Drwa_2022.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JadwalguruController : ControllerBase
    {
        private JadwalContext _context;

        public JadwalguruController(JadwalContext context)
        {
            this._context = context;
        }

        // GET: api/kelas
        [HttpGet]
        public ActionResult<IEnumerable<JadwalItem>> GetJadwalItem()
        {
            _context = HttpContext.RequestServices.GetService(typeof(JadwalContext)) as JadwalContext;
            return _context.GetAllJadwal();
        }

        [HttpGet("{id}", Name = "Get Jadwal by NIP")]
        public ActionResult<IEnumerable<JadwalItem>> GetJadwalItemByNip(string id)
        {
            _context = HttpContext.RequestServices.GetService(typeof(JadwalContext)) as JadwalContext;
            return _context.GetJadwalByNip(id);
        }

        /*[HttpOptions("{id}", Name = "Get Jadwal by ID Matkul")]
        public ActionResult<IEnumerable<JadwalItem>> GetJadwalItemByMatkul(String id)
        {
            _context = HttpContext.RequestServices.GetService(typeof(JadwalContext)) as JadwalContext;
            return _context.GetJadwalByIDMapel(id);
        }*/

        [HttpPost]
        public ActionResult<JadwalItem> AddJadwal(
            [FromForm] string tahun, [FromForm] string semester, [FromForm] int id_guru,[FromForm] string hari, [FromForm] int id_kelas, [FromForm] int id_mapel, [FromForm] string jam_mulai, [FromForm] string jam_selesai )
        {
            JadwalItem mi = new JadwalItem();
            mi.tahun = tahun;
            mi.semester = semester;
            mi.id_guru = id_guru;   
            mi.hari = hari;
            mi.id_kelas = id_kelas;
            mi.id_mapel = id_mapel;
            mi.jam_mulai = jam_mulai;
            mi.jam_selesai = jam_selesai;   



            _context = HttpContext.RequestServices.GetService(typeof(JadwalContext)) as JadwalContext;
            return _context.AddJadwal(mi);

        }
    }
}
