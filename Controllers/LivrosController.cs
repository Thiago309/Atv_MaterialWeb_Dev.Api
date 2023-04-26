using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chapter.WebApi.Models;
using Chapter.WebApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chapter.WebApi.Controllers
{
    [Route("api/[controller]")]

    [ApiController]

    public class LivrosController : ControllerBase
    {
        private readonly LivroRepository _livroRepository;
        public LivrosController(LivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public IActionResult Listar()
        {
            return Ok(_livroRepository.Listar());
        }

        //get /api/livros/{id}
        [HttpGet("{id}")]   //busca pelo id passado
        public IActionResult Listar(int id)
        {

            Livro livro = _livroRepository.BuscarPorId(id);

            if (livro == null)
            {
                return NotFound();
            }
            return Ok(livro);
        }

        [HttpPut("{id}")]   //o id passado no put /api/livros/1
        public IActionResult Atualizar(int id, Livro livro)
        {
            _livroRepository.Atualizar(id, livro);
            return StatusCode(204);
        }

        // post /api /
        // recebe ainfo do livro que deseja salvar docorpo da requisição
        [HttpPost]
        public IActionResult Cadastrar(Livro livro)
        {
            _livroRepository.Cadastrar(livro);
            return StatusCode(201);
        }

        // delete /api /livros/{
        [HttpDelete("{id}")] // o id passado no deleteapi /livros/1
        public IActionResult Deletar(int id)
        {
            _livroRepository.Deletar(id);
            return StatusCode(204);
        }
    }
}