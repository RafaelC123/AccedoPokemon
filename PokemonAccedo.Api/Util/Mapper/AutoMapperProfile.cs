using AutoMapper;
using PokemonAccedo.Dtos.Account.Request;
using PokemonAccedo.Models.Account;

namespace PokemonAccedo.Api.Util.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserIdentity, RegisterRequestDto>();
            CreateMap<RegisterRequestDto, UserIdentity>();
        }
    }
}
