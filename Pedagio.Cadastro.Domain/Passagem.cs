using System;

namespace Pedagio.Cadastro.Domain
{
    public class Passagem
    {
        public int Id { get; set; }
        public Carro Carro { get; set; }
        public DateTime Momento { get; set; }
        public bool Evasao { get; set; }
    }
}
