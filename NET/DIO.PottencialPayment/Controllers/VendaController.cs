using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DIO.PottencialPayment.Context;
using Microsoft.AspNetCore.Mvc;
using PresentersResponse = DIO.PottencialPayment.Presenters.Response;
using PresentersRequest = DIO.PottencialPayment.Presenters.Request;
using PottencialPayment.Models;

namespace DIO.PottencialPayment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendaController : ControllerBase
    {
        private readonly PaymentContext _context;

        public VendaController(PaymentContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var venda = _context.Vendas.Find(id);
            if(venda == null) return NotFound();

            var vendedor = _context.Vendedores.Find(venda.VendedorId);
            if (vendedor == null) return NotFound();

            var itens = _context.Itens.Where(i => i.VendaId == venda.Id).ToList();

            PresentersResponse::Venda response = new PresentersResponse::Venda(){
                Id = venda.Id,
                Data = venda.Data,
                Status = venda.Status.ToString(),
                Vendedor = new PresentersResponse::Vendedor(){
                    Nome = vendedor.Nome,
                    CPF = vendedor.CPF,
                    Email = vendedor.Email,
                    Telefone = vendedor.Telefone
                }
            };

            foreach (var item in itens)
            {
                PresentersResponse::Item resp = new PresentersResponse::Item(){
                    Nome = item.Nome,
                    Quantidade = item.Quantidade,
                    Valor = item.Valor
                };
                response.Items.Add(resp);
            }

            return Ok(response);
        }

        [HttpPost]
        public IActionResult Criar(PresentersRequest::Venda venda)
        {
            List<string> error = new List<string>();
            if (venda != null)
            {
                if (venda.Vendedor != null && venda.Vendedor.Nome.Length > 0 && venda.Vendedor.CPF.Length > 0 && venda.Vendedor.Telefone.Length > 0)
                {
                if (venda.Items.Count == 0)
                {
                    error.Add("Informe pelo meno um item vendido!");
                }
                }
                else
                {
                error.Add("Informe os dados do vendedor!!");
                }
            }
            else
            {
                error.Add("Parâmetros não informados!!");
            }

            if (error.Count > 0)
            {
                return BadRequest(new { Erro = string.Join(", ", error) });
            }
            else
            {
                Venda vendaBanco = new Venda()
                {
                Data = venda.Data,
                Status = StatusVendaEnum.Entregue,

                Vendedor = new Vendedor()
                {
                    Nome = venda.Vendedor.Nome,
                    CPF = venda.Vendedor.CPF.Replace(" ", "").Replace(".", "").Replace("-", ""),
                    Email = venda.Vendedor.Email,
                    Telefone = venda.Vendedor.Telefone
                }
                };

                _context.Vendas.Add(vendaBanco);
                _context.SaveChanges();

                foreach (Item item in venda.Items)
                {
                    _context.Itens.Add(new Item()
                    {
                        Nome = item.Nome,
                        Quantidade = item.Quantidade,
                        Valor = item.Valor,
                        VendaId = vendaBanco.Id
                    });
                }

                _context.SaveChanges();

                return Ok(vendaBanco.Id);
            }
        }

        [HttpPost("AlterarStatus")]
        public IActionResult AlterarStatus(PresentersRequest::AlterarStatus req)
        {
            var venda = _context.Vendas.Find(req.VendaId);
            if (venda == null)
                return NotFound("Id não encontrado");

            switch (req.Status)
            {
                case StatusVendaEnum.PagamentoAprovado:
                    if (!venda.Status.Equals("Aguardando pagamento"))
                    {
                        return BadRequest(new { Erro = "Sua venda precisa estar no status [Aguardando pagamento] para poder ser alterada para este novo status" });
                    }
                    else
                    {
                        venda.Status = req.Status;
                    }
                    break;

                case StatusVendaEnum.EnviadoTransportadora:
                    if (!venda.Status.Equals("Pagamento aprovado"))
                    {
                        return BadRequest(new { Erro = "Sua venda precisa estar no status [Enviado para a transportadora] para poder ser alterada para este novo status" });
                    }
                    else
                    {
                        venda.Status = req.Status;
                    }
                    break;

                case StatusVendaEnum.Entregue:
                    if (!venda.Status.Equals("Enviado para a transportadora"))
                    {
                        return BadRequest(new { Erro = "Sua venda precisa estar no status [Enviado para a transportadora] para poder ser alterada para este novo status" });
                    }
                    else
                    {
                        venda.Status = req.Status;
                    }
                    break;

                case StatusVendaEnum.Cancelada:
                    if (!venda.Status.Equals("Enviado para a transportadora"))
                    {
                        return BadRequest(new { Erro = "Como esta venda já está na transportadora, ela não pode ser cancelada" });
                    }
                    else
                    {
                        venda.Status = req.Status;
                    }
                    break;

                default:
                    return BadRequest(new { Erro = "Informe um estatus válido: [Pagamento aprovado, Enviado para a transportadora, Entregue ou Cancelada]" });
            }

            _context.Vendas.Update(venda);
            _context.SaveChanges();

            return Ok(venda);
        }

    }
}