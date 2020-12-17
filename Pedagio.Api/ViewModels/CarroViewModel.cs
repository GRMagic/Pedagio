using Pedagio.Cadastro.Domain;

namespace Pedagio.Api.ViewModels
{
    public class CarroViewModel
    {
        /// <summary>
        /// Identificação do Carro
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Placa do carro
        /// </summary>
        public string Placa { get; set; }

        /// <summary>
        /// Ano do carro
        /// </summary>
        public int Ano { get; set; }

        /// <summary>
        /// Identificador do modelo do carro
        /// </summary>
        public int? IdModelo { get; set; }

        public CarroViewModel(Carro carro)
        {
            Id = carro.Id;
            Placa = carro.Placa;
            Ano = carro.Ano;
            IdModelo = carro.Modelo?.Id;
        }
    }
}
