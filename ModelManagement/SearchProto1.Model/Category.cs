using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchProto1.Model
{
    public class Category : ICategory
    {
        public int Id { get; set; }
        public string categoryName { get; set; }

        public List<PropertyDefinition> SearchableProperties = new List<PropertyDefinition>();
        public IEnumerable<IPropertyDefinition> GetAllProperties()
        {
            return SearchableProperties;
        }

        public void AddProperty(PropertyDefinition prop)
        {
            SearchableProperties.Add(prop);
        }



        public void SetProperties(List<PropertyDefinition> properties)
        {
            this.SearchableProperties = properties;
        }

        public int GetId()
        {
            return this.Id;
        }
        public override string ToString()
        {
            return this.categoryName;
        }

    }

    public interface ICategory : IPersistable
    {

        IEnumerable<IPropertyDefinition> GetAllProperties();
        void AddProperty(PropertyDefinition prop);
        void SetProperties(List<PropertyDefinition> properties);
    }
}
