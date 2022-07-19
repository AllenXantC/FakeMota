using Mota.Game.InputManagers;
using Mota.Game.Interact.Interacters;
using Mota.Game.Role.Actor;
using Mota.Game.Role.NPC;

namespace Mota.Game.Interact.InteractManagers;

public class SellManager : InteracterManager
{
    public override void InteractUpdate(InteractMessage interactMessage, 
        Role.Role player, Role.Role target, InteractRenderManager render)
    {
        var seller = target.AI.GetSeller();
        Sell(seller, player as Player, target as Shop, render);
    }

    private void Sell(Seller seller, Player player, Shop shop, 
        InteractRenderManager render)
    {
        render.RenderSellOpener(shop, seller);
        while (true)
        {
            GetSellInput(seller, out var index);
            if (IsLeaveShop(seller, index)) break;
            var product = seller.Products[index];
            // product needs to be the actual copy of the stuff chosen
            if (product is not { }) return;
            while (product.Coin > player.Coin)
                // judge whether player could afford the stuff chosen
            {
                render.RenderChooseSellOptionAgain(player);
                GetSellInput(seller, out index);
                if (IsLeaveShop(seller, index)) break;
                product = seller.Products[index];
            }
                
            if (IsLeaveShop(seller, index)) break;
            // supply the line 33, ensure the program could get
            // rid of the while (true)
            player.AddProduct(product);
            render.RenderSellSucceed(product, player);
        }
        render.RenderLeaveShop();
    }

    private static void GetSellInput(Seller seller, out int index)
    {
        InteractInputManager.GetSellInput(seller);
        index = InteractInputManager.SellInput - 1;
    }

    /// <summary>
    /// judge whether player decides to leave the shop
    /// </summary>
    /// <param name="seller"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    private static bool IsLeaveShop(Seller seller, int index)
    {
        return index == seller.Products.Count;
    }
}