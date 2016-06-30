namespace RogueLib
{
    public interface IMapCell
    {
        long X { get; }
        long Y { get; }

        CellFlags Flags { get; }
    }
}