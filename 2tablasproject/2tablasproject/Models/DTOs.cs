namespace tablasproject.Models
{
    public record PersonalDataDto(int PersonalId, string FirstName, string LastName, string Gender, string Language, int CardIndexId);
    public record CreatePersonalDataDto(string FirstName, string LastName, string Gender, string Language, int CardIndexId);
    public record UpdatePersonalDataDto(string FirstName, string LastName, string Gender, string Language, int CardIndexId);

    public record CardDto(int CardId, int CardNumber, string CardTypeName, string CurrencyName, int CurrencyAmmount);
    public record CreateCardDto(int CardNumber, string CardTypeName, string CurrencyName, int CurrencyAmmount);
    public record UpdateCardDto(int CardNumber, string CardTypeName, string CurrencyName, int CurrencyAmmount);
}
