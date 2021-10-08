using System;

namespace IvorySaga
{
    [Serializable]
    public class SagaNotCreatedException : Exception
    {
        public SagaNotCreatedException() { }

        public SagaNotCreatedException(string id, Exception innerException)
            : base(string.Format("Saga {0} could not be created. {1}", id, innerException.Message))
        {

        }
    }
}
