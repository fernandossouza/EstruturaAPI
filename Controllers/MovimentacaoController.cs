using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstruturaAPI.Models;
using EstruturaAPI.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EstruturaAPI.Controllers
{
    [Route("api/[controller]")]
    public class MovimentacaoController : Controller
    {
        private readonly IMovimentacaoService _MovimentacaoService;
        public MovimentacaoController(IMovimentacaoService movimentacaoService)
        {
            _MovimentacaoService = movimentacaoService;
        }

         // GET api/movimentacao
        [HttpGet()]
        public async Task<IActionResult> GetMovimentacao()
        {
            try
            {
                var movimentacaoList = await _MovimentacaoService.GetMovimentacao();
                
                if(movimentacaoList != null && movimentacaoList.Count()>0)
                    return Ok(movimentacaoList);
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/movimentacao
        [HttpPost()]
        public async Task<IActionResult> PostMovimentacao([FromBody]TbMovimentacaoCadastro movimentacao)
        {
            try
            {
                if (ModelState.IsValid)
                {
                var movimentacaoDb = await _MovimentacaoService.PostMovimentacao(movimentacao);
                
                if(movimentacaoDb != null)
                    return Ok(movimentacaoDb);
                 else
                    return StatusCode(500, "Não foi possivel salvar as informações no banco de dados");
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}