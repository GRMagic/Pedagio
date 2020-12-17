using Pedagio.Cadastro.Domain;

namespace Pedagio.Api.ViewModels
{
    class MarcaViewModel
    {
        /// <summary>
        /// Identificação da marca
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome da Marca
        /// </summary>
        public string Nome { get; set; }

        public MarcaViewModel(Marca modelo)
        {
            Id = modelo.Id;
            Nome = modelo.Nome;
        }
    }
}
