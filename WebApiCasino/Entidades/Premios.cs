using System.ComponentModel.DataAnnotations;
using WebApiCasino.Validaciones;
using Microsoft.AspNetCore.Identity;

namespace WebApiCasino.Entidades
{
    public class Premios
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 50, ErrorMessage = "El campo {0} solo puede tener 50 caracteres maximo")]
        [PrimeraLetraMayuscula]
        public string Contenido { get; set; }

        public int RifaId { get; set; }

        public Rifa Rifa { get; set; }

        public string UsuarioId { get; set; }

        public IdentityUser Usuario { get; set; }
    }
}
