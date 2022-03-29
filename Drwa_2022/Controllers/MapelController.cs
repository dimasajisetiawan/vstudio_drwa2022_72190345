using Drwa_2022.Models;
using Microsoft.AspNetCore.Mvc;

namespace Uts_Drwa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MapelController : ControllerBase
    {
        private MapelContext _context;

        public MapelController(MapelContext context)
        {
            this._context = context;
        }

        // GET: api/kelas
        [HttpGet]
        public ActionResult<IEnumerable<MapelItem>> GetMapelItem()
        {
            _context = HttpContext.RequestServices.GetService(typeof(MapelContext)) as MapelContext;
            return _context.GetAllMapel();
        }

        //Get : api/kelas/{id}
        [HttpGet("{id}", Name = "Get Mapel by ID")]
        public ActionResult<IEnumerable<MapelItem>> GetMapelItem(String id)
        {
            _context = HttpContext.RequestServices.GetService(typeof(MapelContext)) as MapelContext;
            return _context.GetMapel(id);
        }

        [HttpPost]
        public ActionResult<MapelItem> AddMapel(
            [FromForm] string nama, [FromForm] string deskripsi)
        {
            MapelItem mi = new MapelItem();
            mi.nama = nama;
            mi.deskripsi = deskripsi;
            

            _context = HttpContext.RequestServices.GetService(typeof(MapelContext)) as MapelContext;
            return _context.AddMapel(mi);

        }
    }
}
