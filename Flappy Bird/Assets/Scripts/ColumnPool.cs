using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour {
	public int columnPoolSize = 5;
	private GameObject[] columns;
	public float spawnRate = 4f;
	public float columnMin = -1f;
	public float columnMax = 3.5f;
	public GameObject columnPrefab;

	private GameObject[] column;
	private Vector2 objectPoolPosition = new Vector2(-15f, -25);
	private float timeSinceLastSpawned=0f;
	private float spawnXPosition = 10f;
	private int currentColumn = 0;
	// Use this for initialization
	void Start () {
		column = new GameObject[columnPoolSize];
		for(int i = 0; i < columnPoolSize; i++)
        {
			column[i] = (GameObject)Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);

        }
		
	}
	
	// Update is called once per frame
	void Update () {
		timeSinceLastSpawned += Time.deltaTime;
		if(GameControl.instance.gameOver==false && timeSinceLastSpawned>=spawnRate)
        {
			timeSinceLastSpawned = 0;
			float spawnYPosition = Random.Range(columnMin, columnMax);
			column[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);
			currentColumn++;
            if (currentColumn >= columnPoolSize)
            {
				currentColumn = 0;
            }
        }
	}
}
