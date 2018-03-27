using UnityEngine;
using System;

/// <summary>
/// very important game object needs a collider
/// 
/// </summary>
public class ClickHandler: MonoBehaviour
{
    protected bool isMouseOver;
    protected Action ClickCallBack;
    protected void processClick()
    {
        bool isClick = Input.GetMouseButtonDown(0) && isMouseOver;
        if (isClick)
        {
            ClickCallBack.Invoke();
        }
    }
    
}