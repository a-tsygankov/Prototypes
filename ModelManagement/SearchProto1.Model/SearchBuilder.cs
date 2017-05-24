using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchProto1.Model
{
    class SearchBuilder : ISearchBuilder
    {
        public int Id{ get; set; }
        public IEnumerable<ISearchCondition> conditions { get; set; }

        public IEnumerable<ISearchCondition> GetAllConditions()
        {
            return this.conditions;
        }

        public int GetId()
        {
            return this.Id;
        }
    }

    internal interface ISearchBuilder : IPersistable
    {
        IEnumerable<ISearchCondition> GetAllConditions();
    }
}
