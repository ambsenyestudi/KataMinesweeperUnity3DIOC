using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileView : ClickedOnDetector
{
    public TileModel TileModel { get; private set; }

    internal void Init()
    {
        //Init logic here
        TileModel = new TileModel
        {
            X =transform.position.x,
            Z =transform.position.z
        };
        dispatcher.Dispatch(EventConstants.TileInitialized);
    }
}
