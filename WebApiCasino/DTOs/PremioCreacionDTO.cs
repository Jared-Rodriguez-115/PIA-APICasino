using System.ComponentModel.DataAnnotations;
using WebApiCasino.Entidades;
using WebApiCasino.Validaciones;

namespace WebApiCasino.DTOs
{
    public class PremioCreacionDTO
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 50, ErrorMessage = "El campo {0} solo puede tener 50 caracteres maximo")]
        [PrimeraLetraMayuscula]
        public string Contenido { get; set; }

        //public List<Rifa> RifasId { get; set; }
        //public List<int> RifasId { get; set; }  // es aqui o en rifacreacion despues vemos donde jala
    }
}
