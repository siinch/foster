using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exhaust : MonoBehaviour
{
    private SpriteRenderer sr;
    private float pixelsPerUnit = 20.0f;

    private float timeSinceLastSpawn = 0.0f;
    private float spawnInterval = 0.03f;
    void Awake()
    {
        sr = gameObject.AddComponent<SpriteRenderer>();
    }

    void Start () {
        Texture2D texture = Game.instance.exhaustTexture;
        Sprite sprite = Sprite.Create(
            texture, 
            new Rect(0.0f, 0.0f, texture.width, texture.height), 
            new Vector2(0.5f, 0.5f),
            pixelsPerUnit
        );
        
        sr.sprite = sprite;
        sr.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        if(Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical"))
            sr.enabled = true;

        if(Input.GetButton("Horizontal") || Input.GetButton("Vertical")) {
            timeSinceLastSpawn += Time.deltaTime;
            if(timeSinceLastSpawn > spawnInterval) {
                GameObject exhaustTrail = new GameObject();
                exhaustTrail.transform.position = transform.position;
                exhaustTrail.AddComponent<ExhaustTrail>();
                timeSinceLastSpawn -= spawnInterval;
            }
        }
        else
            sr.enabled = false;
    }
}
