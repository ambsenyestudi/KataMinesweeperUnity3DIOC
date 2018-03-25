using UnityEngine;
using System.Collections;
using strange.extensions.command.impl;
using System.Collections.Generic;

public class UncoverEmptyNeigboursCommand : EventCommand
{

    [Inject]
    public ITileService tileService { get; set; }

    public override void Execute()
    {
        //TODO startup
        TileModel tile = evt.data as TileModel;
        
        IList<TileModel> tiles = tileService.FindEmptyNeighbours(tile);
        foreach (var currTile in tiles)
        {
        
            dispatcher.Dispatch(EventConstants.UncoverTile, currTile);
        }
        
    }
}
