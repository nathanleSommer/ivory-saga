using System;

namespace IvorySaga.Api.DataTransferObjects.Saga.Chapter;

public sealed record ChapterResponse(
    Guid Id,
    string Content,
    DateTime CreatedAt,
    DateTime UpdatedAt);
