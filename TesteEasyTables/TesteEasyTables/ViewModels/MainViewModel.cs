using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteEasyTables.Model;
using Xamarin.Forms;

namespace TesteEasyTables.ViewModels
{
   public class MainViewModel: BaseViewModel
    {
        private string _nome;

        public string Nome
        {
            get { return _nome; }
            set
            {
                _nome = value;
                OnPropertyChanged();
            }
        }
        private int _idade;

        public int Idade
        {
            get { return _idade; }
            set
            {
                _idade = value;
                OnPropertyChanged();
            }
        }

        private bool Busy;

        public bool IsBusy
        {
            get { return Busy; }
            set
            {
                Busy = value;
                OnPropertyChanged();
                GetUserCommand.ChangeCanExecute();
            }
        }

        public ObservableCollection<Usuario> Usuarios { get; set; }
        public Command GetUserCommand { get; }
        public Command CadastrarCommand { get; }

        public MainViewModel()
        {
            Usuarios = new ObservableCollection<Usuario>();
            CadastrarCommand = new Command(ExecuteCadastrarCommand);
            GetUserCommand = new Command(async () => await GetUsers(), () => !IsBusy);
        }

        void ExecuteCadastrarCommand(object obj)
        {
            var NovoUser = new Usuario
            {

                Nome = Nome,
                Idade = Idade
            };

            Enviar(NovoUser);
        }

        async void Enviar(Usuario novoUser)
        {
            if(!IsBusy)
            {
                Exception Error = null;
                try
                {
                    IsBusy = true;
                    var Teste = new Services.AzureServices<Usuario>();                    
                    await Teste.Enviar(novoUser);
                }
                catch (Exception ex)
                {

                    Error = ex;
                }
                finally
                {
                    IsBusy = false;
                   
                }
                if(Error !=null)
                    await App.Current.MainPage.DisplayAlert("Erro!", Error.Message, "Ok");
            }
            return;
          
        }

        async Task GetUsers()
        {
            if(!IsBusy)
            {
                Exception Error = null;
                try
                {
                    IsBusy = true;

                    var Repository = new Repository();
                    var Items = await Repository.GetUser();

                    Usuarios.Clear();
                    foreach (var usuario in Items)
                    {
                        Usuarios.Add(usuario);
                    }
                }
                catch (Exception ex)
                {

                    Error = ex;
                }
                finally
                {
                    IsBusy = false;
                }
                if(Error != null)
                {
                    await App.Current.MainPage.DisplayAlert("Erro!", Error.Message, "Ok");
                }
            }
            return;
        }

        
    }
}
