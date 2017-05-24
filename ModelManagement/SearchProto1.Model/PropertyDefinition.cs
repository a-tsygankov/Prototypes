using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchProto1.Model
{
    public class PropertyDefinition : IPropertyDefinition

    {
        public int Id { get; set; }
        public string PropertyName { get; set; }
        //public string DisplayName { get; set; }
        public PropertyType Type { get; set; }

        const string NOT_DEFINED = "Not Defined";

        private List<string> _AcceptableValues;

        public List<string> AcceptableValues
        {
            get
            {
                return _AcceptableValues;
            }
            set
            {
               
                _AcceptableValues = value;
                if (_AcceptableValues != null && !_AcceptableValues.Contains(NOT_DEFINED))
                    _AcceptableValues.Add(NOT_DEFINED);
            }
        }

        public int GetId()
        {
            return this.Id;
        }

        public string getPropertyName()
        {
            return this.PropertyName;
        }

        public PropertyType getPropertyType()
        {
            return this.Type;
        }

        public override string ToString()
        {
            return this.PropertyName;
        }

    }

    public interface IPropertyDefinition : IPersistable
    {
        string getPropertyName();
        PropertyType getPropertyType();
        List<string> AcceptableValues { get; set; }
    }

    public enum PropertyType {Number, Bool, String, Percent, Date, Custom, Lookup /* For securities, accounts and submodels*/ };


}
