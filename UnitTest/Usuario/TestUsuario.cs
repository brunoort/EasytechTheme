using Domain.Entidades;
using Infra.Data.Repository;
using NUnit.Framework;

namespace UnitTest.Usuario
{
    [TestFixture]
    public class TestUsuario
    {
        [Test]
        public void CadastraUsuario()
        {
            UsuarioADRepository _usuarioRep = new UsuarioADRepository();

            var usuario = new UsuarioAD
            {
                Login = "Teste"
            };
            _usuarioRep.Create(usuario);
        }
    }
}
