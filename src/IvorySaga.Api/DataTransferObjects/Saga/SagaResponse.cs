using System;

namespace IvorySaga.Api.DataTransferObjects.Saga;

public record SagaResponse(
    Guid Id,
    string Title,
    AuthorResponse Author,
    DateTime CreatedAt,
    DateTime UpdatedAt);

public record AuthorResponse(string FirstName, string LastName);
