using System;

namespace IvorySaga.Api.DataTransferObjects.Saga.Chapter;

public sealed record ChapterReference(Guid SagaId, Guid ChapterId);
