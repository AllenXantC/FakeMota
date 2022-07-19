#nullable enable
namespace Mota.Game.Util;

public static class RandomUtil
{
    private static readonly Random Random = new();

    public static int Range(int minValue, int maxValue)
    {
        return Random.Next(minValue, maxValue + 1);
    }

    public static bool Half()
    {
        return Range(0, 1) == 1;
    }

    /// <summary>
    /// return true at a possibility of percentage%
    /// for example, there's a 50% possibility of
    /// returning true when percentage is 50
    /// </summary>
    /// <param name="percentage"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    /// <exception cref="ArgumentException"></exception>
    public static bool Percent(int percentage)
    {
        if (percentage is > 0 and < 100)
        {
            var nums = new List<int>();
                
            for (var i = 1; i <= percentage; i++)
            {
                nums[i] = 1;
            }
                
            for (var i = percentage + 1; i <= 100; i++)
            {
                nums[i] = -1;
            }
                
            var index = Range(1, 100);
            var num = nums[index];
            return num switch
            {
                1 => true,
                -1 => false,
                _ => throw new Exception()
            };
        }

        if (percentage == 0) return false;
        if (percentage == 100) return true;
        throw new ArgumentException("give an integer between 0 and 100!");
    }
}