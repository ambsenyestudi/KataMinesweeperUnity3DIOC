using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChangeBehaviour : MonoBehaviour {

    public Material MainMaterial;
    public Material RollOverMaterial;
    public Material PressedMaterial;
    private Renderer _currRenderer;
    private bool isOver;

	// Use this for initialization
	void Start () {
        _currRenderer = GetComponent<Renderer>();
        if (!isCurrentMaterial(MainMaterial))
        {
            _currRenderer.material = MainMaterial;
        }
    }
	
	// Update is called once per frame
	void Update () {
        //This is just a frame (This is an event)
        if(Input.GetMouseButtonDown(0) && isOver)
        {
            if(!isCurrentMaterial(PressedMaterial))
            {
                _currRenderer.material = PressedMaterial;
            }
        }
    }
    //Those are ciclical events
    void OnMouseOver()
    {
        isOver = true;

        if (!isCurrentMaterial(RollOverMaterial))
        {
            _currRenderer.material = RollOverMaterial;
        }
    }
    
    void OnMouseExit()
    {
        isOver = false;
        if (!isCurrentMaterial(MainMaterial))
        {
            _currRenderer.material = MainMaterial;
        }
    }
    private bool isCurrentMaterial(Material mat)
    {
        return _currRenderer.material == mat;
    }
}
