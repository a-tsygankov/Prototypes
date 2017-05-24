using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchProto1.Model
{
    public class Value : IValue
    {
        public string StringValue { get; set; }
        public int Id { get; set; }

        public int GetId()
        {
            return Id;
        }

        public string GetStringValue()
        {
            return this.StringValue;
        }

        public bool IsNotDefined()
        {
            throw new NotImplementedException();
        }
    }

    public interface IValue : IPersistable
    {
        string GetStringValue();
        bool IsNotDefined();
    }
}
