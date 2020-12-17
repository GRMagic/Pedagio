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
            IdModelo = carro.Modelo?.Id;
        }

        public Carro ToCarro()
        {
            var carro = new Carro
            {
                Id = Id,
                Placa = Placa,
                Ano = Ano
            };
            if (IdModelo > 0)
            {
                carro.Modelo = new Modelo
                {
                    Id = IdModelo.Value
                };
            }
            return carro;
        }

        public int Id { get; set; }
        public string Placa { get; set; }
        public int Ano { get; set; }
        public int? IdModelo { get; set; }
    }
}
