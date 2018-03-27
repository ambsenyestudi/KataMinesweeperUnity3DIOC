using System.Collections.Generic;

public interface ITileService
{
    IList<TileModel> TileList { get; }
    int TileCount { get; set; }
    void AddTileToList(TileModel tile);
    IList<TileModel> FindEmptyNeighbours(TileModel tile);
    void PlantBombs(int bombs);
    void TrackTile(TileModel tile);
}
