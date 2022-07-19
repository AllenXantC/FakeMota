namespace Mota.Game.AI.Component.Level;

public class Level3 : Level
{
    public override int ExpUpperBound => 70;

    public override void ChangeProperties()
    {
        Player.MaxHealth *= 1.1;
    }
}