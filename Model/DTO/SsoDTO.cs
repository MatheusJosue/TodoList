namespace Model.DTO
{
    public record struct SsoDTO(string Access_token, DateTime Expiration, User User);
}
