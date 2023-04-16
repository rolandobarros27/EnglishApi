using infraestructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Services;

namespace EnglishApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectController : Controller
    {
        private string ConnectionString = "Server=localhost;Port=5432;Database=postgres;User Id=postgres;Password=1234;";
        private SubjectService subjectService;

        public SubjectController()
        {
            this.subjectService = new SubjectService(ConnectionString);
        }

        [HttpGet("ListarPersona")]
        public ActionResult<List<SubjectModel>> read()
        {
            var resultado = subjectService.read();
            return Ok(resultado);
        }

        [HttpGet("ConsultarPersona/{id}")]
        public ActionResult<SubjectModel> getById(int id, string documento)
        {
            return Ok(null);
        }

        [HttpPost("InsertarPersona")]
        public ActionResult<string> insert(SubjectModel modelo)
        {
            return Ok("Ok");
        }
    }
}
