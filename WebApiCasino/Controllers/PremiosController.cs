using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCasino.DTOs;
using WebApiCasino.Entidades;
using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.AspNetCore.Authentication.JwtBearer;


namespace WebApiCasino.Controllers
{
    [ApiController]
    [Route("rifas/{rifaId:int}/premios")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PremiosController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly UserManager<IdentityUser> userManager;

        public PremiosController(ApplicationDbContext context, IMapper mapper, UserManager<IdentityUser> userManager)
        {
            this.context = context;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        [HttpGet]

        public async Task<ActionResult<List<PremioDTO>>> Get(int rifaId)
        {
            var existeRifa = await context.Rifas.AnyAsync(rifaDB => rifaDB.Id == rifaId);
            if (!existeRifa)
            {
                return NotFound();
            }

            var premios = await context.Premios.Where(premioDB => premioDB.RifaId == rifaId).ToListAsync();

            return mapper.Map<List<PremioDTO>>(premios);
        }

        [HttpGet("{id:int}", Name = "obtenerPremio")]
        public async Task<ActionResult<PremioDTO>> GetById(int id)
        {
            var premio = await context.Premios.FirstOrDefaultAsync(premioDB => premioDB.Id == id);

            if (premio == null)
            {
                return NotFound();
            }

            return mapper.Map<PremioDTO>(premio);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Post(int rifaId, PremioCreacionDTO premioCreacionDTO)
        {
            var emailClaim = HttpContext.User.Claims.Where(claim => claim.Type == "email").FirstOrDefault();

            var email = emailClaim.Value;

            var usuario = await userManager.FindByEmailAsync(email);
            var usuarioId = usuario.Id;

            var existeRifa = await context.Rifas.AnyAsync(rifaDB => rifaDB.Id == rifaId);
            if (!existeRifa)
            {
                return NotFound();
            }

            var premio = mapper.Map<Premios>(premioCreacionDTO);
            premio.RifaId = rifaId;
            premio.UsuarioId = usuarioId;
            context.Add(premio);
            await context.SaveChangesAsync();

            var premioDTO = mapper.Map<PremioDTO>(premio);

            return CreatedAtRoute("obtenerPremio", new { id = premio.Id, rifaId = rifaId }, premioDTO);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int rifaId, int id, PremioCreacionDTO premioCreacionDTO)

        {
            var existeRifa = await context.Rifas.AnyAsync(rifaDB => rifaDB.Id == rifaId);
            if (!existeRifa)
            {
                return NotFound();
            }

            var existePremio = await context.Premios.AnyAsync(premioDB => premioDB.Id == id);
            if (!existePremio)
            {
                return NotFound();
            }
            var premio = mapper.Map<Premios>(premioCreacionDTO);
            premio.Id = id;
            premio.RifaId = rifaId;


            context.Update(premio);
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await context.Premios.AnyAsync(x => x.Id == id);
            if (!exist)
            {
                return NotFound("El premio de la rifa que desea eliminar no existe");
            }
            context.Remove(new Premios { Id = id });
            await context.SaveChangesAsync();
            return Ok();

        }
    }
}
