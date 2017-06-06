using Supermercado.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Supermercado.Services
{
    public class ApiService
    {
        public async Task<List<Productos>> GetAllProductos()
        {
            using (HttpClient client = new HttpClient())
            {
                //Cabeceras
                
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("utf-8"));
                   

                //Procesado peticion get en JSON
                string url = "http://melocomo.digitalpower.es/v1/productos";
                var result = await client.GetAsync(url); //GET

                string data = await result.Content.ReadAsStringAsync(); //DATA

                if (result.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<List<Productos>>(data);
                }
                else
                    return new List<Productos>();
            }
        }

        public async Task<List<Clientes>> GetAllClientes()
        {
            using (HttpClient client = new HttpClient())
            {
                //Cabeceras

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("utf-8"));


                //Procesado peticion get en JSON
                string url = "http://melocomo.digitalpower.es/v1/clientes/login";
                var result = await client.GetAsync(url); //GET

                string data = await result.Content.ReadAsStringAsync(); //DATA

                if (result.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<List<Clientes>>(data);
                }
                else
                    return new List<Clientes>();
            }
        }



        public async Task<Productos> CreatePedidos(Productos newPedidos)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = "http://ninjatips.azurewebsites.net/tables/Orders";
                //client.DefaultRequestHeaders.Add("ZUMO-API-VERSION", "2.0.0");

                string content = JsonConvert.SerializeObject(newPedidos);
                StringContent body = new StringContent(content, Encoding.UTF8, "application/json");
                var result = await client.PostAsync(url, body);

                string data = await result.Content.ReadAsStringAsync();

                if (result.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<Productos>(data);
                }
                else
                    return null;
            }
        }
    }
}
