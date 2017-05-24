using System;
using DevExpress.Mvvm;
using SearchProto1.Model;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DevExpress.Data.Browsing;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;

namespace SearchProto1.UI.DX.ViewModel
{
    public class SearchViewModel : ViewModelBase
    {
        IRepository repository = new MockRepository("Resources/");
        public DelegateCommand<string> CloseCommand { get; set; }


        public ObservableCollection<string> dict { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<SearchCondition> SearchConditions { get; set; } = new ObservableCollection<SearchCondition>();

        private List<string> GenerateDictionary()
        {
            var res = new List<string>();

            res.AddRange(
                repository.PropertyDefinitions.Values.Select(x => x.PropertyName).ToList());
            res.AddRange(
                repository.PropertyDefinitions.Values.SelectMany(x => x.AcceptableValues??new List<string>()).Distinct().ToList());

            return res;
        }

        void CloseCommandExecute(string parameter)
        {

            //MessageBox.Show(parameter);
            //SearchConditions.Remove(SearchConditions.Single(s => s.propertyName.Equals(parameter)));
            SearchConditions.Remove(SearchConditions.Where(i => i.propertyName.Equals(parameter)).Single());
            MessageBox.Show("SearchConditions.Count=" + SearchConditions.Count);
            //SearchConditions.
            //NotifyPropertyChanged();

        }

        bool CloseCommandCanExecute(string parameter)
        {
            return true;
        }

        public SearchViewModel()
        {
            CloseCommand = new DelegateCommand<string>(CloseCommandExecute, CloseCommandCanExecute); 
            dict = new ObservableCollection<string>(GenerateDictionary());

            SearchConditions.Add(
                new SearchCondition
                {
                    Id = 1,
                    propertyName = "Country",
                    propertyDefinition = repository.GetPropertyByName("Country"),
                    value = "USA",
                    IsIncluded = true
                });
            SearchConditions.Add(
                new SearchCondition
                {
                    Id = 2,
                    propertyName = "Is Submodel",
                    propertyDefinition = repository.GetPropertyByName("Is Submodel"),
                    value = "No",
                    IsIncluded = true
                });
            SearchConditions.Add(
                new SearchCondition
                {
                    Id = 2,
                    propertyName = "Model Type",
                    propertyDefinition = repository.GetPropertyByName("Model Type"),
                    value = "Sector",
                    IsIncluded = false
                });

        }

        public void OnCloseButtonClicked()
        {
            SearchConditions.RemoveAt(0);
        }
    }
}