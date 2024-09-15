using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public float enemyTimer;
    public float prizeTimer;
    public float spawnIntervalEnemy = 3f;
    public float spawnIntervalPrize = 4f;
    public GameObject myEnemy;
    public GameObject myPrize;
    public TextMeshProUGUI scoreText;
    [SerializeField] carController carController;
    public int displayScore = 0;

    //declare bounding box
    public Vector2 xBounds;
    public Vector2 yBounds;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + carController.score;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + carController.score;

        enemyTimer += Time.deltaTime;

        Vector3 targetPositionEnemy = new Vector3(Random.Range(xBounds.x, xBounds.y), Random.Range(yBounds.x, yBounds.y), 0);
        if (enemyTimer > spawnIntervalEnemy)
        {
            enemyTimer = 0f;
            Instantiate(myEnemy, targetPositionEnemy, Quaternion.identity);
        }

        prizeTimer += Time.deltaTime;

        Vector3 targetPositionPrize = new Vector3(Random.Range(xBounds.x, xBounds.y), Random.Range(yBounds.x, yBounds.y), 0);
        if (prizeTimer > spawnIntervalPrize)
        {
            prizeTimer = 0f;
            Instantiate(myPrize, targetPositionPrize, Quaternion.identity);
        }

    }
}
