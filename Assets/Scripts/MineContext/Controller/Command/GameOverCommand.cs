using UnityEngine;
using System.Collections;
using strange.extensions.command.impl;

public class GameOverCommand : EventCommand
{
    [Inject]
    public ITileService tileService { get; set; }
    public override void Execute()
    {
        foreach (var tile in tileService.TileList)
        {
            dispatcher.Dispatch(EventConstants.UncoverTile,tile);
        }
        
    }

}
