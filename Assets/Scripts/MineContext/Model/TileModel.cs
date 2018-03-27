public enum TileItemEnum
{
    UniInitalized,
    Bomb,
    Nearbomb,
    Empty
}
public class TileModel
{
    public int Index { get; set; }
    public float X { get; set; }
    public float Z { get; set; }
    public int BombsSurroundingCount { get; set; }
    public TileItemEnum HiddenItem { get; set; }
    public bool IsUncovered { get; set; }

    public override string ToString()
    {
        return "Tile{ Index: " + Index + ", X: " + X +", Z:" + Z +" }";
    }
}
