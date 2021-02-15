using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IvorySaga.Mongo
{
    public class IvorySagaDatabaseSettings : IIvorySagaDatabaseSettings
    {
        public string SagasCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IIvorySagaDatabaseSettings
    {
        string SagasCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
