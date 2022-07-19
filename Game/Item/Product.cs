using Mota.Game.Languages;
using Mota.Game.Role.Actor;
using Mota.Game.Util;

namespace Mota.Game.Item;

public class Product : Item, IBind
{
    private Player _player;
    public readonly int Coin;
    /// <summary>
    /// the amount of Product instances player or shop has
    /// </summary>
    private readonly Action<Player> _useProduct;

    public Product(TextWithLan name, int coin, Action<Player> useProduct)
    {
        Name = name;
        Coin = coin;
        _useProduct = useProduct;
    }
        
    public void Bind(Role.Role role)
    {
        _player = role as Player;
    }

    public void Pay()
    {
        _player.Coin -= Coin;
    }

    public void UseProduct()
    {
        _useProduct(_player);
        _player.ConsumeProduct(this);
    }
}