using Infrastructure.Data.Repositories.Interface;
using Infrastructure.Data.Repositories.Interface.Context;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.DTO;

namespace Infrastructure.Data.Repositories.Implementation
{
    public class CardRepository(MySQLContext context) : ICardRepository
    {
        public async Task<Card> GetCardById(int cardId)
        {
            return await context.Card.FindAsync(cardId) ?? throw new ArgumentException("Não foi encontrado nenhum card com esse Id.");
        }

        public async Task<List<Card>> ListCardsByUserId(int userId)
        {
            return await context.Card.Where(x => x.OwnerId.Equals(userId)).ToListAsync();
        }

        public async Task<Card> CreateCard(Card card)
        {
            var newCard = await context.Card.AddAsync(card);

            await context.SaveChangesAsync();

            newCard.State = EntityState.Detached;

            return newCard.Entity;
        }

        public async Task<int> UpdateCard(UpdateCardDTO card)
        {
            context.Entry(card).State = EntityState.Modified;
            return await context.SaveChangesAsync();
        }

        public async Task<bool> DeleteCard(int cardId)
        {
            Card card = await context.Card.FindAsync(cardId) ?? throw new ArgumentException("Card não encontrado.");
            context.Remove(card);

            await context.SaveChangesAsync();

            return true;
        }
    }
}
