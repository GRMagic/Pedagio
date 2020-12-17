using Pedagio.Cadastro.Domain;
using System;

namespace Pedagio.Cadastro.Data.Dto
{
    class PassagemDto
    {
        public PassagemDto(){ }

        public PassagemDto(Passagem passagem)
        {
            Id = passagem.Id;
            IdCarro = passagem.Carro.Id;
            Momento = passagem.Momento;
            Evasao = passagem.Evasao;
        }

        public Passagem ToPassagem()
        {
            return new Passagem
            {
                Id = Id,
                Momento = Momento,
                Evasao = Evasao,
                Carro = new Carro
                {
                    Id = IdCarro
                }
            };
        }

        public int Id { get; set; }
        public int IdCarro { get; set; }
        public DateTime Momento { get; set; }
        public bool Evasao { get; set; }
    }
}
