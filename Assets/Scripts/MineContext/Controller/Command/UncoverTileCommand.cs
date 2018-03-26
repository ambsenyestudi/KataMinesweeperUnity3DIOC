using UnityEngine;
using System.Collections;
using strange.extensions.command.impl;
using System.Linq;
using System.Collections.Generic;

public class UncoverTileCommand : EventCommand
{

    [Inject]
    public ITileService tileService { get; set; }
    [Inject]
    public IGameEvaluationService gameEvaluationService { get; set; }
    public override void Execute()
    {
        //TODO startup
        TileModel tile = evt.data as TileModel;
        tileService.TrackTile(tile);
        dispatcher.Dispatch(EventConstants.UncoverTile, tile);
        if(gameEvaluationService.IsGameWon(tileService.TileList))
        {
            dispatcher.Dispatch(EventConstants.LastTileUncovered);
        }
        
    }

}
