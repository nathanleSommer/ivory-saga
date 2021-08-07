using AutoMapper;
using IvorySaga.Api.Models;
using IvorySaga.Data;

namespace IvorySaga.Api.Mappers
{
    /// <summary>
    /// Contains mapping profiles for the whole assembly.
    /// We may split it into multiple profiles later on.
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MappingProfile"/> class.
        /// </summary>
        public MappingProfile()
        {
            CreateMap<Saga, SagaModel>();
            CreateMap<Chapter, ChapterModel>();
        }
    }
}
