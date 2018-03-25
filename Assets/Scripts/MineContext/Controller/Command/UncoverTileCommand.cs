using UnityEngine;
using System.Collections;
using strange.extensions.command.impl;

public class UncoverTileCommand : EventCommand
{

    [Inject]
    public ITileService tileService { get; set; }

    public override void Execute()
    {
        //TODO startup
        TileModel tile = evt.data as TileModel;

        dispatcher.Dispatch(EventConstants.UncoverTile, tile);
    }

}
