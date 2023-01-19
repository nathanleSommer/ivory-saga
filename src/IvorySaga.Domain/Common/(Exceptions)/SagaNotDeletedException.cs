using System;

namespace IvorySaga;

[Serializable]
public class SagaNotDeletedException : Exception
{
    public SagaNotDeletedException()
    {
    }

    public SagaNotDeletedException(string id)
        : base(string.Format("Saga {0} could not be deleted correctly.", id))
    {
    }
}
