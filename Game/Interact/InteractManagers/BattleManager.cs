using Mota.Game.InputManagers;
using Mota.Game.Interact.Interacters;
using Mota.Game.Role.Actor;
using Mota.Game.Util;

namespace Mota.Game.Interact.InteractManagers;

public class BattleManager : InteracterManager
{
    /// <summary>
    /// store whether the player attacks first in the round
    /// </summary>
    private bool _isPlayerFirst;
    public override void InteractUpdate(InteractMessage interactMessage, 
        Role.Role player, Role.Role target, InteractRenderManager render)
    {
        var battler = target.AI.GetBattler();
        if (battler == null)
            throw new ArgumentException
            ($"check the battler and the interactDirectory of " +
             $"the role {target} to see if they match");
        Battle(battler, player as Player, target as Enemy, render);
    }
        
    private void Battle(Battler battler, Player player, Enemy enemy, 
            InteractRenderManager render) 
        // the battler player and enemy use is the same
    {
        render.RenderBattleOpener(enemy);
        _isPlayerFirst = RandomUtil.Half();
        // the player has a 50% possibility to attack first
        while (player.Health > 0 && enemy.Health > 0)
        {
            render.RenderBattleItemOptions(battler.Skills, player);
            switch (_isPlayerFirst)
            {
                case true:
                {
                    render.RenderBattleOrder(player);
                    InteractInputManager.GetBattleInput(battler, player);
                    var i = InteractInputManager.BattleInput - 1;
                    if (i <= battler.Skills.Count - 1)
                    {
                        Console.WriteLine();
                        UseSkill(battler, player, enemy, i, render);
                    }
                    else
                    {
                        Console.WriteLine();
                        UseProduct(battler, player, i, render);
                    } 
                    break;
                }
                case false:
                {
                    render.RenderBattleOrder(enemy);
                    var i = RandomUtil.Range(1, battler.Skills.Count) - 1;
                    UseSkill(battler, enemy, player, i, render);
                    break;
                }
            }
        }
    }
        
    private void UseSkill(Battler battler, Actor attacker, Actor target, int i, 
        InteractRenderManager manager)
    {
        var skill = battler.Skills[i];
        var isRenderAttacker = skill.UseSkill(attacker, target);
        Thread.Sleep(1000);
        manager.RenderBattleInfo(attacker, skill);
        Thread.Sleep(1000);
        switch (target.Health)
        {
            case > 0:
                manager.RenderTargetInfo(isRenderAttacker ? attacker : target);
                _isPlayerFirst = !_isPlayerFirst;
                break;
            case <= 0:
                manager.RenderEnemyDeath(target);
                break;
        }
    }

    private void UseProduct(Battler battler, Player player, int i, 
        InteractRenderManager manager)
    {
        var product = player.GetProductsList()[i - battler.Skills.Count];
        product.UseProduct();
        // CheckPlayerProducts(player);
        Thread.Sleep(1000);
        manager.RenderBattleInfo(player, product);
        Thread.Sleep(1000);
        manager.RenderTargetInfo(player);
        _isPlayerFirst = !_isPlayerFirst;
    }

/*
    /// <summary>
    /// remove the minus-Num products of the player
    /// </summary>
    /// <param name="player"></param>
    private static void CheckPlayerProducts(Player player)
    {
        var products = player.GetProductsDictionary();
        var readyToBeRemovedProducts = 
            products.Where(product => product.Num <= 0).ToList();
        if (readyToBeRemovedProducts.Count == 0) return;
        foreach (var readyToBeRemovedProduct in readyToBeRemovedProducts)
        {
            player.RemoveProduct(readyToBeRemovedProduct);
        }
    }
*/
}