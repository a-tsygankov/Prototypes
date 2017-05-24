using SearchProto1.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchProto1.Model
{
    public class MockRepository : IRepository
    {
        const string CATEGORIES_FILE_NAME = "categories.json";
        const string ACCOUNTS_FILE_NAME = "accounts.json";
        const string SECURITIES_FILE_NAME = "securities.json";
        const string MODELS_FILE_NAME = "models.json";
        private string FolderPath { get; set; } = "";
        public Dictionary<int, Model> Models { get; set; }
        public Dictionary<int, Category> Categories { get; set; }
        public Dictionary<int, PropertyDefinition> PropertyDefinitions { get; set; }
        public Dictionary<int, Security> Securities { get; set; }
        public Dictionary<int, Account> Accounts { get; set; }

        public MockRepository(string folderPath)
        {
            this.FolderPath = folderPath;
            LoadCategoriesAndProperties();
            LoadSecurities();
            LoadAccounts();
            LoadModels();

        }
        public MockRepository()
        {

            LoadCategoriesAndProperties();
            LoadSecurities();
            LoadAccounts();
            LoadModels();
        }

        private void LoadModels()
        {
            var modelsService = new FileDataServiceBase<Model>(FolderPath + MODELS_FILE_NAME);

            // populate Models dictionary
            this.Models = modelsService.GetAll().ToDictionary(x => x.Id, x => x);
        }

        private void LoadAccounts()
        {
            var accountsService = new FileDataServiceBase<Account>(FolderPath + ACCOUNTS_FILE_NAME);
           
            // populate Accounts dictionary
            this.Accounts = accountsService.GetAll().ToDictionary(x => x.Id, x => x);
        }

        private void LoadSecurities()
        {
            var securitiesService = new FileDataServiceBase<Security>(FolderPath + SECURITIES_FILE_NAME);
            // populate securities dictionary

            this.Securities = securitiesService.GetAll().ToDictionary(x => x.Id, x => x);

        }

        private void LoadCategoriesAndProperties()
        {
            var categoriesService = new FileDataServiceBase<Category>(FolderPath + CATEGORIES_FILE_NAME);
            this.Categories = ((List<Category>)categoriesService.GetAll()).ToDictionary(x => x.Id, x => x);

            // populate property dictionary
            var props = new Dictionary<int, PropertyDefinition>();
            foreach (var category in Categories.Values)
            {

                foreach(PropertyDefinition propDef in category.GetAllProperties())
                {
                    props[propDef.Id] = propDef;
                }
            }

            this.PropertyDefinitions = props;
        }


        public IList<PropertyDefinition> GetAllProperties()
        {
            throw new NotImplementedException();
        }

        public IList<IModel> Search(ISearchCondition condition)
        {
            throw new NotImplementedException();
        }

        public IList<IModel> Search(IList<IModel> models, ISearchCondition condition)
        {
            throw new NotImplementedException();
        }

        public IList<IModel> Search(IList<ISearchCondition> conditions)
        {
            throw new NotImplementedException();
        }

        public IList<IModel> Search(IList<IModel> models, IList<ISearchCondition> conditions)
        {
            throw new NotImplementedException();
        }

        public PropertyDefinition GetPropertyByName(string propertyName)
        {
            return PropertyDefinitions.Values.FirstOrDefault(a => a.PropertyName.Equals(propertyName));
        }

        public IList<IModel> SearchByNameAndValue(string propertyName, string propertyValue)
        {
            return Models.Values.Where(x =>
                x.ModelProperties.ContainsKey(propertyName)
                && x.ModelProperties[propertyName].Equals(propertyValue)).ToList<IModel>();
        }
    }
}
