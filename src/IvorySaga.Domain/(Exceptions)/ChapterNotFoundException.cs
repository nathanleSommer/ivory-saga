using System;

namespace IvorySaga
{
    [Serializable]
    public class ChapterNotFoundException : Exception
    {
        public ChapterNotFoundException()
        {
        }

        public ChapterNotFoundException(string sagaId, string chapterId)
            : base(string.Format("Chapter {0} not found for saga {1}.", sagaId, chapterId))
        {
        }
    }
}
