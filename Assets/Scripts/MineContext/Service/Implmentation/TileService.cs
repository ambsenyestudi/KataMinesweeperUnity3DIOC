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

    public int GridSize
    {
        get
        {
            return (int)Math.Sqrt(_tileList.Count + 1);
        }
    }

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
    private void generateRandomBombs(int bombs)
    {
        //TODO generate as many bombs as param
        var rand = new System.Random();
        var games = new List<int[]>
        {
            FieldsConstants.firstGame,
            FieldsConstants.secondGame,
            FieldsConstants.thirdGame,
            FieldsConstants.fourthGame,
            FieldsConstants.fifthGame,
            FieldsConstants.sixthGame,
            FieldsConstants.seventhGame,
            FieldsConstants.eighthGame,
            FieldsConstants.ninethGame
        };
        var index = rand.Next(games.Count);
        var currGame = games[index];
        
        foreach (var itemIndex in currGame)
        {
            _tileList[itemIndex].HiddenItem = TileItemEnum.Bomb;
        }
    }
    public void PlantBombs(int bombs)
    {
        generateRandomBombs(bombs);


        for (int y = 0; y < GridSize; y++)
        {
            for (int x = 0; x < GridSize; x++)
            {
                int index = (y * GridSize) + x;
                if(_tileList[index].HiddenItem!=TileItemEnum.Bomb)
                {
                    _tileList[index].BombsSurroundingCount = FigureBombsSurrounding(index, GridSize);
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

    public IList<TileModel> FindEmptyNeighbours(TileModel tile)
    {
        bool isFound = false;
        int count = 0;
        while(!isFound&&count<_tileList.Count)
        {
            if(tileComparerService.isTileInSamePosition(_tileList[count], tile))
            {
                isFound = true;
            }
            else
            {
                count++;
            }
        }
        var indexes = surroundingIndexService.FigureSuroundingIndexes(count, GridSize, _tileList.Count).Where(i=>i>-1);
        var emptyNeigbours = indexes.Select(i => _tileList[i]).Where(t=>t.HiddenItem==TileItemEnum.Empty);
        //ToDo recursivity
        
        return emptyNeigbours.ToList();
    }

    public void TrackTile(TileModel tile)
    {
        for (int i = 0; i < _tileList.Count; i++)
        {
            if(tileComparerService.isTileInSamePosition(tile, _tileList[i]))
            {
                _tileList[i].IsUncovered = true;
            }
        }
    }
}
