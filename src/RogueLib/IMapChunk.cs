namespace RogueLib
{
    public interface IMapChunk
    {
        IMapCell this[int x, int y] { get; }
        void SetFlags(int x, int y, CellFlags flags);
    }
}