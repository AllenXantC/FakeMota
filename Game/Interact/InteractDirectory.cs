using Mota.Game.Languages;

namespace Mota.Game.Interact;

/// <summary>
/// the holistic interact information between player and a non-player role
/// </summary>
public class InteractDirectory
{
    /// <summary>
    /// store the order of interacting, who goes first and whatever
    /// </summary>
    public Queue<InteractMessage> InteractMessages;
    
    /// <summary>
    /// the name of the non-player role
    /// </summary>
    public readonly TextWithLan RoleName;

    public InteractDirectory(Queue<InteractMessage> interactMessages, 
        TextWithLan roleName)
    {
        InteractMessages = interactMessages;
        RoleName = roleName;
    }
}