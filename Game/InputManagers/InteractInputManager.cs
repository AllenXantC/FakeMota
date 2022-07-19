using Mota.Game.Interact;
using Mota.Game.Interact.Interacters;
using Mota.Game.Role.Actor;

namespace Mota.Game.InputManagers;

public static class InteractInputManager
{
    public static int BattleInput;
    public static int SellInput;

    public static void GetBattleInput(Battler battler, Player player)
    {
        var getInputTask = Task.Run(() =>
        {
            GetInput(ref BattleInput, battler.Skills.Count + player.GetProductsDictionary().Count);
        });
        getInputTask.Wait();
    }

    public static void GetSellInput(Seller seller)
    {
        var getInputTask = Task.Run(() =>
        {
            GetInput(ref SellInput, seller.Products.Count + 1);
        });
        getInputTask.Wait();
    }

    private static void GetInput(ref int target, int max)
    {
        GetConsoleKey(ref target);
        while (!IsInputValid(target, max, 1))
        {
            InteractRenderManager.RenderInvalidInput();
            GetConsoleKey(ref target);
        }
    }
    
    private static void GetConsoleKey(ref int i)
    {
        var input = Console.ReadKey();
        var ch = input.KeyChar;
        i = Convert.ToInt32(ch) - 48;
    }

    private static bool IsInputValid(int target, int max, int min)
    {
        return target <= max && target >= min;
    }
}