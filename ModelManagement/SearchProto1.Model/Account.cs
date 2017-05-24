using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchProto1.Model
{
    public class Account : IAccount
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int GetId()
        {
            return this.Id;
        }
    }

    public interface IAccount : IPersistable
    {
    }
}
