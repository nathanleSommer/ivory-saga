using System;
using AutoMapper;
using IvorySaga.Api.DataTransferObjects.Saga;
using IvorySaga.Api.Models;
using IvorySaga.Application.Sagas.Commands;
using IvorySaga.Domain.Saga;
using IvorySaga.Domain.Saga.Entities;
using IvorySaga.Domain.Saga.ValueObjects;

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
            CreateMap<AuthorRequest, AuthorCommand>();
            CreateMap<CreateSagaRequest, CreateSagaCommand>();

            CreateMap<SagaId, Guid>().ConvertUsing(src => src.Value);
            CreateMap<Author, AuthorResponse>();
            CreateMap<Saga, SagaResponse>();

            CreateMap<Chapter, ChapterModel>();
        }
    }
}
