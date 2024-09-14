using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carController : MonoBehaviour
{
    public GameObject myCar;
    public float speed = 0.5f;
    public int score = 0;


    // Start is called before the first frame update
    void Start()
    {
        
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
    }

    void OnCollisionStay2D (Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Collided with enemy");
            Destroy(myCar);
        }

        if (collision.gameObject.tag == "Prize")
        {
            Debug.Log("Collided with prize");
            score += 1;
            Destroy(collision.gameObject);
        }
    }
}
