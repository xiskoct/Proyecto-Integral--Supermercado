﻿using GalaSoft.MvvmLight.Command;
using MyOrders.Models;
using MyOrders.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyOrders.ViewModels
{
    public class ProductosViewModel
    {
        ApiService apiService;
        DialogService dialogService;

        public ProductosViewModel()
        {
            apiService = new ApiService();
            dialogService = new DialogService();
            DeliveryDate = DateTime.Today;
        }
        public int idProducto { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string precio { get; set; }
        public string imagen { get; set; }
        public string categoria { get; set; }

        public DateTime? DeliveryDate { get; set; }
        public bool IsDelivered { get; set; }
        public DateTime MinimumDate { get; private set; }

        
          public ICommand SaveCommand
        {
            get { return new RelayCommand(Save); }
        }

        
        private async void Save()
        {
            try
            {
                await apiService.CreatePedidos(new Productos()
                { /*
                    idProducto = Guid.NewGuid().ToString(),
                    nombre = this.Title,
                    descripcion = this.Client,
                    precio = this.DeliveryDate,
                    imagen = this.DeliveryInformation,
                    categoria = this.Description,*/
                });

                await dialogService.ShowMessage("El pedido ha sido creado.", "Información");
            }
            catch 
	        {
                await dialogService.ShowMessage("Ha ocuarrido un error inesperado.", "Error");
            }
        }
        
    }
}