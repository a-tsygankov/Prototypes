using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchProto1.Model
{
    public interface IModel : IPersistable
    {
        string GetModelName();
        int GetModelId();
        string GetModelDescription();

        Dictionary<string, string> ModelProperties { get; set; }

        void SetProperty(string propertyName, string propertyValue);
    }
}
