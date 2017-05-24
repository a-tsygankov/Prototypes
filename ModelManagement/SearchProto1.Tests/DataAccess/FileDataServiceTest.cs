using NUnit.Framework;
using SearchProto1.Model;
using SearchProto1.DataAccess;
using System.Collections.Generic;
using System.Reflection;
using NUnit.Framework.Internal;
using System.IO;
using System;

namespace SearchProto1.Tests.DataAccess
{
    [TestFixture()]
    class FileDataServiceTest
    {
        [OneTimeSetUp]
        public void AdjustPathForVSRunner()
        {
            System.IO.Directory.SetCurrentDirectory(TestContext.CurrentContext.WorkDirectory);
            Console.WriteLine("Current path: {0}", System.IO.Directory.GetCurrentDirectory());
        }


        [Test]
        public void SaveAndLoadAccountsTest()
        {
            List<Account> Accounts = new List<Account>
            {
                new Account{Id = -1, Name = "Test Account"},
                new Account{Id = -2, Name = "Barak Obama"},
                new Account{Id = -3, Name = "Croup Account 1"},
                new Account{Id = -4, Name = "Administrator"},
                new Account{Id = -5, Name = "Andrey"},
                new Account{Id = -6, Name = "Terminator"}
//                new Account{Id = , Name = ""},
            };

            IRepository rep = new MockRepository();

            var service = new FileDataServiceBase<Account>("accounts.json");

            if (File.Exists(service.FILENAME))
            {
                File.Delete(service.FILENAME);
            }
            // create if models file doesn't exist
            foreach (Account account in Accounts)
            {
                service.Save(account);
            }
            

        }

        [Test]
        public void SaveAndLoadSecuritiesTest()
        {
            List<Security> Securities = new List<Security>
            {
                new Security{Id = -1, Name = "USD", FullName = "Unites States Dollar"},
                new Security{Id = -2, Name = "T", FullName = "AT&T"},
                new Security{Id = -3, Name = "JWN", FullName = "Nordstrom"},
                new Security{Id = -4, Name = "MS", FullName = "Morgan Stanley"},
                new Security{Id = -5, Name = "NFLX", FullName = "NetFlix Inc."},
                new Security{Id = -6, Name = "MSFT", FullName = "Microsoft Corp."},
                new Security{Id = -7, Name = "COX", FullName = "Cox Communications"},
                new Security{Id = -8, Name = "AMR", FullName = "American Airlines"},
                new Security{Id = -9, Name = "AXP", FullName = "Amern Express Co"},
                new Security{Id = -10, Name = "EK", FullName = "Eastman Kodak"},
                new Security{Id = -11, Name = "DCX", FullName = "DaimlerChrysler AG"},
                new Security{Id = -12, Name = "INTC", FullName = "Intel Corp."},
                new Security{Id = -13, Name = "GM", FullName = "General Motors Corp."},
                new Security{Id = -14, Name = "F", FullName = "Ford Motor Co."},
                new Security{Id = -15, Name = "IBM", FullName = "International Business Machines"},
                new Security{Id = -16, Name = "WCOM", FullName = "MCI WorldCom, Inc."},
                new Security{Id = -17, Name = "SUNW", FullName = "Sun Microsystems, Inc."},
                new Security{Id = -18, Name = "LMT", FullName = "Lockheed Martin Corp"},
                new Security{Id = -19, Name = "SP500", FullName = "Standard & Poors 500"},
                new Security{Id = -20, Name = "ESP", FullName = "Spanish Peseta"},
                new Security{Id = -21, Name = "GBP", FullName = "British Pound Sterling"},
                new Security{Id = -21, Name = "ADBE", FullName = "Adobe Systems Inc"},
                new Security{Id = -22, Name = "ANF", FullName = "Abercrombie & Fitch Company A"},
//                new Security{Id = 1, Name = "", FullName = ""},
            };

            IRepository rep = new MockRepository();

            var service = new FileDataServiceBase<Security>("securities.json");

            if (File.Exists(service.FILENAME))
            {
                File.Delete(service.FILENAME);
            }
            // create if models file doesn't exist
            foreach (Security security in Securities)
            {
               service.Save(security);
            }
            
            //read and compare by model names
            var securitiesFromFile = service.GetAll();
            foreach (Security security in Securities)
            {
                bool matchFound = false;
                foreach (Security securityFromFile in securitiesFromFile)
                {
                    // do not compare Ids
                    if (security.Name.Equals(securityFromFile.Name))
                    {
                        matchFound = true;
                        break;
                    }
                }

                Assert.IsTrue(matchFound);
                Console.WriteLine("Security {0} is verified. ", security.Name);
            }

        }

