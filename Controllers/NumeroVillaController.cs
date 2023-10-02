using AutoMapper;
using Magic_Villa_7.Datos;
using Magic_Villa_7.Modelos;
using Magic_Villa_7.Modelos.VillaDTO;
using Magic_Villa_7.Repositorio.IRepositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Net;

namespace Magic_Villa_7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NumeroVillaController : ControllerBase
    {
        private readonly ILogger<NumeroVillaController> _logger;
        private readonly IVillaRepositorio _villaRepo;
        private readonly INumeroVillaRepositorio _numeroRepo;
        private readonly IMapper _mapper;
        protected ApiResponse _response;

        public NumeroVillaController(ILogger<NumeroVillaController> logger, IVillaRepositorio villarepo, INumeroVillaRepositorio numeroRepo, IMapper mapper)
        {
            _logger = logger;
            _villaRepo = villarepo;
            _numeroRepo = numeroRepo;
            _mapper = mapper;
            _response = new();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task <ActionResult<ApiResponse>> GetNumeroVillas()
        {
            try
            {


                _logger.LogInformation("Obtener Numero villas");

                IEnumerable<NumeroVilla> numeroVillaList = await _numeroRepo.ObtenerTodos();

                _response.Resultado = _mapper.Map<IEnumerable<NumeroVillaDto>>(numeroVillaList);
                _response.statusCode = HttpStatusCode.OK;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
            //new VillaDTO{ID=1, Nombre="Visita a la Piscina"},
            //new VillaDTO{ID=2, Nombre="Visita a la Playa"}

        }

        [HttpGet("id:int", Name = "GetNumeroVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse>> GetVilla(int id)
        {
            try
            {

                if (id == 0)
                {
                    _logger.LogError("Error al traer el numero de villa con el ID " + id);
                    _response.statusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var numerovilla = await _numeroRepo.Obtener(v => v.Villa_No == id);

                if (numerovilla == null)
                {
                    _response.Resultado = _mapper.Map<NumeroVillaDto>(numerovilla);
                    _response.statusCode = HttpStatusCode.OK;

                    return Ok(_response);
                }
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return Ok(_response);
        }

            
            

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task <ActionResult<ApiResponse>> CrearNumeroVilla([FromBody] NumeroVillaCreateDto createDTO)
        {

            try
            {


                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (await _numeroRepo.Obtener(v => v.Villa_No == createDTO.Villa_No) != null)
                {
                    ModelState.AddModelError("Ya existe ese nombre", "Eres un insecto");
                    return BadRequest(ModelState);
                }

                if(await _villaRepo.Obtener(v => v.ID == createDTO.Villa_Id) != null)
                {
                    ModelState.AddModelError("ClaveForanea", "El Id de la villa no existe! ");
                    return BadRequest(ModelState);
                }

                if (createDTO == null)
                {
                    return BadRequest(createDTO);
                }



                NumeroVilla modelo = _mapper.Map<NumeroVilla>(createDTO);



                await _numeroRepo.Crear(modelo);
                _response.Resultado = modelo;
                _response.statusCode = HttpStatusCode.Created;

               

                return CreatedAtRoute("GetVilla", new { ID = modelo.Villa_No }, _response);
            }
            catch(Exception ex) 
            {
                _response.IsExitoso = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task <IActionResult> DeleteNumeroVilla(int id)
        {
            try
            {


                if (id == 0)
                {
                    _response.IsExitoso = false;
                    _response.statusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var numerovilla = await _numeroRepo.Obtener(v => v.Villa_No == id);
                if (numerovilla == null)
                {
                    _response.IsExitoso = false;
                    _response.statusCode = HttpStatusCode.NotFound;
                    return NotFound();
                }
                await _numeroRepo.Remover(numerovilla);

                _response.statusCode = HttpStatusCode.NoContent;
                return Ok(_response);


                
            }
            catch (Exception ex)
            {
                _response.IsExitoso=false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return BadRequest(_response);
        }


        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task <ActionResult> UpdateNumeroVilla(int id, [FromBody] NumeroVillaUpdateDto UpdateDTO)
        {
            if(UpdateDTO == null || id!= UpdateDTO.Villa_No)
            {

                _response.IsExitoso = false;
                _response.statusCode = HttpStatusCode.BadRequest;
                return BadRequest(_response);
            }

            NumeroVilla modelo = _mapper.Map<NumeroVilla>(UpdateDTO);

            await _numeroRepo.Actualizar(modelo);
            _response.statusCode = HttpStatusCode.NoContent;



            return Ok(_response);
            
        }

        
    }
}
