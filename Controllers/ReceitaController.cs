using Microsoft.AspNetCore.Mvc;
using ApiFinanceira.Models;
using ApiFinanceira.Dtos;

namespace ApiFinanceira.Controllers
{
    [ApiController]
    [Route("receitas")]
    public class ReceitaController : ControllerBase
    {
        
        private static List<Receita> listaReceitas = new List<Receita>();

        [HttpGet]
        public ActionResult<List<Receita>> FindAll()
        {
            return Ok(listaReceitas);
        }

        [HttpGet("{id}")]
        public ActionResult FindById(Guid id)
        {
            var receita = listaReceitas.FirstOrDefault(r => r.Id == id);

            if (receita == null)
            {
                return NotFound("Receita não encontrada");
            }

            return Ok(receita);
        }

        [HttpPost]
        public ActionResult Create([FromBody] ReceitaDto novaReceita)
        {
            var receita = new Receita
            {
                Descricao = novaReceita.Descricao,
                Valor = novaReceita.Valor,
                DataPrevisao = novaReceita.DataPrevisao,
                Categoria = novaReceita.Categoria,
                Observacao = novaReceita.Observacao,
                Situacao = "Pendente"
            };

            listaReceitas.Add(receita);

            return Created("", receita);
        }

        [HttpPut("{id}")]
        public ActionResult Update(Guid id, [FromBody] ReceitaUpdateDto receitaAtualizada)
        {
            var receita = listaReceitas.FirstOrDefault(r => r.Id == id);

            if (receita == null)
            {
                return NotFound("Receita não encontrada");
            }

            receita.Descricao = receitaAtualizada.Descricao;
            receita.Valor = receitaAtualizada.Valor;
            receita.DataPrevisao = receitaAtualizada.DataPrevisao;
            receita.DataRecebimento = receitaAtualizada.DataRecebimento;
            receita.Categoria = receitaAtualizada.Categoria;
            receita.Observacao = receitaAtualizada.Observacao;
            receita.Situacao = receitaAtualizada.Situacao;

            return Ok(receita);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var receita = listaReceitas.FirstOrDefault(r => r.Id == id);

            if (receita == null)
            {
                return NotFound("Receita não encontrada");
            }

            listaReceitas.Remove(receita);

            return NoContent();
        }
    }
}