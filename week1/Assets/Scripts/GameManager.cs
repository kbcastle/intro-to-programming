using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public float enemyTimer;
    public float prizeTimer;
    public float spawnIntervalEnemy = 3f;
    public float spawnIntervalPrize = 4f;
    public GameObject myEnemy;
    public GameObject myPrize;

    //score text
    public TextMeshProUGUI scoreText;
    [SerializeField] carController carController;
    public int displayScore = 0;

    //game start bool and text
    bool gameStarted = false;
    public TextMeshProUGUI startText;

    //restart text
    public TextMeshProUGUI restartText;

    //game end sound
    public AudioSource audioSourceCrash;

    //declare bounding box
    public Vector2 xBounds;
    public Vector2 yBounds;


    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + carController.score;
        restartText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            gameStarted = true;
        }

        scoreText.text = "Score: " + carController.score;

        if (gameStarted == true)
        {
            enemyTimer += Time.deltaTime;
            prizeTimer += Time.deltaTime;
            startText.enabled = false; 
        }
     

        Vector3 targetPositionEnemy = new Vector3(Random.Range(xBounds.x, xBounds.y), Random.Range(yBounds.x, yBounds.y), 0);
        if (enemyTimer > spawnIntervalEnemy)
        {
            enemyTimer = 0f;
            Instantiate(myEnemy, targetPositionEnemy, Quaternion.identity);
        }


        Vector3 targetPositionPrize = new Vector3(Random.Range(xBounds.x, xBounds.y), Random.Range(yBounds.x, yBounds.y), 0);
        if (prizeTimer > spawnIntervalPrize)
        {
            prizeTimer = 0f;
            Instantiate(myPrize, targetPositionPrize, Quaternion.identity);
        }

        if (carController.crashSound == true)
        {
            audioSourceCrash.Play();
            carController.crashSound = false;
        }

        if (carController.gameEnded == true)
        {
            restartText.enabled = true;
        }

        if (carController.gameEnded == true && Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
}
