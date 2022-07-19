using Mota.Game.Interact;
using Mota.Game.Role.Actor;
using Mota.Game.Role.NPC;
using Mota.Game.Util;

namespace Mota.Game.Logic;

public class StageManager : IAwake
{
    public World World;
    private int FinalStage { get; set; }
    private int Stage { get; set; }
    public void Awake()
    {
        Debug.Log($"{GetType().Name} Awake");
        Stage = 0;
        // Stage becomes 1 in the SetStage()
        SetStage();
        GetFinalStage();
    }

    public void SetStage()
    {
        Stage++;
        var stageName = "Stage" + Stage; // get the class name
        var stage = GetType().Assembly.CreateInstance
            ($"Mota.Game.Stage.{stageName}") as StageManager;
        var actorList = stage?.CreateActors();
        var npcList = stage?.CreateNpCs();
        World.Actors = actorList;
        World.NpCs = npcList;
        World.InteractDirectories = stage?.CreateInteractDirectories();
    }

    private void GetFinalStage()
    {
        var stages = Directory.GetFiles("../../../Game/Stage");
        var i = int.MinValue;
        foreach (var stage in stages)
        {
            if (!stage.StartsWith(@"../../../Game/Stage\Stage")) continue;
            var str = stage.TrimEnd('.', 'c', 's');
            var num = int.Parse(str.Last().ToString());
            if (num <= i) continue;
            FinalStage = num;
            i = num;
        }
    }
        
    public bool IsAtFinalStage()
    {
        return Stage == FinalStage;
    }
        
    //let Stage1,Stage2... to override this method
    protected virtual List<Actor> CreateActors()
    {
        return null;
    }
        
    protected virtual List<NPC> CreateNpCs()
    {
        return null;
    }
        
    protected virtual List<InteractDirectory> CreateInteractDirectories()
    {
        return null;
    }
}