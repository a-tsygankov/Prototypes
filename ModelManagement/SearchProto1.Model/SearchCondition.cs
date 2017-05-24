using System;

namespace SearchProto1.Model
{ 
    public class SearchCondition : ISearchCondition 
    {
        public IPropertyDefinition propertyDefinition { get; set; }
        public string propertyName { get; set; }
        public string value { get; set; }
        public bool IsIncluded { get; set; }
        public int Id { get; set; }

        public SearchCondition()
        {
        }

        public IPropertyDefinition GetProperty()
        {
            throw new NotImplementedException();
        }

        public IValue GetValue()
        {
            throw new NotImplementedException();
        }

        bool ISearchCondition.IsIncluded()
        {
            throw new NotImplementedException();
        }

        public int GetId()
        {
            throw new NotImplementedException();
        }
    }

    public interface ISearchCondition : IPersistable // We may need this for history
    {
        IPropertyDefinition GetProperty();
        IValue GetValue();
        bool IsIncluded();
    }
}
