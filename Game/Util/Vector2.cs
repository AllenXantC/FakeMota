#nullable enable
namespace Mota.Game.Util;

public struct Vector2
{
    public int X { get; set; }
    public int Y { get; set; }

    public Vector2(int x, int y)
    {
        X = x;
        Y = y;
    }

    public double Magnitude() => Math.Sqrt(X * X + Y * Y);

    public bool IsNear(Vector2 vector2)
    {
        return (this - vector2).Magnitude() < Math.Sqrt(2);
    }
        
    public static Vector2 Zero = new(0, 0);

    public static Vector2 operator +(Vector2 a, Vector2 b) => new(a.X + b.X, a.Y + b.Y);
    public static Vector2 operator -(Vector2 a, Vector2 b) => new(a.X - b.X, a.Y - b.Y);
    public static Vector2 operator *(Vector2 a, Vector2 b) => new(a.X * b.X, a.Y * b.Y);
    public static Vector2 operator /(Vector2 a, Vector2 b) => new(a.X / b.X, a.Y / b.Y);

    public static Vector2 operator -(Vector2 a) => new(-a.X, -a.Y);

    public static Vector2 operator *(Vector2 a, int d) => new(a.X * d, a.Y * d);

    public static Vector2 operator *(int d, Vector2 a) => new(a.X * d, a.Y * d);

    public static Vector2 operator /(Vector2 a, int d) => new(a.X / d, a.Y / d);

    public static bool operator ==(Vector2 lhs, Vector2 rhs) {
        var num1 = lhs.X - rhs.X;
        var num2 = lhs.Y - rhs.Y;
        return num1 * (double)num1 + num2 * (double)num2 < 9.99999943962493E-11;
    }

    public static bool operator !=(Vector2 lhs, Vector2 rhs) => !(lhs == rhs);

    public override bool Equals(object? other) => other is Vector2 other1 && Equals(other1);

    public bool Equals(Vector2 other) => X == other.X && Y == other.Y;

    public override int GetHashCode() => X.GetHashCode() ^ Y.GetHashCode() << 2;
}