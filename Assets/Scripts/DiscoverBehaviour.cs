using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscoverBehaviour : ClickHandler
{
    public GameObject HiddenItem;
    public bool isBomb;
    public GameObject CoverItem;
	// Use this for initialization
	void Start () {
        ClickCallBack = discoverTile;
        if (HiddenItem != null)
        {
            HiddenItem.SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {
        processClick();
	}
    private void discoverTile()
    {
        Debug.Log("Object Clicked");
        if (CoverItem != null)
        {
            CoverItem.SetActive(false);
        }
        if (HiddenItem != null)
        {
            HiddenItem.SetActive(true);
        }
    }
    void OnMouseOver()
    {
        isMouseOver = true;

    }
    void OnMouseExit()
    {
        isMouseOver = false;
    }
}
