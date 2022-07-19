#nullable enable
namespace Mota.Game.Util;

public interface IBind
{
    /// <summary>
    /// bind a component-like object to a role
    /// </summary>
    /// <param name="role"></param>
    public void Bind(Role.Role role);
}