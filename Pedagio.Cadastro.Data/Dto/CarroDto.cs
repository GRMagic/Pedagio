using Pedagio.Cadastro.Domain;

namespace Pedagio.Cadastro.Data.Dto
{
    class CarroDto
    {
        public CarroDto(){ }

        public CarroDto(Carro carro)
        {
            Id = carro.Id;
            Placa = carro.Placa;
            Ano = carro.Ano;
            IdModelo = carro.Modelo.Id;
        }

        public Carro ToCarro()
        {
            return new Carro
            {
                Id = Id,
                Placa = Placa,
                Ano = Ano,
                Modelo = new Modelo
                {
                    Id = IdModelo
                }
            };
        }

        public int Id { get; set; }
        public string Placa { get; set; }
        public int Ano { get; set; }
        public int IdModelo { get; set; }
    }
}
