using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchProto1.Model
{
    public class Security : ISecurity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string FullName { get; set; }

        public int GetId()
        {
            return this.Id;
        }
    }

    public interface ISecurity : IPersistable
    {
    }
}
