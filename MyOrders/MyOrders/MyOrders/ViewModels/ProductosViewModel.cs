using GalaSoft.MvvmLight.Command;
using Supermercado.Models;
using Supermercado.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Supermercado.ViewModels
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
        public ImageSource imguri { get; set; }
        public string categoria { get; set; }

    
 
        public DateTime? DeliveryDate { get; set; }
        public bool IsDelivered { get; set; }
        public DateTime MinimumDate { get; private set; }
        
        public ImageSource uri()
        {
            try
            {
                imguri = ImageSource.FromUri(new Uri(imagen));
            }
            catch(Exception e)
            {

            }
            return imguri;


        }



    }
}





        /*
          public ICommand SaveCommand
        {
            get { return new RelayCommand(Save); }
        }

        
     
    
    }

}
*/
  