        [Test]
        public void SaveAndLoadModelsTest()
        {
            List<IModel> models = new List<IModel>
            {
                new Model.Model{Id=-1, ModelName="Adv Sector1", ModelDescription="Adv Sector1Adv Sector1Adv Sector1Adv Sector1Adv Sector1Adv Sector1"},
                new Model.Model{Id=-2, ModelName="Protfolio model", ModelDescription="Protfolio modelProtfolio modelProtfolio modelProtfolio model"},
                new Model.Model{Id=-3, ModelName="model 100", ModelDescription="model 100model 100model 100model 100model 100model 100model 100model 100"},
                new Model.Model{Id=-4, ModelName="Gene's Model - 01", ModelDescription="Gene's Model - 01Gene's Model - 01Gene's Model - 01Gene's Model - 01Gene's Model - 01Gene's Model - 01"},
                new Model.Model{Id=-5, ModelName="Model123456", ModelDescription="Model123456Model123456Model123456Model123456Model123456"},
                new Model.Model{Id=-6, ModelName="Simple sector", ModelDescription="Simple sectorSimple sectorSimple sectorSimple sectorSimple sector"},
                new Model.Model{Id=-7, ModelName="Advanced sector - S&P500", ModelDescription="Advanced sector - S&P500Advanced sector - S&P500Advanced sector - S&P500Advanced sector - S&P500Advanced sector - S&P500Advanced sector - S&P500Advanced sector - S&P500"},
                new Model.Model{Id=-8, ModelName="Model 001", ModelDescription="Test model 001 for Model Search prototype.. "},
                new Model.Model{Id=-8, ModelName="Model 002", ModelDescription="Test model 002 for Model Search prototype.. "},
                new Model.Model{Id=-8, ModelName="Model 003", ModelDescription="Test model 003 for Model Search prototype.. "},
                new Model.Model{Id=-8, ModelName="Model 004", ModelDescription="Test model 004 for Model Search prototype.. "},
                new Model.Model{Id=-8, ModelName="Model 005", ModelDescription="Test model 005 for Model Search prototype.. "},
                new Model.Model{Id=-8, ModelName="Model 006", ModelDescription="Test model 006 for Model Search prototype.. "},
                new Model.Model{Id=-8, ModelName="Model 007", ModelDescription="Test model 007 for Model Search prototype.. "},
                new Model.Model{Id=-8, ModelName="Model 008", ModelDescription="Test model 008 for Model Search prototype.. "},
                new Model.Model{Id=-8, ModelName="Model 009", ModelDescription="Test model 009 for Model Search prototype.. "},
                new Model.Model{Id=-8, ModelName="S&P500", ModelDescription="S&P500S&P500S&P500S&P500S&P500S&P500S&P500S&P500S&P500S&P500S&P500"}

            };

           
            var testDir = TestContext.CurrentContext.TestDirectory;
            var workDir = TestContext.CurrentContext.WorkDirectory;
            var appWorkDir = AssemblyHelper.GetDirectoryName(Assembly.GetCallingAssembly());
            var effectiveDir = System.IO.Directory.GetCurrentDirectory();

            

            var service = new FileDataServiceBase<Model.Model>("models.json");

            if (File.Exists(service.FILENAME))
            {
                File.Delete(service.FILENAME);
            }
            // create if models file doesn't exist
            foreach (Model.Model model in models)
            {
                service.Save(model);
            }
            

            //read and compare by model names
            var modelsFromFile = service.GetAll();
            foreach(IModel model in models)
            {
                bool matchFound = false;
                foreach (IModel modelFromFile in modelsFromFile)
                {
                    // do not compare Ids
                    if(model.GetModelName().Equals(modelFromFile.GetModelName()))
                    {
                        matchFound = true;
                        break;
                    }
                }

                Assert.IsTrue(matchFound);
                Console.WriteLine("Model {0} is verified.", model.GetModelName());
            }
        }


