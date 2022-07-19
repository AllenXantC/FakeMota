#nullable enable
using Mota.Game.Item;

namespace Mota.Game.Util;

public static class ExMethod
{
    public static bool ContainsProduct(this Dictionary<Product, int> dictionary,
        Product product, out Product? oriProduct)
    {
        foreach (var productNumPair in dictionary)
        {
            oriProduct = productNumPair.Key;
            if (oriProduct.Name == product.Name && oriProduct.Coin == product.Coin)
            {
                return true;
            }
        }

        oriProduct = null;
        return false;
    }
}