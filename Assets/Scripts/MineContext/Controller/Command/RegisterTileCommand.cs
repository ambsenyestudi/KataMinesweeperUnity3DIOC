using strange.extensions.command.impl;
using strange.extensions.context.api;
using System.Linq;
using UnityEngine;

public class RegisterTileCommand : EventCommand
{

    [Inject(ContextKeys.CONTEXT_VIEW)]
    public GameObject contextView { get; set; }

    [Inject]
    public ITileService tileService { get; set; }

    public override void Execute()
    {
        //Debug.Log("Registering tile");
        TileModel tile = evt.data as TileModel;
        tileService.AddTileToList(tile);
        if (tileService.TileCount > -1)
        {
            if (tileService.TileList.Count == tileService.TileCount)
            {
                tileService.PlantBombs(5);
                Debug.Log("All tiles (" + tileService.TileCount + ") acounted for");
            }
        }
        else if (tileService.TileList.Count > tileService.TileCount)
        {
            var tiles = GameObject.FindObjectsOfType<TileView>();
            tileService.TileCount = tiles.Count();
        }
        
    }
}
