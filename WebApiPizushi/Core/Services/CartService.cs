
using System.Diagnostics.Eventing.Reader;
using Core.Interfaces;
using Core.Models.Cart;
using Domain;
using Domain.Entities;

namespace Core.Services;

public class CartService(AppDbPizushiContext pizushiContext) : ICartService
{
    public async Task<long> CreateUpdate(CartCreateUpdateModel model, long userId)
    {
        var entity = pizushiContext.Carts
            .SingleOrDefault(x => x.UserId == userId && x.ProductId == model.ProductId);
        if (entity != null)
            entity.Quantity = model.Quantity;
        else
            entity = new CartEntity
            {
                UserId = userId,
                ProductId = model.ProductId,
                Quantity = model.Quantity
            };
        pizushiContext.Carts.Update(entity);
        await pizushiContext.SaveChangesAsync();
        return entity.ProductId;
    }
}
