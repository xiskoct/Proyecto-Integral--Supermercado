using GalaSoft.MvvmLight.Command;
using Supermercado.Pages;
using Supermercado.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Supermercado.ViewModels
{
    public class MainViewModel
    {
        NavigationService navigationService;
        ApiService apiService;

        #region Properties


        //Properties de ViewModel 
        private string _user;
        private string _pass;


        public string user
        {
            get { return _user; }
            set { _user = value; }
        }
        public string pass
        {
            get { return _pass; }
            set { _pass = value; }
        }
 

        public ProductosViewModel productosvm { get; set; }
        public ClientesViewModel clientesvm { get; set; }



        //Miembros que son llamados desde los binding, en este caso desde MainPage
        public ObservableCollection<MenuItemViewModel> Menu { get; set; }
        public ObservableCollection<ProductosViewModel> Productos { get; set; }
        public ObservableCollection<ProductosViewModel> Productos { get; set; }

        public ObservableCollection<ClientesViewModel> Clientes { get; set; }


        #endregion

        public MainViewModel()
        {
            navigationService = new NavigationService();
            apiService = new ApiService();

            //Creo lista temporal de productos
            Productos = new ObservableCollection<ProductosViewModel>();

            //Creo lista temporal de Clientes
            Clientes = new ObservableCollection<ClientesViewModel>();


            LoadMenu();
            //LoadProductos();
        }



        #region Commands

        public ICommand GoToCommand
        {
            get { return new RelayCommand<string>(GoTo); }
        }

        private void GoTo(string pageName)
        {
            // Minuto 31 del video
            switch (pageName)
            {

                case "AddProductoCesta":
                    productosvm = new ProductosViewModel();
                    break;
                case "NewOrderPage":
                    productosvm = new ProductosViewModel();
                    break;
                default:
                    break;

            }

            navigationService.Navigate(pageName);
        }

        public ICommand StartCommand
        {
            get { return new RelayCommand(Start); }
        }


        private async void Start()
        //Se inicializa desde el bindin de WelcomePage
        {

            //Chequeo User y Password.
            /*var listaclientes = await apiService.GetAllClientes();
            foreach (var clientes in listaclientes)
            {
                if(clientes.nombre == "admin")
                {

                }
            }

                */

            //
            //Instancio Atributo
            //clientesvm = new ClientesViewModel();
            //Chequeo Usuario


            /*
            string passw = clientesvm.password;
            var datoscliente = apiService.checkuser(user,passw);
            */

            //Obtenglo datos del cliente enviados por POST
            var datoscliente = await apiService.checkAuth(_user,_pass);
          


                //Obtengo la lista de los productos desde la API
                var listaproductos = await apiService.GetAllProductos();

                //Limpio datos dinamicos del ObservableCOllection
                Productos.Clear();
                //Recorre la lista y llena la ObservableCollection Orders
                foreach (var producto in listaproductos)
                {
                    Productos.Add(new ProductosViewModel()
                    {
                        //Asignas a las ViewModel lo deserializado del JSON a través de los Models
                        nombre = producto.nombre, //ViewModel=Models
                        descripcion = producto.descripcion,
                        precio = producto.precio,
                    });
                }


                //navigationService.SetMainPage("MainPage");
                navigationService.SetMainPage("MasterPage");

            }
        
        

        #endregion


        #region Methods
        private void LoadMenu()
        {
            //Creo Lista de Menu

            Menu = new ObservableCollection<MenuItemViewModel>();

            //Relleno Menu Estaticamente
            Menu.Add(new MenuItemViewModel()
            {
                Icon = "ic_action_orders",
                Title = "Productos",
                PageName = "MainPage"
            });

            Menu.Add(new MenuItemViewModel()
            {
                Icon = "ic_action_clients",
                Title = "Clientes",
                PageName = "ClientsPage"
            });

            Menu.Add(new MenuItemViewModel()
            {
                Icon = "ic_action_alarm",
                Title = "Cesta",
                PageName = "CestaPage"
            });

            Menu.Add(new MenuItemViewModel()
            {
                Icon = "ic_action_settings",
                Title = "Pedidos",
                PageName = "PedidosPage"
            });
        }

        private void LoadProductos()
        {
            
            //Relleno estaticamente
            for (int i = 0; i < 5; i++)
            {
                Productos.Add(new ProductosViewModel()
                {
                    nombre = "Lorem Ipsum",
                    descripcion = "DateTime.Today",
                    imagen = "Lorem ipsum dolor sit amet, consectetur adipiscing elit."
                });
            }
        } 
        
        #endregion

    }
}
