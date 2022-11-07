using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PokemonAccedo.Api.RepositoriesHttp.UnitOfWork;
using PokemonAccedo.Api.Util.Attributes.Versions;
using PokemonAccedo.Dtos;
using PokemonAccedo.Dtos.Pokemon;
using PokemonAccedo.Models.Pokemons;

namespace PokemonAccedo.Api.Controllers.V1.Pokemons
{
    [ApiController]
    [Route("Api/Pokemon")]
    [HeaderRequestVersion("x-version", "1")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class PokemonController : Controller
    {
        private readonly UnitContext unitContext;

        public PokemonController(UnitContext unitContext)
        {
            this.unitContext = unitContext;
        }

        [HttpGet("SimpleList")]
        public async Task<ActionResult<ResponseDto<ListedPokemon>>> GetSimpleList()
        {
            var Data = await unitContext.GetList.GetList();
            if (Data == null)
                return new ResponseDto<ListedPokemon>()
                {
                    IsSuccess = false,
                    Message = "No se ha logrado conectar a la API",
                    Data = null
                };


            return new ResponseDto<ListedPokemon>()
            {
                IsSuccess = true,
                Message = "Se ha conectado correctamente a la API",
                Data = Data
            };
        }

        [HttpPost("Pokemon")]
        public async Task<ActionResult<ResponseDto<FullPokemon>>> GetPokemon([FromBody]RequestUrl Url)
        {
            var Data = await unitContext.GetPokemon.GetFirst(Url.Url);
            if(Data == null)
                if (Data == null)
                    return new ResponseDto<FullPokemon>()
                    {
                        IsSuccess = false,
                        Message = "No se ha logrado conectar a la API",
                        Data = null
                    };


            return new ResponseDto<FullPokemon>()
            {
                IsSuccess = true,
                Message = "Se ha conectado correctamente a la API",
                Data = Data
            };
        }
    }
}
