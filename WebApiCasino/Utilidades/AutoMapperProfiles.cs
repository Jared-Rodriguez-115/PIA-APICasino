using AutoMapper;
using WebApiCasino.DTOs;
using WebApiCasino.Entidades;

namespace WebApiCasino.Utilidades
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<RifaCreacionDTO, Rifa>();
            CreateMap<Rifa, RifaDTO>();

            CreateMap<ParticipanteCreacionDTO, Participante>()
                .ForMember(participante => participante.RifaParticipante, opciones => opciones.MapFrom(MapRifasParticipantes));
            CreateMap<Participante, ParticipanteDTO>();
            CreateMap<ParticipantePatchDTO, Participante>().ReverseMap();

            CreateMap<PremioCreacionDTO, Premios>();
            CreateMap<Premios, PremioDTO>();

            CreateMap<CartaCreacionDTO, Cartas>();
            CreateMap<Cartas, CartaDTO>();

            

        }

        private List<RifaParticipante> MapRifasParticipantes(ParticipanteCreacionDTO participanteCreacionDTO, Participante participante)
        {
            var resultado = new List<RifaParticipante>();
            if (participanteCreacionDTO.RifasIds == null) { return resultado; }
            foreach (var rifaId in participanteCreacionDTO.RifasIds)
            {
                resultado.Add(new RifaParticipante()
                {
                    RifaId = rifaId
                });
            }
            return resultado;
        }

        //private List<Rifa> MapRifasPremios(PremioCreacionDTO premioCreacionDTO, Premios premios)
        //{
        //    var resultado = new List<Rifa>();
        //    if (premioCreacionDTO.RifasId == null) { return resultado; }
        //    foreach (var rifaId in premioCreacionDTO.RifasId)
        //    {
        //        resultado.Add(new Rifa()
        //        {
                    
        //        });
        //    }
        //}

    }
}