using Supermercado.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Java.IO;
using Android.OS;

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

    
        public async Task<List<Clientes>> checkAuth(string user, string password)
        {
            using (var client = new HttpClient())
            {
                //Convierto en array y serializo
                var jsonRequest = new { email = user, password = password };

                var serializedJsonRequest = JsonConvert.SerializeObject(jsonRequest);

                string apiurl = "http://melocomo.digitalpower.es/v1/clientes/login";
                HttpContent content = new StringContent(serializedJsonRequest, Encoding.UTF8, "application/json");
               

                var result = await client.PostAsync(apiurl, content);

                string data = await result.Content.ReadAsStringAsync();

                if (result.IsSuccessStatusCode)
                {                    
                    return  JsonConvert.DeserializeObject<List<Clientes>>(data);
                
                }
                else
                    return new List<Clientes>();

            }
        }

        /*
        public async Task<List<Clientes>> CreatePedidos()
        {
            using (var client = new HttpClient())
            {
                //Convierto en array y serializo
                var jsonRequest = new { email = user, password = password };

                var serializedJsonRequest = JsonConvert.SerializeObject(jsonRequest);
                
                string apiurl = "http://melocomo.digitalpower.es/v1/clientes/login";
                HttpContent content = new StringContent(serializedJsonRequest, Encoding.UTF8, "application/json");


                var result = await client.PostAsync(apiurl, content);

                string data = await result.Content.ReadAsStringAsync();

                if (result.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<List<Clientes>>(data);

                }
                else
                    return new List<Clientes>();

            }
        }

    */




        public static byte[] convertStringtoByteArray(string userName, string userPassword)
        {
            var byteArray = Encoding.UTF8.GetBytes(userName + ":" + userPassword);
            return byteArray;
        }

    }
}

       
  

