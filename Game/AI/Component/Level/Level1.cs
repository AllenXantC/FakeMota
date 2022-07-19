namespace Mota.Game.AI.Component.Level;

public class Level1 : Level
{
    public override int ExpUpperBound => 20;

    public override void ChangeProperties()
    {
        Player.MaxHealth *= 1.1;
    }
}