﻿using strange.extensions.command.impl;

public class GameWonCommand : EventCommand
{
    [Inject]
    public ITileService tileService { get; set; }
    public override void Execute()
    {
        foreach (var tile in tileService.TileList)
        {
            dispatcher.Dispatch(EventConstants.GameWon, tile);
        }

    }

}
