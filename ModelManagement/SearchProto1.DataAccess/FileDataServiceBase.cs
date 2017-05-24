using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchProto1.Model;
using Newtonsoft.Json;
using System.IO;

namespace SearchProto1.DataAccess 
{
    public class FileDataServiceBase<T> : IDataService<T> where T: IPersistable
    {
        public string FILENAME { get; private set; }

        public FileDataServiceBase(string fileName)
        {
            FILENAME = fileName;
        }
        public T GetById(int friendId)
        {
            var persistables = ReadFromFile();
            //List<T> persistables = ReadFromFile();
            return persistables.Single(f => f.GetId() == friendId);
        }

        public void Save(T persistable)
        {
            if (persistable.GetId() <= 0)
            {
                Insert(persistable);
            }
            else
            {
                Update(persistable);
            }
        }

        public void Delete(int Id)
        {
            var persistables = ReadFromFile();
            var existing = persistables.Single(f => f.GetId() == Id);
            persistables.Remove(existing);
            SaveToFile(persistables);
        }

        private void Update(T persistable)
        {
            var persistables = ReadFromFile();
            var existing = persistables.Single(f => f.GetId() == persistable.GetId());
            var indexOfExisting = persistables.IndexOf(existing);
            persistables.Insert(indexOfExisting, persistable);
            persistables.Remove(existing);
            SaveToFile(persistables);
        }

        private void Insert(T persistable)
        {
            var persistables = ReadFromFile();
            var maxPersistableId = persistables.Count == 0 ? 0 : persistables.Max(f => f.Id);
            persistable.Id = maxPersistableId + 1;
            persistables.Add(persistable);
            SaveToFile(persistables);
        }

        public IList<T> GetAll()
        {
            return ReadFromFile();
        }

        public void Dispose()
        {
            // Usually Service-Proxies are disposable. This method is added as demo-purpose
            // to show how to use an IDisposable in the client with a Func<T>. =>  Look for example at the FriendDataProvider-class
        }

        private void SaveToFile(List<T> persistableList)
        {
            string json = JsonConvert.SerializeObject(persistableList, Formatting.Indented);
            File.WriteAllText(FILENAME, json);
        }

        private List<T> ReadFromFile()
        {
            if (!File.Exists(FILENAME))
            {
                return new List<T>
                {
                };
            }

            string json = File.ReadAllText(FILENAME);
            return JsonConvert.DeserializeObject<List<T>>(json);
        }
    }


}

