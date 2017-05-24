using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using SearchProto1.Model;
using System.Collections.ObjectModel;
using SearchProto1.DataAccess;
using System.Linq;

namespace SearchProto1.UI.DX.ViewModel
{
    //[POCOViewModel]
    public class OrdersViewModel
    {
        public ReadOnlyCollection<Model.Model> Models { get; set; }
        IRepository repository = new MockRepository("Resources/");
        public OrdersViewModel()
        {
            Console.WriteLine("OrdersViewModel created.");
            
            Models = new ReadOnlyCollection<Model.Model>(repository.Models.Values.ToList());
            

        }
    }
}