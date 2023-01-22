using System;
using DIO.LocalizaLabsCovid.Data.Collections;
using DIO.LocalizaLabsCovid.Data.DTOs;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using DIO.LocalizaLabsCovid;

namespace DIO.LocalizaLabsCovid.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InfectadoController : ControllerBase
    {
        private Data.MongoDB _mongoDB;
        IMongoCollection<Infectado> _infectadosCollection;

        public InfectadoController(Data.MongoDB mongoDB)
        {
            _mongoDB = mongoDB;
            _infectadosCollection = _mongoDB.DB.GetCollection<Infectado>(typeof(Infectado).Name.ToLower());
        }

        [HttpPost]
        public ActionResult SalvarInfectado([FromBody] InfectadoDTO dto)
        {
            var infectado = new Infectado(dto.DataNascimento, dto.Sexo, dto.Latitude, dto.Longitude);

            _infectadosCollection.InsertOne(infectado);

            return StatusCode(201, "Infected successfully added");
        }

        [HttpGet]
        public ActionResult ObterInfectados()
        {
            var infectados = _infectadosCollection.Find(Builders<Infectado>.Filter.Empty).ToList();

            return Ok(infectados);
        }

        [HttpPut]
        public ActionResult AtualizarInfectado([FromBody] InfectadoDTO dto)
        {
            _infectadosCollection.UpdateOne(Builders<Infectado>.Filter.Where(_ => _.DataNascimento == dto.DataNascimento), Builders<Infectado>.Update.Set("sexo", dto.Sexo));

            return Ok("Successfully updated");
        }

        [HttpDelete("{dataNasc}")]
        public ActionResult DeletarInfectado(DateTime dataNasc)
        {
            _infectadosCollection.DeleteOne(Builders<Infectado>.Filter.Where(_ => _.DataNascimento == dataNasc));

            return Ok("Successfully deleted");
        }
    }
}