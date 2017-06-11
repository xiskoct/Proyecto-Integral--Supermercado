using GalaSoft.MvvmLight.Command;
using Supermercado.Models;
using Supermercado.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Supermercado.ViewModels
{
    public class ClientesViewModel
    {
        ApiService apiService;
        DialogService dialogService;

        public ClientesViewModel()
        {
            apiService = new ApiService();
            dialogService = new DialogService();
            DeliveryDate = DateTime.Today;
        }

        //Para login
        public string user { get; set; }

        public string password { get; set; }



        public int idCliente { get; set; }
        

        public string nombre { get; set; }
        public string email { get; set; }
        public string direccion { get; set; }
        public string poblacion { get; set; }
        public string cp { get; set; }
        public string provincia { get; set; }
        public string pais { get; set; }
        public string DNI { get; set; }
        public string fec_alta { get; set; }
        public string claveAPI { get; set; }


       

        public DateTime? DeliveryDate { get; set; }
        public bool IsDelivered { get; set; }
        public DateTime MinimumDate { get; private set; }

        /*
          public ICommand SaveCommand
        {
            get { return new RelayCommand(Save); }
        }

        /*
        private async void Save()
        {
            try
            {
                await apiService.CreatePedidos(new Productos()
                { 
                    idProducto = Guid.NewGuid().ToString(),
                    nombre = this.Title,
                    descripcion = this.Client,
                    precio = this.DeliveryDate,
                    imagen = this.DeliveryInformation,
                    categoria = this.Description,
                });

                await dialogService.ShowMessage("El pedido ha sido creado.", "Información");
            }
            catch 
	        {
                await dialogService.ShowMessage("Ha ocuarrido un error inesperado.", "Error");
            }
        }
        */
    }
}
