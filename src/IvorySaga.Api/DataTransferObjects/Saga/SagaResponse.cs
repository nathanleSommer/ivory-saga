using System;
using System.Collections.Generic;
using IvorySaga.Api.DataTransferObjects.Saga.Author;
using IvorySaga.Api.DataTransferObjects.Saga.Chapter;

namespace IvorySaga.Api.DataTransferObjects.Saga;

public sealed record SagaResponse(
    Guid Id,
    string Title,
    AuthorModel Author,
    List<ChapterResponse> Chapters,
    DateTime CreatedAt,
    DateTime UpdatedAt);
