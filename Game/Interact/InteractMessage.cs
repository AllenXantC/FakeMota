using Mota.Game.Interact.InteractManagers;
using Mota.Game.Languages;

namespace Mota.Game.Interact;

public class InteractMessage
{
    /// <summary>
    /// the name of the non-player role
    /// </summary>
    public readonly TextWithLan RoleName;
    
    /// <summary>
    /// decide what kind of interact it'll be
    /// </summary>
    public readonly EInteractManagerType EInteractManagerType;
    
    /// <summary>
    /// which element it is (only) in Talkers
    /// </summary>
    public readonly int Order;

    public InteractMessage(TextWithLan roleName, EInteractManagerType eType, 
        int order)
    {
        RoleName = roleName;
        EInteractManagerType = eType;
        Order = order;
    }
}