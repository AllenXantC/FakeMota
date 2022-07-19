using Mota.Game.Examples;
using Mota.Game.Interact;
using Mota.Game.Logic;
using Mota.Game.Role.Actor;
using Mota.Game.Role.NPC;

namespace Mota.Game.Stage;

public class Stage1 : StageManager
{
    protected override List<Actor> CreateActors()
    {
        var actorList = new List<Actor>
        {
            RoleExamples.Csb,
            RoleExamples.Zbb
        };
        return actorList;
    }

    protected override List<NPC> CreateNpCs()
    {
        var npcList = new List<NPC>
        {
            RoleExamples.Gate,
            RoleExamples.Shop
        };
        return npcList;
    }

    protected override List<InteractDirectory> CreateInteractDirectories()
    {
        var interactDirectories = new List<InteractDirectory>(3)
        {
            InteractDirectoryExamples.ZbbInDir,
            InteractDirectoryExamples.ShopInDir,
            InteractDirectoryExamples.GateInDir
        };

        return interactDirectories;
    }
}