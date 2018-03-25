﻿using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMediator : EventMediator
{
    //This is how your Mediator knows about your View.
    [Inject]
    public TileView view { get; set; }

    [Inject]
    public ITilePositionComparisonService _comparisonService { get; set; }

    private GameObject hiddenItem ;

    public override void OnRegister()
    {
        hiddenItem = null;
        //Listen to the view for an event
        view.dispatcher.AddListener(EventConstants.ClickedOn, onViewClickedOn);
        view.dispatcher.AddListener(EventConstants.TileInitialized, onTileInitialized);
        dispatcher.AddListener(EventConstants.UncoverTile, UnCoverTile);
        //Listen to the global event bus for events
        dispatcher.AddListener(EventConstants.AppStarted, AppStarted);

        view.Init();
    }
    
    private void onTileInitialized(IEvent payload)
    {
        dispatcher.Dispatch(EventConstants.RegisterTile, view.TileModel);
    }
    private void UnCoverTile(IEvent payload)
    {
        //TODO figure if this is the tile clicked on
        var tile = payload.data as TileModel;
        if (_comparisonService.isTileInSamePosition(view.TileModel, tile))
        {
            if (hiddenItem == null)
            {
                if (tile.HiddenItem == TileItemEnum.Bomb || tile.HiddenItem == TileItemEnum.Nearbomb)
                {
                    if (tile.HiddenItem == TileItemEnum.Bomb)
                    {
                        hiddenItem = (GameObject)Instantiate(Resources.Load("Prefab/ase-minesweeper_mine"));
                    }
                    else
                    {
                        InstantiateBombCount(tile.BombsSurroundingCount);
                    }
                    hiddenItem.transform.parent = gameObject.transform;
                    hiddenItem.transform.localPosition = Vector3.zero;
                }
                
            }

        }
    }

    private void InstantiateBombCount(int bombsSurroundingCount)
    {
        switch (bombsSurroundingCount)
        {
            case 1:
                hiddenItem = (GameObject)Instantiate(Resources.Load("Prefab/ase-minesweeper_number_1"));
                break;
            case 2:
                hiddenItem = (GameObject)Instantiate(Resources.Load("Prefab/ase-minesweeper_number_2"));
                break;
            default:
                break;
        }
    }

    private void AppStarted(IEvent payload)
    {
        //TODO identify this tile
        //throw new NotImplementedException();
    }
    private void onViewClickedOn()
    {
        dispatcher.Dispatch(EventConstants.ClickedOn, view.TileModel);
    }

    public override void OnRemove()
    {
        //Clean up listeners when the view is about to be destroyed
        view.dispatcher.RemoveListener(EventConstants.ClickedOn, onViewClickedOn);
        dispatcher.RemoveListener(EventConstants.AppStarted, AppStarted);
    }

    
}
