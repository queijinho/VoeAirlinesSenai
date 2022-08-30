using Microsoft.AspNetCore.Mvc;
using VoeAirlinesSenai.ViewModel;
using VoeAirlinesSenai.Services;

    [Route("api/aeronaves")]
    [ApiController]
    public class AeronaveController : ControllerBase
    {
        private readonly AeronaveService _AeronaveService;
        public AeronaveController(AeronaveService aeronaveService){
            _AeronaveService = aeronaveService;
        }
        [HttpPost]
        public IActionResult AdicionarAeronave(AdicionarAeronaveViewModel dados){
            var aeronave = _AeronaveService.AdicionarAeronave(dados);
            return Ok(aeronave);
        }
        [HttpGet]
        public IActionResult ListarAeronaves(){
            return Ok(_AeronaveService.ListarAeronaves());
        }
        [HttpGet("(id)")]
        public IActionResult ListarAeronavePeloId(int id){
            var aeronave = _AeronaveService.ListarAeronavePeloId(id);
            if(aeronave != null){
                return Ok(aeronave);
            }else{
                return NotFound();
            }
        }
        
        [HttpPut ("(id)")]
        public IActionResult AtualizarAeronave(int id , AtualizarAeronaveViewModel dados){
            var aeronave = _AeronaveService.AtualizarAeronave(dados);
            if(id != dados.Id){
                return BadRequest("O id informado na URL é diferente do id");
            }else{
                return Ok(aeronave);
            }
        }

        [HttpDelete("(id)")]
        public IActionResult ExcluirAeronave(int id){
            _AeronaveService.ExcluirAeronave(id);
            return NoContent();
        }

}
