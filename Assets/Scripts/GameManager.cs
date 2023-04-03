using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public GameObject obstacle;

    private Vector2 spawn1;
    private Vector2 spawn2;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScore;
    public GameObject highestScore;
    public GameObject playButton;
    public GameObject player;

    int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            float waitTime = Random.Range(1f, 3f);
            float axisY = Random.Range(-12.30f, 12.30f);
            float axisX = Random.Range(-8.30f, 8.30f);

            float[] side = {-1f, 1f};
            int randomIndex = Random.Range(0,2);
         

            spawn1 = new Vector2(8.30f * side[randomIndex], axisY);
            spawn2 = new Vector2(axisX , 12.30f * side[randomIndex]);

            yield return new WaitForSeconds(waitTime);

            Instantiate(obstacle, spawn1, Quaternion.identity);
            Instantiate(obstacle, spawn2, Quaternion.identity);
        }

    }
    public void ScoreUp()
    {
        score++;
        scoreText.text = score.ToString();
        if (score > PlayerPrefs.GetInt("HighScore", 0)) PlayerPrefs.SetInt("HighScore", score);
    }

    public void GameStart()
    {
        playButton.SetActive(false);
        highestScore.SetActive(false);
        StartCoroutine("SpawnObstacles");
        InvokeRepeating("ScoreUp", 2f, 1f);
        player.SetActive(true);
    }

}
