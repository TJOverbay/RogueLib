using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RogueLib
{
    /// <summary>
    /// Interface representing a rectangular grid of <see cref="MapChunk">chunks</see>
    /// </summary>

    public interface IMap
    {
        int ChunkCellsAcross { get; }
        int ChunkCellsDown { get; }

        int ChunksAcross { get; }
        int ChunksDown { get; }

        void Initialize(int chunkCellsAcross, int chunkCellsDown, int chunksAcross, int chunksDown);

        IMapChunk this[int x, int y] { get; }

        IEnumerable<IMapChunk> GetAllChunks();

        bool IsInFov(int x, int y);

        void Clear(CellFlags clearFlags = CellFlags.All);

        void CopyCells(IMap sourceMap, long x = 0, long y = 0, long? cellsAcross = null, long? cellsDown = null);
        void CopyChunks(IMap sourceMap, int x = 0, int y = 0, int? chunksAcross = null, int? chunksDown = null);

        void ComputFov(IEnumerable<LightSource> lightSources);
    }
}

public enum CellFlags : byte
{
    IsVisible = 1,
    IsWalkable = 2,
    IsExplored = 4,
    IsInFov = 8,
    All = IsVisible | IsWalkable | IsExplored
}