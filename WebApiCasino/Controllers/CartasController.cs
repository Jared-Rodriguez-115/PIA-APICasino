using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCasino.DTOs;
using WebApiCasino.Entidades;
using WebApiCasino.Migrations;
using Cartas = WebApiCasino.Entidades.Cartas;

namespace WebApiCasino.Controllers
{
    [ApiController]
    [Route("api/cartas")]

    public class CartasController : ControllerBase
    {

        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly UserManager<IdentityUser> userManager;

        public CartasController(ApplicationDbContext context, IMapper mapper, UserManager<IdentityUser> userManager)
        {
            this.context = context;
            this.mapper = mapper;
            this.userManager = userManager;
        }





        //[HttpGet]
        //public ActionResult<List<Cartas>> Get()
        //{
        //    return new List<Cartas>()
        //    {
        //        new Cartas() {Id = 1, Nombre = "El gallo"},
        //        new Cartas() {Id = 1, Nombre = "El gallo"},
        //        new Cartas() {Id = 1, Nombre = "El gallo"},
        //        new Cartas() {Id = 1, Nombre = "El gallo"},
        //        new Cartas() {Id = 1, Nombre = "El gallo"},
        //        new Cartas() {Id = 1, Nombre = "El gallo"},
        //        new Cartas() {Id = 1, Nombre = "El gallo"},
        //        new Cartas() {Id = 1, Nombre = "El gallo"},
        //        new Cartas() {Id = 1, Nombre = "El gallo"},
        //        new Cartas() {Id = 1, Nombre = "El gallo"},
        //        new Cartas() {Id = 1, Nombre = "El gallo"},
        //        new Cartas() {Id = 1, Nombre = "El gallo"},
        //        new Cartas() {Id = 1, Nombre = "El gallo"},
        //    };
        //}

        //[HttpPost]
        //[AllowAnonymous]
        //public async Task<ActionResult> Post(CartaCreacionDTO cartaCreacionDTO)
        //{
        //    var cartas = mapper.Map<Cartas>(cartaCreacionDTO);
        //    context.Add(cartas);
        //    await context.SaveChangesAsync();
        //    return Ok();

        //}
    }
}
