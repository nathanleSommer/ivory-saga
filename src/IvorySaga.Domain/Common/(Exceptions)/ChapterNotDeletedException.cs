using System;

namespace IvorySaga;

[Serializable]
public class ChapterNotDeletedException : Exception
{
    public ChapterNotDeletedException()
    {
    }

    public ChapterNotDeletedException(string sagaId, string chapterId)
        : base(string.Format("Chapter {0} of saga {1} could not be deleted correctly.", chapterId, sagaId))
    {
    }
}
