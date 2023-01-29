using System;
using AutoMapper;
using IvorySaga.Api.DataTransferObjects.Saga;
using IvorySaga.Api.DataTransferObjects.Saga.Author;
using IvorySaga.Api.DataTransferObjects.Saga.Chapter;
using IvorySaga.Application.Sagas.Commands;
using IvorySaga.Domain.Saga;
using IvorySaga.Domain.Saga.Entities;
using IvorySaga.Domain.Saga.ValueObjects;
using static IvorySaga.Application.Sagas.Commands.CreateSagaCommand;

namespace IvorySaga.Api.Mappers;

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
        CreateMap<AuthorModel, AuthorCommand>();
        CreateMap<Author, AuthorModel>();

        CreateMap<ChapterId, Guid>().ConvertUsing(src => src.Value);
        CreateMap<CreateChapterRequest, CreateChapterCommand>();
        CreateMap<UpdateChapterRequest, UpdateChapterCommand>();
        CreateMap<Chapter, ChapterResponse>();

        CreateMap<SagaId, Guid>().ConvertUsing(src => src.Value);
        CreateMap<CreateSagaRequest, CreateSagaCommand>();
        CreateMap<UpdateSagaRequest, UpdateSagaCommand>();
        CreateMap<Saga, SagaResponse>();
    }
}
