using Model;
using Model.DTO;

namespace Service.Interface
{
    public interface ICardService
    {
        Task<Card> CreateCard(CreateCardDTO card);
        Task<Card> GetCardById(int cardId);
        Task<List<Card>> GetCardsByUserId(int userId);
        Task<bool> RemoverCard(int cardId);
        Task<int> UpdateCard(UpdateCardDTO updateCardDto);
    }
}