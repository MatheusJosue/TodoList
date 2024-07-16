using Infrastructure.Data.Repositories.Interface;
using Model;
using Model.DTO;
using Service.Interface;

namespace Service.Implementation
{
    public class CardService(ICardRepository cardRepository, IAuthService authService) : ICardService
    {
        public async Task<Card> GetCardById(int cardId)
        {
            return await cardRepository.GetCardById(cardId);
        }

        public async Task<List<Card>> GetCardsByUserId(int userId)
        {
            var currentUser = await authService.GetCurrentUser();

            return await cardRepository.ListCardsByUserId(userId);
        }

        public async Task<Card> CreateCard(CreateCardDTO card)
        {
            var currentUser = await authService.GetCurrentUser();
            var newCard = new Card(card.Titulo, card.Descricao, currentUser.Nome, currentUser.Id, DateTime.Now, 0);

            return await cardRepository.CreateCard(newCard);
        }

        public async Task<int> UpdateCard(UpdateCardDTO updateCardDto)
        {
            var card = await cardRepository.UpdateCard(updateCardDto);
            User currentUser = await authService.GetCurrentUser();

            return await cardRepository.UpdateCard(updateCardDto);
        }

        public async Task<bool> RemoverCard(int cardId)
        {
            Task<Card> card = cardRepository.GetCardById(cardId);
            return await cardRepository.DeleteCard(cardId);
        }
    }
}
