using Mota.Game.Role.Actor;
using Mota.Game.Util;

namespace Mota.Game.AI.Component.Level;

public class Level : IBind
{
    protected Player Player;
    /// <summary>
    /// the level changes when exp >= ExpUpperBound
    /// </summary>
    public virtual int ExpUpperBound => 0;

    /// <summary>
    /// change the properties when player was upgraded to the next level,
    /// for example, the override of Level1.cs is the changes that will be made
    ///              when player's level becomes 2
    /// </summary>
    public virtual void ChangeProperties()
    {
            
    }

    public void Bind(Role.Role role)
    {
        Player = role as Player;
    }
}