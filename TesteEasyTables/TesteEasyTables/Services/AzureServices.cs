using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;using TesteEasyTables.Model;

namespace TesteEasyTables.Services
{
    public class AzureServices<T>
    {
        IMobileServiceClient Client;
        IMobileServiceTable<Usuario> Table;

        public AzureServices()
        {
            string MyAppServiceURL = "http://pedro1teste.azurewebsites.net";
            Client = new MobileServiceClient(MyAppServiceURL);
            Table = Client.GetTable<Usuario>();
        }

        public Task<IEnumerable<Usuario>> GetTable()
        {
            return Table.ToEnumerableAsync();
        }

        public async Task Enviar(Usuario usuario)
        {
            await Table.InsertAsync(usuario);
            await App.Current.MainPage.DisplayAlert("Sucesso", "Mensagem envida", "Ok");
        }
    }
}
