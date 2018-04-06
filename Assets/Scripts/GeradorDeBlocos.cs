using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorDeBlocos : MonoBehaviour {

    public GameObject[] blocks;
    public int lines;

	// Use this for initialization
	void Start () {
        createBlocks();
	}
	
	void createBlocks ()
    {
        Bounds blockLimits = blocks[0].GetComponent<SpriteRenderer>().bounds;
        float blockWidth = blockLimits.size.x;
        float blockHeight = blockLimits.size.y;
        float screenWidth, screenHeight, widthMultiplicator;
        int colums;
        getBlockInformations(blockWidth, out screenWidth, out screenHeight, out colums, out widthMultiplicator);
        GerenciadorDoGame.totalNumberOfBlocks = lines * colums;
        for (int i = 0; i < lines; i++)
        {
            for (int j = 0; j < colums; j++)
            {
                GameObject randomBlock = blocks[Random.Range(0, blocks.Length)];
                GameObject instantiatedBlock = (GameObject)Instantiate(randomBlock);
                instantiatedBlock.transform.position = new Vector3(-(screenWidth * 0.5f) + (j * blockWidth * widthMultiplicator), (screenHeight * 0.5f) - (i * blockHeight), 0);
                float newBlockWidth = instantiatedBlock.transform.localScale.x * widthMultiplicator;
                instantiatedBlock.transform.localScale = new Vector3(newBlockWidth, instantiatedBlock.transform.localScale.y, 1);
            }
        }
    }

    void getBlockInformations (float blockWidth, out float screenWidth, out float screenHeight, out int colums, out float widthMultiplicator)
    {
        Camera c = Camera.main;
        screenWidth = (c.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)) - c.ScreenToWorldPoint(new Vector3(0, 0, 0))).x;
        screenHeight = (c.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)) - c.ScreenToWorldPoint(new Vector3(0, 0, 0))).y;
        colums = (int)(screenWidth / blockWidth);
        widthMultiplicator = screenWidth / (colums * blockWidth);
    }
}
