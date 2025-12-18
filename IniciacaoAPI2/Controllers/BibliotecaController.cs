using API.Commands;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BibliotecaController : ControllerBase
    {
        private IBibliotecaRepository _bibliotecaRepository;
        public BibliotecaController(IBibliotecaRepository bibliotecaRepository)
        {
            _bibliotecaRepository = bibliotecaRepository;
        }

        [HttpGet]
        [Route("biblioteca/{idBiblioteca}")]
        [Produces("application/json")]
        public Biblioteca? RecuperarBibliotecaPorId(Guid idBiblioteca)
        {
            try
            {
                return _bibliotecaRepository.RecuperarBibliotecaPorId(idBiblioteca);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        [HttpPost]
        [Route("biblioteca")]
        [Produces("application/json")]
        public Biblioteca? CriarNova([FromBody] CriarBibliotecaCommand nomeBiblioteca)
        {
            try
            {
                return _bibliotecaRepository.CriarNovaBiblioteca(nomeBiblioteca.Nome);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        [HttpPut]
        [Route("biblioteca/{idBiblioteca}")]
        [Produces("application/json")]
        public Biblioteca? CriarNova([FromBody] CriarBibliotecaCommand nomeBiblioteca, Guid idBiblioteca)
        {
            try
            {
                return _bibliotecaRepository.AtualizarBiblioteca(idBiblioteca, nomeBiblioteca.Nome);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        [HttpDelete]
        [Route("biblioteca/{idBiblioteca}")]
        [Produces("application/json")]
        public Biblioteca? ExcluirBiblioteca(Guid idBiblioteca)
        {
            try
            {
                return _bibliotecaRepository.ExcluirBiblioteca(idBiblioteca);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        [Route("biblioteca/todas")]
        [Produces("application/json")]
        public Biblioteca? RecuperarTodas(Guid idBiblioteca, string nomeBiblioteca)
        {
            try
            {
                return _bibliotecaRepository.RecuperarBiblioteca(idBiblioteca, nomeBiblioteca);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}