        [Test]
        public void SaveAndLoadCategoriesTest()
        {

            var cat1Props = new List<PropertyDefinition>
            {
                new PropertyDefinition{Id = 1, PropertyName = "Model Name", Type = PropertyType.String},
                new PropertyDefinition{Id = 2, PropertyName = "Model Type", Type = PropertyType.Custom,
                    AcceptableValues = new List<string>
                    {
                        "Portfolio",
                        "Sector",
                        "Advanced Sector",
                        "Variance"
                    }
                },
                new PropertyDefinition{Id = 3, PropertyName = "Hierarchy", Type = PropertyType.Lookup},
                new PropertyDefinition{Id = 4, PropertyName = "Is Submodel", Type = PropertyType.Bool,
                    AcceptableValues = new List<string>
                    {
                        "Yes", "No", "Maybe"
                    }},
                new PropertyDefinition{Id = 5, PropertyName = "Target Type", Type = PropertyType.Custom,
                    AcceptableValues = new List<string>
                    {
                    }
                },
                new PropertyDefinition{Id = 6, PropertyName = "Benchmark", Type = PropertyType.Bool,
                    AcceptableValues = new List<string>
                    {
                        "Yes", "No", "Maybe"
                    }},
                new PropertyDefinition{Id = 7, PropertyName = "Lead Account", Type = PropertyType.Lookup},
                new PropertyDefinition{Id = 8, PropertyName = "Exclude Cash", Type = PropertyType.Bool,
                    AcceptableValues = new List<string>
                    {
                        "Yes", "No", "Maybe"
                    }}
            };
            var cat1 = new Category
            {
                Id = -1,
                categoryName = "General",
                SearchableProperties = cat1Props
            };
            var cat2Props = new List<PropertyDefinition>
            {
                new PropertyDefinition{Id = 11, PropertyName = "Note/Description", Type = PropertyType.String},
                new PropertyDefinition{Id = 12, PropertyName = "Security Used", Type = PropertyType.Lookup},
                new PropertyDefinition{Id = 13, PropertyName = "Account Default", Type = PropertyType.Lookup},
                new PropertyDefinition{Id = 14, PropertyName = "Submodel Used", Type = PropertyType.Lookup},
                new PropertyDefinition{Id = 15, PropertyName = "Overrides", Type = PropertyType.Bool,
                    AcceptableValues = new List<string>
                    {
                        "Yes", "No", "Maybe"
                    }
                }

            };
            var cat2 = new Category
            {
                Id = -1,
                categoryName = "Other",
                SearchableProperties = cat2Props
            };
            var cat3Props = new List<PropertyDefinition>
            {
                new PropertyDefinition{Id = 21, PropertyName = "Country", Type = PropertyType.Custom,
                    AcceptableValues = new List<string>
                    {
                        "USA",
                        "Mordor",
                        "United Kingdom",
                        "Russia",
                        "Galactic Empire"
                    }
                },
                new PropertyDefinition{Id = 22, PropertyName = "Security Level", Type = PropertyType.Custom,
                    AcceptableValues = new List<string>
                    {
                        "Secret",
                        "Top Secret",
                        "Super-Puper Top Secret",
                        "Destroy Before Using"
                    }
                },
                new PropertyDefinition{Id = 23, PropertyName = "Taxability", Type = PropertyType.Custom,
                    AcceptableValues = new List<string>
                    {
                        "Taxable",
                        "Not Taxable",
                        "Pretty Taxable",
                        "Maybe Taxable"
                    }
                },
                new PropertyDefinition{Id = 24, PropertyName = "Investment Option", Type = PropertyType.Custom,
                    AcceptableValues = new List<string>
                    {
                        "25%",
                        "50%",
                        "75%",
                        "90%"
                    }
                },
                new PropertyDefinition{Id = 25, PropertyName = "AAAA", Type = PropertyType.Custom,
                    AcceptableValues = new List<string>
                    {   
                        "aaaa",
                        "bbbb",
                        "cccc"
                    }
                },
                new PropertyDefinition{Id = 26, PropertyName = "Market Value", Type = PropertyType.Custom,
                    AcceptableValues = new List<string>
                    {
                        "High",
                        "Medium",
                        "Low"
                    }
                },
                new PropertyDefinition{Id = 27, PropertyName = "Draft", Type = PropertyType.Custom,
                    AcceptableValues = new List<string>
                    {
                        "Draft",
                        "Clean Copy"
                    }
                }
            };
            var cat3 = new Category
            {
                Id = -1,
                categoryName = "User Defined Properties",
                SearchableProperties = cat3Props
            };

            var cat0Props = new List<PropertyDefinition>
            {
                cat1Props[0],
                cat1Props[1],
                cat3Props[0],
                cat3Props[2],
                cat2Props[1],
                new PropertyDefinition{Id = 31, PropertyName = "Created", Type = PropertyType.Date}
            };

            var cat0 = new Category
            {
                Id = -1,
                categoryName = "Recent",
                SearchableProperties = cat0Props
            };

            var categories = new List<ICategory>
                {
                    cat0,
                    cat1,
                    cat2,
                    cat3
                };


            var workDir = TestContext.CurrentContext.WorkDirectory;
            var effectiveDir = System.IO.Directory.GetCurrentDirectory();



            var categoriesService = new FileDataServiceBase<Category>("categories.json");


            if (File.Exists(categoriesService.FILENAME))
            {
                File.Delete(categoriesService.FILENAME);
            }
            // create if models file doesn't exist
            foreach (Category cat in categories)
            {
                    categoriesService.Save(cat);
            }
            

            // read and compare by cat names and properties names
            foreach (Category cat in categoriesService.GetAll())
            {
                bool matchFound = false;
                foreach (Category catTest in categories)
                {
                    if (cat.categoryName.Equals(catTest.categoryName))
                    {
                        // compare properties
                        bool propMatchFound = false;

                        foreach (PropertyDefinition propTest in catTest.GetAllProperties())
                        {
                           
                            foreach(PropertyDefinition prop in cat.GetAllProperties())
                            {
                                if (propTest.getPropertyName().Equals(prop.getPropertyName()))
                                {
                                    propMatchFound = true;
                                    break;
                                }
                            }

                            if (!propMatchFound)
                            {
                                matchFound = false;
                                break;
                            }
                        }

                        if (propMatchFound)
                        {
                            matchFound = true;
                            break;
                        }
                    }
                }


                Assert.IsTrue(matchFound);
                Console.WriteLine("Category {0} is verified.", cat.categoryName);
            }
        }


    }

}
