using Domain.Entidades;
using System;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Infra.Data.Repository
{
    public class UsuarioADRepository : BaseRepository<UsuarioAD>
    {

        public bool ValidaAcessoUsuario(string pLogin, string pSenha)
        {
            var usuario = Read(x => x.Login == pLogin).FirstOrDefault();

            if (usuario != null)
            {
                var authTicket = new FormsAuthenticationTicket(1, pLogin, DateTime.Now, DateTime.Now.AddMinutes(30), true, "");
                string cookieContents = FormsAuthentication.Encrypt(authTicket);

                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, cookieContents)
                {
                    Expires = authTicket.Expiration,
                    Path = FormsAuthentication.FormsCookiePath
                };

                if (HttpContext.Current != null)
                {
                    HttpContext.Current.Response.Cookies.Add(cookie);
                }

                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
