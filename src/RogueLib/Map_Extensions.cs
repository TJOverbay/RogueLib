using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RogueLib
{
    public static class Map_Extensions
    {
        public static bool IsCellInFov(this IMap map, long x, long y)
        {
            return (map?.IsInFov((int)(x / map.ChunkCellsAcross), (int)(y / map.ChunkCellsDown))).GetValueOrDefault()
                && (GetCell(map, x, y).Flags & CellFlags.IsInFov) == CellFlags.IsInFov;
        }

        public static bool IsCellVisible(this IMap map, long x, long y)
        {
            return (GetCell(map, x, y).Flags & CellFlags.IsVisible) == CellFlags.IsVisible;
        }

        public static bool IsCellWalkable(this IMap map, long x, long y)
        {
            return (GetCell(map, x, y).Flags & CellFlags.IsWalkable) == CellFlags.IsWalkable;
        }

        public static bool IsCellExplored(this IMap map, long x, long y)
        {
            return (GetCell(map, x, y).Flags & CellFlags.IsExplored) == CellFlags.IsExplored;
        }

        public static IMapCell GetCell(this IMap map, long x, long y)
        {
            if (map == null) return null;

            return map[(int)(x / map.ChunkCellsAcross), (int)(y / map.ChunkCellsDown)]
                      [(int)(x % map.ChunkCellsAcross), (int)(y % map.ChunkCellsDown)];
        }

        public static void SetCellFlags(this IMap map, long x, long y, CellFlags flags)
        {
            map[(int)(x / map.ChunkCellsAcross), (int)(y / map.ChunkCellsDown)]
                .SetFlags((int)(x % map.ChunkCellsAcross), (int)(y % map.ChunkCellsDown), flags);
        }
    }
}
