using Pedagio.Cadastro.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pedagio.Cadastro.Data.Dto
{
    class ModeloDto
    {
        public ModeloDto(){ }

        public ModeloDto(Modelo modelo)
        {
            Id = modelo.Id;
            IdMarca = modelo.Marca?.Id;
            Nome = modelo.Nome;
        }

        public Modelo ToModelo()
        {
            return new Modelo
            {
                Id = Id,
                Nome = Nome,
                Marca = new Marca
                {
                    Id = IdMarca
                }
            };
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int? IdMarca { get; set; }
    }
}
