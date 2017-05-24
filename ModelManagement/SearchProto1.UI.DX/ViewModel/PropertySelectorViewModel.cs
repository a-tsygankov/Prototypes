using System;
using DevExpress.Mvvm;
using SearchProto1.Model;
using System.Collections.ObjectModel;
using SearchProto1.DataAccess;
using System.Collections.Generic;
using System.Linq;

namespace SearchProto1.UI.DX.ViewModel
{
    public class PropertySelectorViewModel : ViewModelBase
    {
        public ReadOnlyCollection<Category> Categories { get; set; }
        public virtual object SelectedItem { get; set; }
        IRepository repository = new MockRepository("Resources/");

        public PropertySelectorViewModel()
        {
            Console.WriteLine("PropertySelectorViewModel created.");
            
            Categories = new ReadOnlyCollection<Category>(repository.Categories.Values.ToList());
            if (Categories.Count > 0)
                SelectedItem = Categories[0].SearchableProperties[0];
        }
    }
}