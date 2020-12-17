using Pedagio.Cadastro.Domain;
using System;

namespace Pedagio.Api.ViewModels
{
    class PassagemViewModel
    {
        /// <summary>
        /// Identificação da passagem
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Identificação do carro
        /// </summary>
        public int IdCarro { get; set; }

        /// <summary>
        /// Momento que a passagem foi realizada
        /// </summary>
        public DateTime Momento { get; set; }

        /// <summary>
        /// Foi uma evasão
        /// </summary>
        public bool Evasao { get; set; }

        public PassagemViewModel(Passagem passagem)
        {
            Id = passagem.Id;
            IdCarro = passagem.Carro.Id;
            Momento = passagem.Momento;
            Evasao = passagem.Evasao;
        }
    }
}
