using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstruturaAPI.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EstruturaAPI.Controllers
{
    [Route("api/[controller]")]
    public class LocalizacaoController : Controller
    {
        private readonly ILocalizacaoService _LocalizacaoService;

        public LocalizacaoController(ILocalizacaoService localizacaoService)
        {
            _LocalizacaoService = localizacaoService;
        }

        // GET api/localizacao/containers
        [HttpGet("Containers/")]
        public async Task<IActionResult> GetLocalizacaoContainer()
        {
            try
            {
                var containerList = await _LocalizacaoService.GetContainer();
                
                if(containerList.Count()>0)
                    return Ok(containerList);
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