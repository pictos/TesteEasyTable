using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.WindowsAzure.MobileServices;

namespace TesteEasyTables.Model
{
    [DataTable("Usuario")]
    public class Usuario
    {
        [JsonProperty("Id")]
        public string Id { get; set; }
        [Version]
        public string AzureVersion { get; set; }
        [JsonProperty("Nome")]
        public string Nome { get; set; }
        [JsonProperty("Idade")]
        public int Idade { get; set; }
    }
}
