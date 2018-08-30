using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TCCApp.Helpers;
using TCCApp.Negocio;
using Xamarin.Forms;

namespace TCCApp.ViewModels
{
    public class LoginViewModel
    {
        public string Email { get; set; }
        public string Senha { get; set; }

        public ICommand DoLogin { get; set; }

        public ICommand DoRegister { get; set; }

        public ICommand DoEsqueciMinhaSenha { get; set; }
        public IAuthNegocio AuthNegocio { get; }

        

        public LoginViewModel()
        {
            AuthNegocio = DependencyService.Get<IAuthNegocio>();

            DoLogin = new Command(() => {

                if(string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Senha))
                {
                    MessagingCenter.Send<string>("Usuario ou Senha invalidos/Não informados", HelperMessagingCenter.LoginFail);
                    return;
                }

                if(AuthNegocio.DoLogin(Email, Senha))
                {
                    MessagingCenter.Send<string>("Login Efetuado", HelperMessagingCenter.LoginSucess);
                }
            });


            DoRegister = new Command(() =>
            {
                MessagingCenter.Send<string>("Iniciar Registro", HelperMessagingCenter.OpenRegister);
            });

            DoEsqueciMinhaSenha = new Command(() => {
                MessagingCenter.Send<string>( Email ?? "", HelperMessagingCenter.OpenEsqueciMinhaSenha);
            });
            
        }

    }
}
