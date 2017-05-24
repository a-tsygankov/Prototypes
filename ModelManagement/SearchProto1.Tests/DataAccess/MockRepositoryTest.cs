using NUnit.Framework;
using SearchProto1.Model;
using SearchProto1.DataAccess;
using System.Collections.Generic;
using System.Reflection;
using NUnit.Framework.Internal;
using System.IO;
using System;
using System.Linq;

namespace SearchProto1.Tests.DataAccess
{
    [TestFixture()]
    class MockRepositoryTest
    {

        [OneTimeSetUp]
        public void AdjustPathForVSRunner()
        {
            System.IO.Directory.SetCurrentDirectory(TestContext.CurrentContext.WorkDirectory);
            Console.WriteLine("Current path: {0}", System.IO.Directory.GetCurrentDirectory());
        }

        [Test]
        public void LoadRepositoryTest()
        {
            IRepository rep = new MockRepository();

            Assert.True(rep.Categories.Count > 0);
            Assert.True(rep.PropertyDefinitions.Count > 0);
            Assert.True(rep.Securities.Count > 0);
            Assert.True(rep.Accounts.Count > 0);
            Assert.True(rep.Models.Count > 0);

        }

        [Test]
        public void GetPropertyByNameTest()
        {
            IRepository rep = new MockRepository();

            Assert.IsNotNull(rep.GetPropertyByName("Model Name"));
            Assert.IsNotNull(rep.GetPropertyByName("Model Type"));
            Assert.IsNull(rep.GetPropertyByName("Model QWERT"));
            Assert.IsNull(rep.GetPropertyByName(null));

        }

        [Test]
        public void PropertyAcceptableValuesTest()
        {
            IRepository rep = new MockRepository();
            var countryProperty = rep.GetPropertyByName("Country");

            Assert.Contains("USA", countryProperty.AcceptableValues);
            Assert.Contains("Russia", countryProperty.AcceptableValues);
            CollectionAssert.DoesNotContain("Zimbabwe", countryProperty.AcceptableValues);
            Assert.Contains("Not Defined", countryProperty.AcceptableValues);

        }

        [Test]
        public void SaveRandomCustomPropertiesOnModelsTest()
        {
            IRepository rep = new MockRepository();
            var service = new FileDataServiceBase<Model.Model>("models.json");
            var defs = rep.PropertyDefinitions.Values.Where(x => 
                    (x.getPropertyType() == PropertyType.Custom || x.getPropertyType() == PropertyType.Bool));
            var rand = new System.Random();
            foreach (var model in rep.Models.Values)
            {
                model.ModelProperties["Model Name"] = model.ModelName;
                model.ModelProperties["Note/Description"] = model.ModelDescription;
                //model.ModelProperties["Model Name"] = model.ModelName;
                foreach (var def in defs)
                {
                    var count = def.AcceptableValues.Count();
                    
                    //model.SetProperty(def.PropertyName, def.AcceptableValues.Skip(rand.Next(count)).FirstOrDefault());
                    model.ModelProperties[def.PropertyName] = def.AcceptableValues.Skip(rand.Next(count)).FirstOrDefault();
                }

                model.ModelProperties["Created"] = DateTime.UtcNow.AddDays(-rand.Next(90)).ToShortDateString();


                service.Save(model);
            }

        }

       

        [Test]
        public void SearchByNameAndValueTest()
        {
            IRepository rep = new MockRepository();
            string name = rep.Models.Values.ElementAtOrDefault(1).ModelName;
            Assert.True(rep.SearchByNameAndValue("Model Name", name).Count == 1);

            string countryValue = rep.Models.Values.ElementAtOrDefault(1).ModelProperties["Country"];
            Assert.True(rep.SearchByNameAndValue("Country", countryValue).Count >= 1);
        }

    }

}
