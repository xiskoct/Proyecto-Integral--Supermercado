using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOrders.Models
{
    public class Productos
    {
        //Comentario: Si no coincide con los campos de la API: [JsonProperty("id")]
        public int idProducto { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string precio { get; set; }
        public string imagen { get; set; }
        public string categoria { get; set; }
    }
}
