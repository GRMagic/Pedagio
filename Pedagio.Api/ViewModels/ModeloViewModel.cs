using Pedagio.Cadastro.Domain;

namespace Pedagio.Api.ViewModels
{
    class ModeloViewModel
    {
        /// <summary>
        /// Identificação do modelo
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome do Modelo
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Identificação da marca
        /// </summary>
        public int IdMarca { get; set; }

        public ModeloViewModel(Modelo modelo)
        {
            Id = modelo.Id;
            IdMarca = modelo.Marca.Id;
            Nome = modelo.Nome;
        }
    }
}
