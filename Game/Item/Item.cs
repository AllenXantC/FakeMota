using Mota.Game.Languages;

namespace Mota.Game.Item;

/// <summary>
/// make this class the father of the class Product and Skill is to
/// let them share the field Name, which is used in the class 
/// InteractRenderEngine
/// </summary>
public class Item
{
    public TextWithLan Name;
}