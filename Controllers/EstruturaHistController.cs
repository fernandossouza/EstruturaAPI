using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstruturaAPI.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EstruturaAPI.Controllers
{
    [Route("api/[controller]")]
    public class EstruturaHistController : Controller
    {
        private readonly IEstruturaHistService _EstruturaHistService;
        
        public EstruturaHistController(IEstruturaHistService estruturaHistService)
        {
            _EstruturaHistService = estruturaHistService;
        }

        // GET api/estruturaHist/container/121Container
        [HttpGet("Container/{rfid}")]
        public async Task<IActionResult> GetEstruturaContainer(string rfid)
        {
            try
            {
                var container = await _EstruturaHistService.GetContainer(rfid);
                
                if(container != null)
                    return Ok(container);
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/estruturaHist/bandeja/12Bandeja
        [HttpGet("Bandeja/{rfid}")]
        public async Task<IActionResult> GetEstruturaBandeja(string rfid)
        {
            try
            {
                var bandeja = await _EstruturaHistService.GetBandeja(rfid);
                
                if(bandeja != null)
                    return Ok(bandeja);
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}