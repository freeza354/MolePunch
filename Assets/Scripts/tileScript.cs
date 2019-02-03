using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileScript : MonoBehaviour {

    public int tileNumber;
    public int tileDestroy;

	// Use this for initialization
	void Start () {
        
        tileNumber = GameManager.gameManager.randomTile;       

	}
	
	// Update is called once per frame
	void Update () {
        
	}
    
    void OnMouseDown()
    {
        GameManager.gameManager.score++;
        GameManager.gameManager.counter--;
        GameManager.gameManager.isFilled[tileNumber] = false;
        print(tileNumber + "tile destroyed!");
        Destroy(gameObject);
    }  


}
