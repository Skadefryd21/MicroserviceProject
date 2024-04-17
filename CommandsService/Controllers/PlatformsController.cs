using Microsoft.AspNetCore.Mvc;

namespace CommandsService.Controllers
{
    [ApiController, Route("api/cmds/[controller]")]
    public class PlatformsController : ControllerBase
    {
        public PlatformsController()
        {
            
        }

        [HttpPost]   
        public ActionResult TestInboundConnection()
        {
            Console.WriteLine("--> Inbound POST # Command Service");

            return Ok("Return of POST # Command Service");
        }
    }
}