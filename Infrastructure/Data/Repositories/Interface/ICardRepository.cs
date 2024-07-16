using Model;
using Model.DTO;

namespace Infrastructure.Data.Repositories.Interface
{
    public interface ICardRepository
    {
        Task<Card> GetCardById(int cardId);
        Task<Card> CreateCard(Card card);
        Task<bool> DeleteCard(int cardId);
        Task<List<Card>> ListCardsByUserId(int userId);
        Task<int> UpdateCard(UpdateCardDTO card);
    }
}