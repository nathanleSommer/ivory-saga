using System;

namespace IvorySaga
{
    [Serializable]
    public class SagaNotFoundException : Exception
    {
        public SagaNotFoundException()
        {
        }

        public SagaNotFoundException(string id)
            : base(string.Format("Saga not found: {0}", id))
        {
        }
    }
}
