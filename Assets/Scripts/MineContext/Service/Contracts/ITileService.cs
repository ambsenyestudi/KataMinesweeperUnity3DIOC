using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITileService
{
    IList<TileModel> TileList { get; }
    int TileCount { get; set; }
    void AddTileToList(TileModel tile);
    IList<TileModel> FindEmptyNeighbours(TileModel tile);
    void PlantBombs(int bombs);
}
