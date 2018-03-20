using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBehaviour : MonoBehaviour {
    private bool isMouseOver;
    public float destroyExplosionAfterSeconds = 0.5f;
    public GameObject explosion;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        processClick();
	}

    private void processClick()
    {
        bool isClick = Input.GetMouseButtonDown(0) && isMouseOver;
        if (isClick)
        {
            //Generetate explosion
            
            var lastExplosion = Instantiate(explosion, transform.position, transform.rotation);
            StartCoroutine(KillAfterSomeTime(destroyExplosionAfterSeconds, lastExplosion));
        }
    }
    IEnumerator KillAfterSomeTime(float seconds, GameObject gObj)
    {
        yield return new WaitForSeconds(seconds);
        GameObject.Destroy(gObj);
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
