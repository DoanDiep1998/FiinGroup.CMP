using FiinGroup.CMP.API.CommandQueries;
using FiinGroup.Packages.Common.Controller;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CMPController : FgController
    {
        [HttpPost("GetCMPByProduct")]
        public async Task<IActionResult> GetCMPByProduct([FromBody] GetCMPByProductRequest request)
        {
            return Ok(await Mediator.Send(request));
        }
    }
}
