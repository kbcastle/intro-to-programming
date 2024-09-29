using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class carController : MonoBehaviour
{
    public GameObject myCar;
    public float speed = 0.5f;
    public int score = 0;

    public AudioSource audioSource;
    public AudioClip crash;
    public AudioClip prize;

    //game restart text
    bool gameEnded = false;
    //public TextMeshProUGUI restartText;


    // Start is called before the first frame update
    void Start()
    {
        //restartText.enabled = false;
        //audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            myCar.transform.position += Vector3.up * speed;
            Debug.Log("W Pressed");
        }

        if (Input.GetKey(KeyCode.S))
        {
            myCar.transform.position += Vector3.down * speed;
            Debug.Log("S Pressed");
        }

        if (Input.GetKey(KeyCode.A))
        {
            myCar.transform.position += Vector3.left * speed;
            Debug.Log("A Pressed");
        }

        if (Input.GetKey(KeyCode.D))
        {
            myCar.transform.position += Vector3.right * speed;
            Debug.Log("D Pressed");
        }

       /* if (gameEnded == true)
        {
            restartText.enabled = true;
        }

        if (gameEnded == true && Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }*/
    }

    void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            gameEnded = true;
            audioSource.PlayOneShot(crash, 0.8f);
            Debug.Log("Collided with enemy");
            Destroy(myCar);
        }

        if (collision.gameObject.tag == "Prize")
        {
            audioSource.PlayOneShot(prize, 0.8f);
            Debug.Log("Collided with prize");
            score += 1;
            Destroy(collision.gameObject);
        }
    }
}
