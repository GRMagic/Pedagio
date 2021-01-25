using System;
using Xunit;
using NSubstitute;
using Pedagio.Cadastro.Application.Services;
using System.Threading.Tasks;
using NSubstituteAutoMocker;
using Pedagio.Cadastro.Application.Utils;
using Pedagio.Cadastro.Data;
using Pedagio.Cadastro.Domain;
using System.Linq;

namespace Pedagio.Test.Unit
{
    public class PassagemServiceTest
    {
        [Fact(DisplayName = "Efetuar a passagem de um carro não cadastrado usando a placa")]
        [Trait("Categoria", "PassagemService")]
        public async Task EfetuarPassagem_PlacaNaoCadastrada_DeveDarErro()
        {
            // Arrange
            var placa = "abc1234";
            var autoMocker = new NSubstituteAutoMocker<PassagemService>();
            autoMocker.Get<ICarroStore>().BuscarPorPlacaAsync(placa).Returns(Task.FromResult<Carro>(null));
            var esperado = new BusinessException(Language.Mensagens.ErroPlacaNaoEncontrada);
            
            var passagemService = autoMocker.ClassUnderTest;
            
            // Act
            Func<Task> act = async () =>
            {
                await passagemService.EfetuarPassagemAsync(placa);
            };

            // Assert
            var exception = await Assert.ThrowsAsync<BusinessException>(act);
            Assert.Equal(esperado.Code, exception.Code);
            Assert.Equal(esperado.Message, exception.Message);
        }

        [Fact(DisplayName = "Efetuar a passagem de um carro com sucesso")]
        [Trait("Categoria", "PassagemService")]
        public async Task EfetuarPassagem_CarroCadastrado_Sucesso()
        {
            // Arrange
            var carro = new Carro {
                Id = 123,
                Ano = 1990,
                Placa = "abc1234"
            };
            var idPassagem = 456;
            var autoMocker = new NSubstituteAutoMocker<PassagemService>();
            autoMocker.Get<ICarroStore>().BuscarPorPlacaAsync(carro.Placa).Returns(Task.FromResult(carro));
            autoMocker.Get<IPassagemStore>().InserirAsync(Arg.Any<Passagem>()).Returns(Task.FromResult(idPassagem));

            var passagemService = autoMocker.ClassUnderTest;

            // Act
            var resposta = await passagemService.EfetuarPassagemAsync(carro.Placa);

            // Assert
            Assert.Equal(idPassagem, resposta);
        }

        [Fact(DisplayName = "Registrar a evasão de um carro usando uma placa conhecida com sucesso")]
        [Trait("Categoria", "PassagemService")]
        public async Task RegistrarEvasao_PlacaCadastrada_Sucesso()
        {
            // Arrange
            var carro = new Carro
            {
                Id = 123,
                Ano = 1990,
                Placa = "abc1234"
            };
            var idPassagem = 456;
            var autoMocker = new NSubstituteAutoMocker<PassagemService>();
            autoMocker.Get<ICarroStore>().BuscarPorPlacaAsync(carro.Placa).Returns(Task.FromResult(carro));
            autoMocker.Get<IPassagemStore>().InserirAsync(Arg.Any<Passagem>()).Returns(Task.FromResult(idPassagem));

            var passagemService = autoMocker.ClassUnderTest;

            // Act
            var resposta = await passagemService.RegistrarEvasaoAsync(carro.Placa);

            // Assert
            Assert.Equal(idPassagem, resposta);

            var chamada = autoMocker.Get<IPassagemStore>()
                .ReceivedCalls()
                .Where(c => c.GetMethodInfo().Name == "InserirAsync")
                .FirstOrDefault();
            Assert.NotNull(chamada);

            var passagemInserida = chamada.GetArguments().First() as Passagem;
            Assert.True(passagemInserida?.Evasao, "A passagem inserida deve ter a propriedade Evasao = true");
        }

        [Fact(DisplayName = "Ao registrar a evasão de um carro usando uma placa desconhecida o carro deve ser cadastrado")]
        [Trait("Categoria", "PassagemService")]
        public async Task RegistrarEvasao_PlacaNaoCadastrada_Sucesso()
        {
            // Arrange
            var placa = "abc1234";
            var autoMocker = new NSubstituteAutoMocker<PassagemService>();
            
            var passagemService = autoMocker.ClassUnderTest;

            // Act
            var resposta = await passagemService.RegistrarEvasaoAsync(placa);

            // Assert
            var chamadaInserirCarro = autoMocker.Get<ICarroStore>()
                .ReceivedCalls()
                .Where(c => c.GetMethodInfo().Name == "InserirAsync")
                .FirstOrDefault();
            Assert.NotNull(chamadaInserirCarro);

            var chamadaInserirPassagem = autoMocker.Get<IPassagemStore>()
                .ReceivedCalls()
                .Where(c => c.GetMethodInfo().Name == "InserirAsync")
                .FirstOrDefault();
            Assert.NotNull(chamadaInserirPassagem);

        }
    }
}
