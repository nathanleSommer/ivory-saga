using System;

namespace IvorySaga.Api.DataTransferObjects.Saga.Chapter;

public sealed record ChapterResponse(string Content, DateTime CreatedAt, DateTime UpdatedAt);
