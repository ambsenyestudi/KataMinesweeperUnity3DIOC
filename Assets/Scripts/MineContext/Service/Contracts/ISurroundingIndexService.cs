using System.Collections.Generic;

public interface ISurroundingIndexService
{
    IList<int> FigureSuroundingIndexes(int index, int size, int listSize);
}
