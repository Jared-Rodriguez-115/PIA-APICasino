namespace WebApiCasino.DTOs
{
    public class PremioDTO
    {
        public int Id { get; set; }

        public string Contenido { get; set; }

        List<RifaDTO> Rifas { get; set; }

    }
}
