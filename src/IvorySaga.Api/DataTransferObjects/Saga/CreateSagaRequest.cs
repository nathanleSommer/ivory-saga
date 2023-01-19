using IvorySaga.Api.DataTransferObjects.Saga.Author;

namespace IvorySaga.Api.DataTransferObjects.Saga;

public sealed record CreateSagaRequest(string Title, AuthorModel Author);
