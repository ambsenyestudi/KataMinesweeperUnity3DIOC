using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCoverMediator : EventMediator
{
    //This is how your Mediator knows about your View.
    [Inject]
    public TileCoverView view { get; set; }
    [Inject]
    public ITilePositionComparisonService _comparisonService{ get; set; }
    
    public override void OnRegister()
    {
        dispatcher.AddListener(EventConstants.UncoverTile, UnCoverTile);
        dispatcher.AddListener(EventConstants.GameOver, OnGameOver);
        view.Init();
    }

    private void OnGameOver(IEvent payload)
    {
        view.DisableGo();
    }

    private void UnCoverTile(IEvent payload)
    {
        //TODO figure if this is the tile clicked on
        var tile = payload.data as TileModel;
        if(_comparisonService.isTileInSamePosition(view.TileModel, tile))
        {
            view.DisableGo();
        }
    }
    public override void OnRemove()
    {
        //Clean up listeners when the view is about to be destroyed
        dispatcher.AddListener(EventConstants.ClickedOn, UnCoverTile);
    }
}
