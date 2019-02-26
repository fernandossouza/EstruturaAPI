using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstruturaAPI.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EstruturaAPI.Controllers
{
    [Route("api/[controller]")]
    public class EstruturaController : Controller
    {
        private readonly IEstruturaService _EstruturaService;
        public EstruturaController(IEstruturaService estruturaService)
        {
            _EstruturaService = estruturaService;
        }

        // GET api/localizacao/container/1
        [HttpGet("Container/{rfid}")]
        public async Task<IActionResult> GetLocalizacaoContainer(string rfid)
        {
            try
            {
                var container = await _EstruturaService.GetContainer(rfid);
                
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

        // GET api/localizacao/bandeja/1
        [HttpGet("Bandeja/{rfid}")]
        public async Task<IActionResult> GetLocalizacaoBandeja(string rfid)
        {
            try
            {
                var bandeja = await _EstruturaService.GetBandeja(rfid);
                
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

        // GET api/localizacao/bandeja/1
        [HttpGet("Bandeja/")]
        public async Task<IActionResult> GetLocalizacaoBandeja([FromQuery] long containerId)
        {
            try
            {
                var bandeja = await _EstruturaService.GetBandejaListPorContainer(containerId);
                
                if(bandeja != null && bandeja.Count() >0)
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