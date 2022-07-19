using Mota.Game.Interact.Interacters;
using Mota.Game.Item;
using Mota.Game.Render.RenderEngines;
using Mota.Game.Render.RenderEngines.InteractRenderEngines;
using Mota.Game.Role.Actor;
using Mota.Game.Role.NPC;
using Mota.Game.Texts.Interact;

namespace Mota.Game.Interact;

public class InteractRenderManager : RenderEngine
{
    private readonly TalkRenderEngine _talkRender = new();
    private readonly BattleRenderEngine _battleRender = new();
    private readonly SellRenderEngine _sellRenderEngine = new();
    private readonly StageChangeRenderEngine _stageChangeRenderEngine = new();

    /// <summary>
    /// this method has to be static because InteractInputManager needs it
    /// without having its instance
    /// </summary>
    public static void RenderInvalidInput()
    {
        Console.WriteLine();
        Console.WriteLine(InvalidInputText.InvalidInput);
    }
    
    #region Talk    
        
    public void RenderTalk(Role.Role role, Talker talker)
    {
        _talkRender.RenderTalk(role, talker);
    }
        
    #endregion
        
    #region Battle
    public void RenderBattleOpener(Role.Role role)
    {
        _battleRender.RenderBattleOpener(role);
    }

    public void RenderBattleOrder(Role.Role role)
    {
        _battleRender.RenderBattleOrder(role);
    }

    public void RenderBattleItemOptions(List<Skill> skills, Player player)
    {
        _battleRender.RenderBattleItemOptions(skills, player);
    }

    public void RenderBattleInfo(Actor actor, Item.Item item)
    {
        _battleRender.RenderBattleInfo(actor, item);
    }

    public void RenderTargetInfo(Actor target)
    {
        _battleRender.RenderTargetInfo(target);
    }

    public void RenderEnemyDeath(Actor enemy)
    {
        _battleRender.RenderEnemyDeath(enemy);
    }

    #endregion
        
    #region Sell

    public void RenderSellOpener(Shop shop, Seller seller)
    {
        _sellRenderEngine.RenderSellOpener(shop, seller);
    }

    public void RenderChooseSellOptionAgain(Player player)
    {
        _sellRenderEngine.RenderChooseSellOptionAgain(player);
    }
        
    public void RenderSellSucceed(Product product, Player player)
    {
        _sellRenderEngine.RenderSellSucceed(product, player);
    }

    public void RenderLeaveShop()
    {
        _sellRenderEngine.RenderLeaveShop();
    }
        
    #endregion
        
    #region ChangStage

    public void RenderCannotGoToNextStage()
    {
        _stageChangeRenderEngine.RenderCannotGoToNextStage();
    }

    #endregion

    public override void Awake()
    {
        base.Awake();
        _talkRender.Awake();
        _battleRender.Awake();
        _sellRenderEngine.Awake();
        _stageChangeRenderEngine.Awake();
    }
}