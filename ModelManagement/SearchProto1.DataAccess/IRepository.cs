using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchProto1.Model
{
    public interface IRepository
    {
        Dictionary<int, Model> Models { get; set; }
        Dictionary<int, Category> Categories { get; set; }
        Dictionary<int, PropertyDefinition> PropertyDefinitions { get; set; }
        Dictionary<int, Security> Securities { get; set; }
        Dictionary<int, Account> Accounts { get; set; }

        IList<IModel> Search(ISearchCondition condition);
        IList<IModel> Search(IList<IModel> models, ISearchCondition condition);
        IList<IModel> Search(IList<ISearchCondition> conditions);
        IList<IModel> Search(IList<IModel> models, IList<ISearchCondition> conditions);
        IList<PropertyDefinition> GetAllProperties();

        IList<IModel> SearchByNameAndValue(string propertyName, string propeertyValue);

        PropertyDefinition GetPropertyByName(string propertyName);
        
    }
}
