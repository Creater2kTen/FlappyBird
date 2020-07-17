using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameControl : MonoBehaviour {
	public static GameControl instance;
	public GameObject gameOverText;
	public bool gameOver = false;
	private int score = 0;
	public float scrollSpeed = -1.5f;
	public Text ScoreText;
	// Use this for initialization
	void Awake () {

		if(instance == null)
		{
			instance = this;
		}
		else if(instance!=null){
			
			Destroy(gameObject);

		}
		
	}
	
	// Update is called once per frame
	void Update () {
		if(gameOver==true && Input.GetMouseButtonDown(0))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}
	public void BirdDie()
	{
		gameOverText.SetActive(true);
		gameOver = true;
	}
	public void BirdScored()
	{
		if (gameOver)
		{
			return;
		}
		score++;
		ScoreText.text = "Score:" + score.ToString();
	}
	
}
