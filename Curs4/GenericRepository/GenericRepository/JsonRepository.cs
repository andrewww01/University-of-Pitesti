using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using Newtonsoft.Json;

namespace GenericRepository
{
    //salvam pe disk in fisiere json cu numele dat de id-ul unic al obiectului
    internal class JsonRepository<T> : IRepository<T> where T : class, IEntity
    {
        public string RootFilePath { get; private set; }
        
        public JsonRepository()
        {
            var rootPathFromConfig = ConfigurationManager.AppSettings["RepositoryFolder"];

            if(string.IsNullOrEmpty(rootPathFromConfig))
            {
                rootPathFromConfig = "RepositoryData";
            }

            RootFilePath = Path.Combine(rootPathFromConfig, typeof(T).Name);

            if(!Directory.Exists(RootFilePath))
            {
                Directory.CreateDirectory(RootFilePath);
            }
        }
        
        public int Create(T entity)
        {
            var id = GetNextAvailableId();

            entity.Id = id;

            var jsonValue = JsonConvert.SerializeObject(entity);

            //save on disk
            File.WriteAllText(Path.Combine(RootFilePath, $"{id}.json"), jsonValue);

            return id;
        }

        public void Delete(int id)
        {
            if(Exists(id))
            {
                File.Delete(Path.Combine(RootFilePath, $"{id}.json"));
            }
        }

        public List<T> GetAll()
        {
            var result = new List<T>();

            var files = Directory.GetFiles(RootFilePath, "*.json");

            foreach(var file in files)
            {
                var jsonValue = File.ReadAllText(file);
                result.Add(JsonConvert.DeserializeObject<T>(jsonValue));
            }

            return result;
        }

        public T GetById(int id)
        {
            var fileName = Path.Combine(RootFilePath, $"{id}.json");

            if(File.Exists(fileName))
            {
                return JsonConvert.DeserializeObject<T>(File.ReadAllText(fileName));
            }

            return null;
        }

        public void Update(T entity)
        {
            if(Exists(entity.Id))
            {
                var jsonValue = JsonConvert.SerializeObject(entity);

                //save on disk
                File.WriteAllText(Path.Combine(RootFilePath, $"{entity.Id}.json"), jsonValue);
            }
        }

        private int GetNextAvailableId()
        {
            var existingIds = Directory
                .GetFiles(RootFilePath, "*.json")
                .Select(x => Path.GetFileNameWithoutExtension(x))
                .Select(x => int.Parse(x))
                .ToList();


            if (existingIds.Count == 0)
            {
                return 1;
            }

            return existingIds.Max() + 1;
        }

        public bool Exists(int id)
        {
            var fileName = Path.Combine(RootFilePath, $"{id}.json");

            return File.Exists(fileName);
        }
    }
}
