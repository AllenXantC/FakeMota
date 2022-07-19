namespace Mota.Game.AI.Component.Level;

public class Level2 : Level
{
    public override int ExpUpperBound => 40;

    public override void ChangeProperties()
    {
        Player.MaxHealth *= 1.1;
    }
}