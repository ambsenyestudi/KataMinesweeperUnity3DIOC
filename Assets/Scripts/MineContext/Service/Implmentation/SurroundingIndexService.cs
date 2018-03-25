using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SurroundingIndexService:ISurroundingIndexService
{
    public IList<int> FigureSuroundingIndexes(int index, int size, int listSize) {
        var indexList = new int[] {
            FigureUpperIndex(index,size),
            FigureUpperRightIndex(index,size),
            FigureRightIndex(index,size),
            FigureLowerRightIndex(index,size, listSize),
            FigureLowerIndex(index,size, listSize),
            FigureLowerLeftIndex(index,size, listSize),
            FigureLeftIndex(index,size),
            FigureUppeLeftIndex(index,size),
        };
        return indexList;
    }
    private int figureOffsetInSize(int index, int offset, int min, int max)
    {
        int resultIndex = -1;
        var next = index + offset;
        if (next >= min && next < max)
        {
            resultIndex = next;
        }
        return resultIndex;
    }

    public int FigureUpperIndex(int index, int size)
    {
        return figureOffsetInSize(index, -size, 0, index);
    }

    public int FigureUpperRightIndex(int index, int size)
    {
        var result = FigureUpperIndex(index, size);
        if (result > -1)
        {
            result = FigureRightIndex(result, size);
        }
        return result;
    }

    public int FigureRightIndex(int index, int size)
    {
        return figureOffsetInSize(index, 1, index, FigureCurrentRowSize(index, size));
    }

    public int FigureLowerRightIndex(int index, int size, int listSize)
    {
        var result = FigureLowerIndex(index, size, listSize);
        if (result > -1)
        {
            result = FigureRightIndex(result, size);
        }
        return result;
    }

    public int FigureLowerIndex(int index, int size, int listSize)
    {
        return figureOffsetInSize(index, size, index, listSize);
    }

    public int FigureLowerLeftIndex(int index, int size, int listSize)
    {
        var result = FigureLowerIndex(index, size, listSize);
        if (result > -1)
        {
            result = FigureLeftIndex(result, size);
        }
        return result;
    }

    public int FigureLeftIndex(int index, int size)
    {
        return figureOffsetInSize(index, -1, FigurePreviousRowSize(index, size), index);
    }

    public int FigureUppeLeftIndex(int index, int size)
    {
        var result = FigureUpperIndex(index, size);
        if (result > -1)
        {
            result = FigureLeftIndex(result, size);
        }
        return result;
    }

    private int FigureCurrentRowSize(int index, int size)
    {
        int total = 0;
        while (total <= index)
        {
            total += size;
        }
        return total;
    }

    private int FigurePreviousRowSize(int index, int size)
    {
        var previousRow = FigureCurrentRowSize(index, size) - size;
        return previousRow;
    }
}
