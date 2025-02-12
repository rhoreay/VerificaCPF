using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VerificaCPF.Model;

namespace VerificaCPF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CpfController : ControllerBase
    {
        [HttpGet]
        public Cpf VerificaCPF(string? CpfCompleto)
        {
            Cpf CpfVerifiacdo = new Cpf(CpfCompleto);
            return CpfVerifiacdo;
        }
    }
}
