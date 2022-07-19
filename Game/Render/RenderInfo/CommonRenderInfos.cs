namespace Mota.Game.Render.RenderInfo;

public class CommonRenderInfos
{
    private readonly List<CommonRenderInfo> _comRenderInfos = new();
    public void AddCommonRenderInfo(CommonRenderInfo commonRenderInfo)
    {
        _comRenderInfos.Add(commonRenderInfo);
    }
        
    public List<CommonRenderInfo> GetCommonRenderInfos()
    {
        return _comRenderInfos;
    }
}