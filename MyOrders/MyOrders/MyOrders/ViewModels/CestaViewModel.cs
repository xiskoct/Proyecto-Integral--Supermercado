using GalaSoft.MvvmLight.Command;
using Supermercado.Models;
using Supermercado.Services;
using System.Windows.Input;

namespace Supermercado.ViewModels
{
    public class CestaViewModel
    {
        public CestaViewModel()
        {

        }
        public int idLineaPedido { get; set; }
        public int idPedido { get; set; }
        public int idProducto { get; set; }
        public int cantidad { get; set; }
        public double precio { get; set; }
    }
}


        /*
        public ICommand AddProductoCesta
        {
            get { return new RelayCommand(SaveProductoCesta); }
        }

        
        private async void SaveProductoCesta()
        {
            try
            {
                await ApiService.CreateCesta(new Cesta()
                {
                idLineaPedido = this.idLineaPedido,
                idPedido = this.idPedido,
                idProducto = this.idProducto,
                cantidad = this.cantidad,
                precio = this.precio,
                });

                //await dialogService.ShowMessage("El pedido ha sido creado.", "Información");
            }

            catch
            {
                //await dialogService.ShowMessage("Ha ocuarrido un error inesperado.", "Error");
            }
        }
    }

 
}*/