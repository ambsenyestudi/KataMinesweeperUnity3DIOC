using strange.extensions.dispatcher.eventdispatcher.api;
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
    private bool isDisabled;
    public override void OnRegister()
    {
        hiddenItem = null;
        //Listen to the view for an event
        view.dispatcher.AddListener(EventConstants.ClickedOn, onViewClickedOn);
        view.dispatcher.AddListener(EventConstants.TileInitialized, onTileInitialized);
        dispatcher.AddListener(EventConstants.UncoverTile, UnCoverClickedOnTile);
        dispatcher.AddListener(EventConstants.GameWon, ShowFlag);
        dispatcher.AddListener(EventConstants.GameOver, GameOverUncover);
        //Listen to the global event bus for events
        dispatcher.AddListener(EventConstants.AppStarted, AppStarted);
        view.Init();
    }

    private void Reset()
    {
        isDisabled = false;
    }
    private void ShowFlag(IEvent payload)
    {
        if (hiddenItem == null)
        {
            hiddenItem = (GameObject)Instantiate(Resources.Load(PrefabConstants.Flag));
            hiddenItem.transform.parent = this.transform;
            hiddenItem.transform.localPosition = Vector3.zero;
        }
        isDisabled = true;
    }

    private void GameOverUncover(IEvent payload)
    {
        if (hiddenItem == null)
        {
            var tile = payload.data as TileModel;
            if (_comparisonService.isTileInSamePosition(view.TileModel, tile))
            {
                DoUncoverTile(tile);
            }
        }
    }

    private void onTileInitialized(IEvent payload)
    {
        dispatcher.Dispatch(EventConstants.RegisterTile, view.TileModel);
    }
    private void UnCoverClickedOnTile(IEvent payload)
    {
        if (hiddenItem == null)
        {
            var tile = payload.data as TileModel;
            if (_comparisonService.isTileInSamePosition(view.TileModel, tile))
            {
                DoUncoverTileAndEmptyNeibours(tile);
            }
        }
    }
    private void DoUncoverTile(TileModel tile)
    {
        if (tile.HiddenItem == TileItemEnum.Bomb || tile.HiddenItem == TileItemEnum.Nearbomb)
        {
            if (tile.HiddenItem == TileItemEnum.Bomb)
            {
                hiddenItem = (GameObject)Instantiate(Resources.Load(PrefabConstants.Mine));
                dispatcher.Dispatch(EventConstants.Explosion);
            }
            else
            {
                InstantiateBombCount(tile.BombsSurroundingCount);
            }
            hiddenItem.transform.parent = gameObject.transform;
            hiddenItem.transform.localPosition = Vector3.zero;
        }
    }
    private void DoUncoverTileAndEmptyNeibours(TileModel tile)
    {
        if (tile.HiddenItem == TileItemEnum.Empty)
        {
            hiddenItem = new GameObject();
            hiddenItem.transform.parent = this.transform;
            hiddenItem.transform.localPosition = Vector3.zero;
            dispatcher.Dispatch(EventConstants.UncoverEmptyNeighbours, tile);
        }
        else
        {
            DoUncoverTile(tile);
        }
    }

    private void InstantiateBombCount(int bombsSurroundingCount)
    {
        switch (bombsSurroundingCount)
        {
            case 1:
                hiddenItem = (GameObject)Instantiate(Resources.Load(PrefabConstants.Number1));
                break;
            case 2:
                hiddenItem = (GameObject)Instantiate(Resources.Load(PrefabConstants.Number2));
                break;
            case 3:
                hiddenItem = (GameObject)Instantiate(Resources.Load(PrefabConstants.Number3));
                break;
            case 4:
                hiddenItem = (GameObject)Instantiate(Resources.Load(PrefabConstants.Number4));
                break;
            case 5:
                hiddenItem = (GameObject)Instantiate(Resources.Load(PrefabConstants.Number5));
                break;
            case 6:
                hiddenItem = (GameObject)Instantiate(Resources.Load(PrefabConstants.Number6));
                break;
            default:
                break;
        }
    }

    private void AppStarted(IEvent payload)
    {
        //TODO identify this tile
        Reset();
    }
    private void onViewClickedOn()
    {
        if (!isDisabled)
        {
            dispatcher.Dispatch(EventConstants.ClickedOn, view.TileModel);
        }
    }

    public override void OnRemove()
    {
        //Clean up listeners when the view is about to be destroyed
        view.dispatcher.RemoveListener(EventConstants.ClickedOn, onViewClickedOn);
        dispatcher.RemoveListener(EventConstants.AppStarted, AppStarted);
    }

    
}
