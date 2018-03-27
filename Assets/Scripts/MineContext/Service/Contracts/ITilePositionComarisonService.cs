using System.Collections.Generic;

public interface ITilePositionComparisonService
{
    bool isTileInList(TileModel tile, IList<TileModel> list);
    bool isTileInSamePosition(TileModel tile, TileModel other);
}
