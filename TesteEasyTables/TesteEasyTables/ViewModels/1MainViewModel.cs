using System.Collections.Generic;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using TesteEasyTables.Model;

namespace TesteEasyTables.ViewModels
{
    public class MainViewModel : BaseViewModel
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
        

        public Command CadastrarCommand { get; }
        public Command ConsultarCommand { get; }
        public ObservableCollection<Usuario> Usuario { get; set; }


        public List<Usuario> Lista { get; set; }

        public MainViewModel()
        {
            
            Usuario = new ObservableCollection<Usuario>();
            CadastrarCommand = new Command(ExecuteCadastrarCommand);
            ConsultarCommand = new Command(ExecuteConsultarCommandAsync);
        }

        async void ExecuteConsultarCommandAsync()
        {        
            
            
        }

        
        

        private void ExecuteCadastrarCommand(object obj)
        {
            var novo = new Usuario()
            {
                Nome = Nome,
                Idade = Idade
            };

            Enviar(novo);
        }

        async void Enviar(Usuario elemento)
        {
            
            await App.Current.MainPage.DisplayAlert("Sucesso", "Mensagem envida", "Ok");
            
        }
    }
}

