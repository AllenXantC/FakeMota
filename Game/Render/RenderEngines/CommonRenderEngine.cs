using System.Text;
using Mota.Game.Languages;
using Mota.Game.Logic;
using Mota.Game.Render.RenderInfo;
using Mota.Game.Role.Actor;
using Mota.Game.Texts.Interact;
using Mota.Game.Texts.Settings;
using Mota.Game.Util;

namespace Mota.Game.Render.RenderEngines;

public class CommonRenderEngine : RenderEngine
{
    private ulong _rowCount;
    private ulong _colCount;
    
    private ulong[,] _mapData;

    private IRenderIsInteract _isInteractRenderer;

    public void SetMapData(int rowCount, int colCount)
    {
        _rowCount = (ulong) rowCount;
        _colCount = (ulong) colCount;
        _mapData = new ulong[_rowCount, _colCount];
    }

    public void RenderPlayerInfo(Player player)
    {
        Console.WriteLine(player.ToString());
    }
        
    public void RenderMap(CommonRenderInfos commonRenderInfos)
    {
        Console.Title = "FakeMota";
        Debug.Log($"{GetType().Name} Update");
        for (var row = 0; row < (int) _rowCount; row++)
        {
            for (var col = 0; col < (int) _colCount; col++)
            {
                _mapData[row, col] = 0;
            }
        }
        var infos = commonRenderInfos.GetCommonRenderInfos();
        foreach (var renderInfo in infos)
        {
            var halfRowCount = (_rowCount - 1) / 2;
            var row = halfRowCount + (ulong) renderInfo.Pos.Y;
            var halfCowCount = (_colCount - 1) / 2;
            var col = halfCowCount + (ulong) renderInfo.Pos.X;
            _mapData[row, col] = renderInfo.RenderName;
        }
        const int charSpaceCount = 2;
        for (var row = 0; row < (int) _rowCount; row++)
        {
            var lastIndex = -1;
            for (var col = 0; col < (int) _colCount; col++)
            {
                var val = _mapData[row, col];
                if (val == 0) continue;
                var spaceCount = col - lastIndex - 1;
                lastIndex = col;
                var spaceStr = new string(' ', spaceCount * charSpaceCount);
                Console.Write(spaceStr);
                var sb = new StringBuilder();
                sb.Append(Convert.ToChar(val));
                sb.Append(' ',
                    LanguageManager.ELanguage == ELanguages.Chinese ? 
                        charSpaceCount - 2 : charSpaceCount - 1);
                var ch = sb.ToString();
                Console.Write(ch);
            }

            var endSpaceStr = new string(' ', ((int)_colCount - lastIndex - 1) * charSpaceCount);
            Console.Write(endSpaceStr);
            Console.Write('|');
            Console.WriteLine();
        }

        var endLineStr = new string('-', (int) (_colCount * charSpaceCount));
        Console.Write(endLineStr);
    }

    public void RenderExtraInfo()
    {
        Console.WriteLine(GameState.Instance.ToString());
    }
        
    public void RenderIsInteract(IsInteractRenderInfo info)
    {
        Console.WriteLine();
        // Console.Write($"The one near you is {info.Name}，");
        Console.Write(OutputText.TextWithLans["TheOneNear"] + $"{info.Name}" + (
            LanguageManager.ELanguage == ELanguages.Chinese ? "，" : ", "));
        var interactType = info.EInteracterType;
        _isInteractRenderer = GetType().Assembly.CreateInstance
            ("Mota.Game.Render.IsInteractRenderers." +
             $"{interactType.ToString()}" + "IsInteractRenderer")
            as IRenderIsInteract;
        if (_isInteractRenderer == null) throw new ArgumentException();
        _isInteractRenderer.RenderIsInteract(OutputText as AskInteractText);
        Console.WriteLine(OutputText.TextWithLans["Yes"]);
    }

    public static void RenderIsOpenSettings()
    {
        Console.WriteLine(AskIsOpenSettingsText.IsOpenSettings);
    }
    
    public override void Awake()
    {
        base.Awake();
        OutputText = new AskInteractText();
        // OriginalText = OutputText.Clone() as Text;
    }
}