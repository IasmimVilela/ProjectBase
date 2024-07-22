using System;
using AutoMapper;
using TaskB3.Application.Services;
using TaskB3.Application.ViewModels;
using TaskB3.Domain.Interfaces;
using Moq;
using Xunit;
using TaskB3.Domain.Enums;

namespace TaskB3.Application.UnitTests.Services
{
    public class TarefaAppServiceTests
    {
        [Fact]
        public void GetById()
        {
            // Arrange
            var tarefa = new Domain.Models.Tarefa(new Guid(), "Teste", new DateTime(), Status.Aguardando);

            var customerRepositoryMock = new Mock<ITarefaRepository>();
            customerRepositoryMock.Setup(x => x.GetById(tarefa.Id))
                .Returns(tarefa);
            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(x => x.Map<TarefaViewModel>(tarefa)).Returns(new TarefaViewModel
            {
                Id = tarefa.Id,
                Descricao = tarefa.Descricao,
                Status = tarefa.Status,
                Data = tarefa.Data,
            });

            // Act
            var sut = new TarefaAppService(mapperMock.Object, customerRepositoryMock.Object, null, null);
            var result = sut.GetById(tarefa.Id);

            // Assert
            Assert.Equal(result.Id, tarefa.Id);
            Assert.Equal(result.Descricao, tarefa.Descricao);
            Assert.Equal(result.Status, tarefa.Status);
            Assert.Equal(result.Data, tarefa.Data);
        }
    }
}
