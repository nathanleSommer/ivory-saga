namespace IvorySaga.Api.DataTransferObjects.Saga;

public record CreateSagaRequest(string Title, AuthorRequest Author);

public record AuthorRequest(string FirstName, string LastName);
