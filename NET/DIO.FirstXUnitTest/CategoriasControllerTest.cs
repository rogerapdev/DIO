using DIO.FirstAPI.Controllers;
using DIO.FirstWeb.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace DIO.FirstXUnitTest
{
    public class CategoriasControllerTest
    {
        private readonly Mock<DbSet<Categoria>> _mockSet;
        private readonly Mock<Context> _mockContext;
        private readonly Categoria _categoria;

        public CategoriasControllerTest()
        {
            _mockSet = new Mock<DbSet<Categoria>>();
            _mockContext = new Mock<Context>();

            _categoria = new Categoria() { Id = 1, Descricao = "Teste" };

        }
        [Fact]
        public async Task Get_Categoria()
        {
            var service = new CategoriasController(_mockContext.Object);

            await service.GetCategoria(1);

            _mockSet.Verify(m => m.FindAsync(1), Times.Once);
        }
    }
}
