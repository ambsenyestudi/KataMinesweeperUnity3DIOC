using strange.extensions.mediation.impl;
using UnityEngine;

public class TileCoverView : View
{

    private GameObject _go;
    public TileModel TileModel { get; private set; }

    internal void Init()
    {
        //Init logic here
        TileModel = new TileModel
        {
            X = transform.position.x,
            Z = transform.position.z
        };
        _go = this.gameObject;
    }
    public void DisableGo()
    {
        if (_go.activeSelf)
        {
            _go.SetActive(false);
        }
    }
    public void EnableGo()
    {
        _go.SetActive(true);
    }
}
