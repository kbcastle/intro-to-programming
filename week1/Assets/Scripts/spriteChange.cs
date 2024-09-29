using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class spriteChange : MonoBehaviour
{

    private SpriteRenderer mySpriteRenderer;
    public Sprite newSprite;


    // Start is called before the first frame update
    void Start()
    {
        mySpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        mySpriteRenderer.sprite = newSprite;
    }
}
