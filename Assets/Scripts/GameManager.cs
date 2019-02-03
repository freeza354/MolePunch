using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour {
    
    public static GameManager gameManager;

    public Text scoretext;
    public Transform Board;
    public GameObject activeTile;

    public Transform[] Tile;
    public bool[] isFilled = new bool[25];

    public int randomTile;
    public int score;
    public int counter = 0;

    private void Awake()
    {
        gameManager = this;
    }

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
            for (int i = 0; i < 11; i++)
            {
                RandomNumber();

                while (isFilled[randomTile])
                {
                    print(randomTile + " tile is already activated. Randoming number again...");
                    RandomNumber();
                }
                
                isFilled[randomTile] = true;

                Instantiate(activeTile, Tile[randomTile - 1].position, Tile[randomTile - 1].rotation);
                counter++;
                print(randomTile + " is " + isFilled[randomTile] + " and total counter are : " + counter);
            }

            yield return new WaitForSeconds(5);

        }

    }

    void RandomNumber()
    {
        randomTile = Random.Range(1, 25);

        while (isFilled[randomTile - 1])
        {
            randomTile = Random.Range(1, 25);
        }
    }

    void GameOver()
    {
        StopAllCoroutines();
        print("Game Over!");
    }

}
