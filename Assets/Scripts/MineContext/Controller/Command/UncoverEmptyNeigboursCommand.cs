using UnityEngine;
using System.Collections;
using strange.extensions.command.impl;
using System.Collections.Generic;

public class UncoverEmptyNeigboursCommand : EventCommand
{

    [Inject]
    public ITileService tileService { get; set; }
    [Inject]
    public IGameEvaluationService gameEvaluationService { get; set; }

    public override void Execute()
    {
        //TODO startup
        TileModel tile = evt.data as TileModel;
        
        IList<TileModel> tiles = tileService.FindEmptyNeighbours(tile);
        
        foreach (var currTile in tiles)
        {
            tileService.TrackTile(tile);
            dispatcher.Dispatch(EventConstants.UncoverTile, currTile);
        }
        if (gameEvaluationService.IsGameWon(tileService.TileList))
        {
            dispatcher.Dispatch(EventConstants.LastTileUncovered);
        }
    }
}
