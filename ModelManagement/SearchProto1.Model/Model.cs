using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SearchProto1.Model
{
    public class Model : IModel
    {
        public int Id { get; set; }
        public string ModelName { get; set; }
        public string  ModelDescription { get; set; }

       
        [JsonIgnore]
        public string Created { get { return ModelProperties["Created"] ?? "Not Defined"; } }

        [JsonIgnore]
        public string ModelType { get { return ModelProperties["Model Type"] ?? "Not Defined"; } }

        [JsonIgnore]
        public string IsSubmodel { get { return ModelProperties["Is Submodel"] ?? "Not Defined"; } }

        [JsonIgnore]
        public string Taxability { get { return ModelProperties["Taxability"] ?? "Not Defined"; } }

        [JsonIgnore]
        public string Country { get { return ModelProperties["Country"] ?? "Not Defined"; } }

        [JsonIgnore]
        public string Benchmark { get { return ModelProperties["Benchmark"] ?? "Not Defined"; } }

        [JsonIgnore]
        public string ExcludeCash { get { return ModelProperties["Exclude Cash"] ?? "Not Defined"; } }

        [JsonIgnore]
        public string Overrides { get { return ModelProperties["Overrides"] ?? "Not Defined"; } }

        [JsonIgnore]
        public string SecurityLevel { get { return ModelProperties["Security Level"] ?? "Not Defined"; } }

        [JsonIgnore]
        public string InvestmentOption { get { return ModelProperties["Investment Option"] ?? "Not Defined"; } }

        [JsonIgnore]
        public string MarketValue { get { return ModelProperties["Market Value"] ?? "Not Defined"; } }

        [JsonIgnore]
        public string Draft { get { return ModelProperties["Draft"] ?? "Not Defined"; } }


        private Dictionary<string, string> _ModelProperties;
        public Dictionary<string, string> ModelProperties
        {
            get
            {
                if (_ModelProperties == null)
                    _ModelProperties =  new Dictionary<string, string>();
                return _ModelProperties;
            }
            set
            {
                _ModelProperties = value;
                AssignModelProperties();
            } 
        }

        public string this[string key]
        {
            get { return _ModelProperties[key]; }
            set { _ModelProperties[key] = value == null ? null : value.Trim(); }
        }

        private void AssignModelProperties()
        {

            //throw new NotImplementedException();
        }

        public int GetId()
        {
            return this.Id;
        }

        public string GetModelDescription()
        {
            return this.ModelDescription;
        }

        public int GetModelId()
        {
            return this.Id;
        }

        public string GetModelName()
        {
            return this.ModelName;
        }

        public void SetProperty(string propertyName, string propertyValue)
        {
            if (ModelProperties == null)
            {
                ModelProperties = new Dictionary<string, string>
                {
                    { propertyName, propertyValue }
                };
            }

            //TODO: Add value verification
        }
    }

    //public class ModelProperty
    //{
    //    const string MODEL_NAME_PROPERTY = "Model Name";
    //    const string MODEL_DESCRIPTION_PROPERTY = "";
    //    const string MODEL_TYPE_PROPERTY = "";
    //    const string MODEL_CREATED_PROPERTY = "";
    //    const string MODEL_COUNTRY_PROPERTY = "";
    //    const string MODEL__PROPERTY = "";
    //    const string MODEL__PROPERTY = "";
    //    const string MODEL__PROPERTY = "";
    //    const string MODEL__PROPERTY = "";
    //}
}
