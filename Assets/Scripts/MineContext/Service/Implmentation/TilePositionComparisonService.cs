using System;
using System.Collections.Generic;

public class TilePositionComparisonService : ITilePositionComparisonService
{
    public bool isTileInList(TileModel tile, IList<TileModel> list)
    {
        bool isTileInList = false;
        if (list != null)
        {
            int count = 0;
            while (!isTileInList && count < list.Count)
            {
                isTileInList = isTileInSamePosition(tile, list[count]);
                count++;
            }
        }
        return isTileInList;
    }

    public bool isTileInSamePosition(TileModel tile, TileModel other)
    {
        var distance = figureVectorDistance(new float[] { tile.X, tile.Z }, new float[] { other.X, other.Z });
        return distance < 0.00005f;
    }
    private float figureVectorDistance(float[] vec, float[] otherVec)
    {
        var distance = Math.Pow(vec[0] - otherVec[0], 2d) +
            Math.Pow(vec[1] - otherVec[1], 2d);
        distance = Math.Sqrt(distance);
        return (float)distance;
    }
    
}
