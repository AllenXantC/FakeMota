using Mota.Game.Item;

namespace Mota.Game.Interact.Interacters;

/// <summary>
/// info of a pile of products
/// </summary>
public class Seller
{
    public readonly List<Product> Products;

    public Seller(List<Product> products)
    {
        Products = products;
    }
}