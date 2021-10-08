using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IvorySaga
{
    [Serializable]
    public class ChapterNotCreatedException : Exception
    {
        public ChapterNotCreatedException() { }

        public ChapterNotCreatedException(string sagaId, string chapterId, Exception innerException)
            : base(string.Format("Chapter {0} could not be created for Saga {1}. {2}", chapterId, sagaId, innerException.Message))
        {

        }
    }
}
