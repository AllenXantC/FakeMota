using Mota.Game.Texts;
using Mota.Game.Util;

namespace Mota.Game.Render.RenderEngines;

public class RenderEngine : TextUser
{
    public override void Awake()
    {
        Debug.Log($"{GetType().Name} Awake");
    }
}