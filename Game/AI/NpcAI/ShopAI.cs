using Mota.Game.Interact.Interacters;

namespace Mota.Game.AI.NpcAI;

public class ShopAI : NpcAI
{
    /// <summary>
    /// instantiate a shop 
    /// </summary>
    /// <param name="talkers">
    /// </param>
    /// <param name="seller"></param>
    /// <param name="component"></param>
    public ShopAI(List<Talker> talkers, Seller seller, 
        List<Component.Component> component) : 
        base(talkers, seller, null, component)
    {
    }
}