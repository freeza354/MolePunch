using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour {
    
    /*
    public class Tiles
    {
        public Transform[] Tile;
        public bool[] isFilled = new bool[25];

        public Tiles()
        {
            for (int i = 0; i < isFilled.Length; i++)
            {
                isFilled[i] = false;
            }
        }

    }*/

    public Text scoretext;
    public Transform Board;
    public GameObject activeTile;

    public Transform[] Tile;
    public bool[] isFilled = new bool[25];

    public static int score;
    public static int counter = 0;
    
	// Use this for initialization
	void Start () {
        
        score = 0;

        Tile = new Transform[Board.childCount];

        for (int i = 0; i < Tile.Length; i++)
        {
            Tile[i] = Board.GetChild(i);
            isFilled[i] = false;
        }

        StartCoroutine(SpawnTiles());

	}
	
	// Update is called once per frame
	void Update () {

        scoretext.text = score.ToString();

        if (counter >= 24)
        {
            GameOver();
        }

	}

    IEnumerator SpawnTiles()
    {
        while (true)
        {
            print("called");

            int random;
            for (int i = 0; i < 5; i++)
            {
                random = Random.Range(1, 25);
                print(random);
                while (isFilled[random - 1])
                {
                    random = Random.Range(1, 25);
                }

                isFilled[random - 1] = true;
                Instantiate(activeTile, Tile[random - 1].position, Tile[random - 1].rotation);
                counter++;
            }

            yield return new WaitForSeconds(5);

        }

    }

    void GameOver()
    {
        StopAllCoroutines();
    }

}
