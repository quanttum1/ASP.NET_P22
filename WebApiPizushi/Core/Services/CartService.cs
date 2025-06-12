
using System.Diagnostics.Eventing.Reader;
using Core.Interfaces;
using Core.Models.Cart;
using Domain;
using Domain.Entities;

namespace Core.Services;

public class CartService(AppDbPizushiContext pizushiContext, IAuthService authService) : ICartService
{
    public async Task CreateUpdate(CartCreateUpdateModel model)
    {
        var userId = await authService.GetUserId();
        var entity = pizushiContext.Carts
            .SingleOrDefault(x => x.UserId == userId && x.ProductId == model.ProductId);
        if (entity != null)
            entity.Quantity = model.Quantity;
        else
        {
            entity = new CartEntity
            {
                UserId = userId,
                ProductId = model.ProductId,
                Quantity = model.Quantity
            };
            pizushiContext.Carts.Add(entity);
        }
        await pizushiContext.SaveChangesAsync();
    }
}
