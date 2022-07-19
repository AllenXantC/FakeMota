using Mota.Game.InputManagers;
using Mota.Game.Interact;
using Mota.Game.Render.RenderEngines;
using Mota.Game.Render.RenderInfo;
using Mota.Game.Role.Actor;
using Mota.Game.Role.NPC;
using Mota.Game.Util;

namespace Mota.Game.Logic;

public class World : ILifeCycle
{
    private static readonly Vector2 XRange = new(-10, 10);
    private static readonly Vector2 YRange = new(-10, 10);
    private readonly CommonRenderEngine _commonRenderEngine = new();
    public bool IsInteract;
    public bool IsOpenSettings;
    public List<InteractDirectory> InteractDirectories = new();
    public List<Actor> Actors = new();
    public Player Player;
    public readonly int[] ActorsCount = new int[(int) EActorType.EnumCount]; // 记录Actors中不同Actor子类对象的个数
    private readonly List<Actor> _deadActors = new();
    public List<NPC> NpCs = new();

    public void CommonRender()
    {
        Console.Clear();
        _commonRenderEngine.RenderPlayerInfo(GetPlayerRenderInfo());
        Console.WriteLine();
        _commonRenderEngine.RenderMap(GetCommonRenderInfo());
        Console.WriteLine();
        _commonRenderEngine.RenderExtraInfo();
    }

    private void RenderIsInteract(IsInteractRenderInfo info)
    {
        _commonRenderEngine.RenderIsInteract(info);
    }

    /// <summary>
    /// this method is only used for printing things (like "Open Settings?")
    /// to hint the player that settings exists
    /// </summary>
    private void RenderIsOpenSettings()
    {
        CommonRenderEngine.RenderIsOpenSettings();
    }
    
    private Role.Role FindNearRole(Player player)
        // find the player which is close to the role (dist < sqrt(2))
    {
        foreach (var actor1 in Actors)
        {
            if (actor1.Health <= 0 || actor1.Type == player.Type)
            {
                continue;
            }
            if (player.Pos.IsNear(actor1.Pos))
            {
                return actor1;
            }
        }
        foreach (var npc in NpCs)
        {
            if (player.Pos.IsNear(npc.Pos))
            {
                return npc;
            }
        }
        return null;
    }
        
    private CommonRenderInfos GetCommonRenderInfo()
    {
        var infos = new CommonRenderInfos();
        foreach (var info in Actors.Select(actor => 
                     new CommonRenderInfo {Pos = actor.Pos, 
                         RenderName = actor.RenderName.ToChar()}))
        {
            infos.AddCommonRenderInfo(info);
        }
        foreach (var info in NpCs.Select(npc =>
                     new CommonRenderInfo {Pos = npc.Pos, 
                         RenderName = npc.RenderName.ToChar()}))
        {
            infos.AddCommonRenderInfo(info);
        }
        return infos;
    }

    private static IsInteractRenderInfo GetIsInteractRenderInfo(Role.Role role)
    {
        var info = new IsInteractRenderInfo
            {Name = role.Name, EInteracterType = role.EInteracterType};
        return info;
    }
        
    private Player GetPlayerRenderInfo()
    {
        return Player;
    }

    private Player GetPlayer()
    {
        foreach (var actor in Actors)
        {
            if (actor is Player player)
            {
                return player;
            }
        }
        return null;
    }

    private void OnCreateActor(Actor actor)
    {
        ActorsCount[actor.Type]++;
    }

    private void OnDestroyActor(Actor actor)
    {
        ActorsCount[actor.Type]--;
    }

    private bool IsPlayerNearRole()
    {
        return FindNearRole(Player) != null;
    }
        
    public void AskIsInteract()
    {
        if (!IsPlayerNearRole()) return;
        var role = FindNearRole(Player);
        var info = GetIsInteractRenderInfo(role);
        RenderIsInteract(info);
        IsInteract = IsInteractInputManager.IsInteractDetectInput;
    }

    public void AskIsOpenSettings()
    {
        RenderIsOpenSettings();
        IsOpenSettings = IsOpenSettingsInputManager.IsOpenSettings;
    }
    
    public static Vector2 GetRandomPos()
    {
        var x = RandomUtil.Range(XRange.X, XRange.Y);
        var y = RandomUtil.Range(YRange.X, YRange.Y);
        return new Vector2(x, y);
    }
        
    public static Vector2 GetValidPos(Vector2 pos)
    {
        if (pos.X < XRange.X) pos.X = XRange.X;
        if (pos.X > XRange.Y) pos.X = XRange.Y;
        if (pos.Y < YRange.X) pos.Y = YRange.X;
        if (pos.Y > YRange.Y) pos.Y = YRange.Y;
        return pos;
    }

    public bool IsAllEnemyDie()
    {
        return !Actors.OfType<Enemy>().Any();
    }

    private void SetPlayer()
    {
        Player = GetPlayer();
        // Player.AI.Bind(Player);
    }
        
    public void Awake()
    {
        Debug.Log($"{GetType().Name} Awake");
        _commonRenderEngine.SetMapData(
            YRange.Y - YRange.X + 1, XRange.Y - XRange.X + 1);
        _commonRenderEngine.Awake();
        SetPlayer();
        Actors.ForEach(actor =>
        {
            actor.Awake();
            OnCreateActor(actor);
        });
        NpCs.ForEach(npc =>
        {
            npc.Awake();
        });
    }

    public void AwakeActorAndNpc()
    {
        Actors.ForEach(actor =>
        {
            actor.Awake();
            OnCreateActor(actor);
        });
        NpCs.ForEach(npc =>
        {
            npc.Awake();
        });
    }
    
    public void Update()
    {
        Debug.Log($"{GetType().Name} Update");
        Actors.ForEach(actor =>
        {
            actor.Update();
        });
        _deadActors.Clear();
        foreach (var actor in Actors.Where(actor => actor.Health <= 0))
        {
            if (actor is Enemy enemy)
            {
                Player.Exp += enemy.Exp;
                Player.Coin += enemy.Coin;
                GameState.Instance.Score += enemy.Score;
            }
            _deadActors.Add(actor);
        }
        foreach (var deadActor in _deadActors)
        {
            OnDestroyActor(deadActor);
            Actors.Remove(deadActor);
        }
        NpCs.ForEach(npc =>
        {
            npc.Update();
        });
    }
        
    public void SetInteractInformation(InteractController interactController, 
        Action setStage, Func<bool> isEnemyAllDie)
    {
        interactController.Set(
            Player, FindNearRole(Player), InteractDirectories,
            isEnemyAllDie, setStage);
    }
}