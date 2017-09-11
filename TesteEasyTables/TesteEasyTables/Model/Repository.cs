using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteEasyTables.Model
{
    public class Repository
    {
        public async Task<List<Usuario>> GetUser()
        {
            var service = new Services.AzureServices<Usuario>();
            var items = await service.GetTable();
            return items.ToList();
        }
    }
}
