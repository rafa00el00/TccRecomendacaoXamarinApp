using System;
using System.Collections.Generic;
using System.Text;

namespace TCCApp.Negocio
{
    public interface IAuthNegocio
    {
        bool DoLogin(string email, string senha);
    }
    public class AuthNegocio : IAuthNegocio
    {
        public bool DoLogin(string email, string senha)
        {
            return true;
        }
    }
}
