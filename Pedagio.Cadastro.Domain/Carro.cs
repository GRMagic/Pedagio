namespace Pedagio.Cadastro.Domain
{
    public class Carro
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public int Ano { get; set; }
        public Modelo Modelo { get; set; }
    }
}
