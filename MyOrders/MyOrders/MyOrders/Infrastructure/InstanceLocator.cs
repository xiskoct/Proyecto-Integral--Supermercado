using Supermercado.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermercado.Infrastructure
{
    public class InstanceLocator
    {
        public InstanceLocator()
        {
            Main = new MainViewModel();
            //ProductosVM = new ProductosViewModel();
            //ClientesVM = new ClientesViewModel();

        }

        public MainViewModel Main { get; set; }
        //public ProductosViewModel ProductosVM { get; set; }


        //public ClientesViewModel ClientesVM { get; set; }


    }
}
