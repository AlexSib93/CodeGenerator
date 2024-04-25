using BuisinessLogicLayer.Enum;
using BuisinessLogicLayer.Models;
using BuisinessLogicLayer.Services.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TerminalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarcodeController : ControllerBase
    {
        private readonly ITerminalService _terminalService;
        public BarcodeController(ITerminalService terminalService)
        {
            _terminalService = terminalService;
        }

        [HttpPost("scan")]
        public async Task<ActionResult<OrderItemViewModel>> Scan(string barcode)
        {
            OrderItemViewModel res = null;
            try
            {
                res =_terminalService.GetGpStorageInfo(barcode);
            }
            catch (Exception e)
            {
                BadRequest(e);
            }

            return Ok(res);
        }
    }
}
