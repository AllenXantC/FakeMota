using Mota.Game.AI.ActorAI;
using Mota.Game.AI.Component;
using Mota.Game.AI.Component.Level;
using Mota.Game.AI.NpcAI;
using Mota.Game.Interact.Interacters;
using Mota.Game.Item;
using Mota.Game.Role.Actor;
using Mota.Game.Role.NPC;
using Mota.Game.Texts.Interact;
using Mota.Game.Texts.Role;

namespace Mota.Game.Examples;

public static class RoleExamples
{
    private static readonly NameText NameText = new();
    private static readonly RenderNameText RenderNameText = new();
    private static readonly TalkText TalkText = new();
    private static readonly SkillNameText SkillNameText = new();
    private static readonly ProductNameText ProductNameText = new();
    
    public static readonly Player Csb = new(NameText.TextWithLans["Csb"], 
        RenderNameText.TextWithLans["Csb"], 200, 30, 30,
        new PlayerAI(
            new List<Talker>
            {
                new(TalkText.TextWithLans["Csb0"])
            },
            new List<Component>
            {
                new LevelController()
            }
        ),
        EInteracterType.None, 0, 1000);

    public static readonly Enemy Zbb = new(NameText.TextWithLans["Zbb"],
        RenderNameText.TextWithLans["Zbb"], 10, 20,
        30, 20, 20, 10,
        new EnemyAI(
            new List<Talker>
            {
                new(TalkText.TextWithLans["Zbb0"])
            },
            new Battler
            (new List<Skill>
            {
                new(SkillNameText.TextWithLans["GA"], 
                    (attacker, target) =>
                    // attack algorithm
                {
                    // calculate the difference between dodges
                    var dodgeDiff = attacker.Dodge - target.Dodge;
                    target.Health -= dodgeDiff switch
                    {
                        >= 0 => attacker.Damage,
                        < 0 => attacker.Damage * 
                               (1 + (double)dodgeDiff / target.Dodge)
                    };
                    return false;
                    // print the info of the attacker if return true
                    // print the info of the target if return false
                }),
                new(SkillNameText.TextWithLans["DOE"], 
                    (attacker, _) =>
                {
                    attacker.Dodge += 15;
                    return true;
                }),
                new(SkillNameText.TextWithLans["DAE"], 
                    (attacker, _) =>
                {
                    attacker.Damage += 15;
                    return true;
                })
            }), null),
        EInteracterType.Battle);

    public static readonly Enemy Gxq = new(NameText.TextWithLans["Gxq"],
        RenderNameText.TextWithLans["Gxq"], 10, 25,
        25, 30, 30, 10,
        new EnemyAI(
            new List<Talker>
            {
                new(TalkText.TextWithLans["Gxq0"])
            },
            new Battler(new List<Skill>
            {
                new(SkillNameText.TextWithLans["GA"], 
                    (attacker, target) =>
                    // attack algorithm
                {
                    // calculate the difference between dodges
                    var dodgeDiff = attacker.Dodge - target.Dodge;
                    target.Health -= dodgeDiff switch
                    {
                        >= 0 => attacker.Damage,
                        < 0 => attacker.Damage * 
                               (1 + (double)dodgeDiff / target.Dodge)
                    };
                    return false;
                    // print the info of the attacker if return true
                    // print the info of the target if return false
                }),
                new(SkillNameText.TextWithLans["DOE"], 
                    (attacker, _) =>
                {
                    attacker.Dodge += 25;
                    return true;
                }),
                new(SkillNameText.TextWithLans["DAE"], 
                    (attacker, _) =>
                {
                    attacker.Damage += 25;
                    return true;
                })
            }), null),
        EInteracterType.Battle);

    public static readonly Enemy Khrushchev = new(NameText.TextWithLans["Khrushchev"],
        RenderNameText.TextWithLans["Khrushchev"], 200, 25,
        25, 30, 30, 10,
        new EnemyAI(
            new List<Talker>
            {
                new(TalkText.TextWithLans["Khrushchev0"])
            },
            new Battler(new List<Skill>
            {
                new(SkillNameText.TextWithLans["GA"], 
                    (attacker, target) =>
                        // attack algorithm
                    {
                        // calculate the difference between dodges
                        var dodgeDiff = attacker.Dodge - target.Dodge;
                        target.Health -= dodgeDiff switch
                        {
                            >= 0 => attacker.Damage,
                            < 0 => attacker.Damage * 
                                   (1 + (double)dodgeDiff / target.Dodge)
                        };
                        return false;
                        // print the info of the attacker if return true
                        // print the info of the target if return false
                    }),
                new(SkillNameText.TextWithLans["DOE"], 
                    (attacker, _) =>
                    {
                        attacker.Dodge += 25;
                        return true;
                    }),
                new(SkillNameText.TextWithLans["DAE"], 
                    (attacker, _) =>
                    {
                        attacker.Damage += 25;
                        return true;
                    })
            }), null),
        EInteracterType.Battle);
    
    public static readonly Shop Shop = new(NameText.TextWithLans["Shop"],
        RenderNameText.TextWithLans["Shop"],
        new ShopAI(
            new List<Talker>(),
            new Seller(new List<Product>
            {
                new(ProductNameText.TextWithLans["HP"], 10, player =>
                {
                    player.Health += 20;
                }),
                new(ProductNameText.TextWithLans["MHP"], 10, player =>
                {
                    player.MaxHealth += 20;
                })
            }), null
        ), EInteracterType.Sell
    );

    public static readonly Gate Gate = new(NameText.TextWithLans["Gate"],
        RenderNameText.TextWithLans["Gate"],
        new GateAI(
            new List<Talker>(),
            new StageChanger(),
            null),
        EInteracterType.StageChange
    );
}