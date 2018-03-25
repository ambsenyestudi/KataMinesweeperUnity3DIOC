using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TileService : ITileService
{
    [Inject(ContextKeys.CONTEXT_VIEW)]
    public GameObject contextView { get; set; }

    [Inject]
    public IEventDispatcher dispatcher { get; set; }
    [Inject]
    public ITilePositionComparisonService tileComparerService { get; set; }
    [Inject]
    public ISurroundingIndexService surroundingIndexService { get; set; }

    private IList<TileModel> _tileList;

    public IList<TileModel> TileList
    {
        get { return _tileList; }
    }

    public int TileCount{ get;set;}
    public TileService()
    {
        TileCount = -1;
    }

    public void AddTileToList(TileModel tile)
    {
        if (_tileList == null)
        {
            _tileList = new List<TileModel>();
        }
                
        var isTileInList = tileComparerService.isTileInList(tile, TileList);
        if (!isTileInList)
        {
            //Then reorder list
            _tileList.Add(tile);
        }
        
        var orderedItems = _tileList.GroupBy(item => item.Z)
            .OrderBy(g => g.First().Z)
            .Select(g => g.OrderBy(record => record.X))
            .SelectMany(group => group);
        
        _tileList = orderedItems.ToList();

    }

    public void PlantBombs(int bombs)
    {
        _tileList[0].HiddenItem = TileItemEnum.Bomb;
        _tileList[3].HiddenItem = TileItemEnum.Bomb;
        _tileList[21].HiddenItem = TileItemEnum.Bomb;
        int size = (int)Math.Sqrt(_tileList.Count + 1);
        for (int y = 0; y < size; y++)
        {
            for (int x = 0; x <size; x++)
            {
                int index = (y * size) + x;
                if(_tileList[index].HiddenItem!=TileItemEnum.Bomb)
                {
                    _tileList[index].BombsSurroundingCount = FigureBombsSurrounding(index, size);
                    if (_tileList[index].BombsSurroundingCount == 0)
                    {
                        _tileList[index].HiddenItem = TileItemEnum.Empty;
                    }
                    else
                    {
                        _tileList[index].HiddenItem = TileItemEnum.Nearbomb;
                    }
                }
            }
        }
    }

    private int FigureBombsSurrounding(int index, int size)
    {

        var indexList = surroundingIndexService.FigureSuroundingIndexes(index, size, _tileList.Count);
        var result = countBombsInCells(indexList);
        
        return result;
    }

    private int countBombsInCells(IList<int> indexList)
    {
        var totalBombs = 0;
        foreach (var item in indexList)
        {
            if(item >= 0)
            {
                if(_tileList[item].HiddenItem == TileItemEnum.Bomb)
                {
                    totalBombs++;
                }
            }
        }
        return totalBombs;
    }
    

    
}
