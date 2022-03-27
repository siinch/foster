using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExhaustTrail : MonoBehaviour
{
    // Start is called before the first frame update
    private float timeSinceSpawn = 0.0f;
    private float timeToLive = 1.0f;
    private SpriteRenderer sr;
    private float pixelsPerUnit = 100.0f;
    void Awake()
    {
        sr = gameObject.AddComponent<SpriteRenderer>();
    }

    void Start () {
        Texture2D texture = Game.instance.exhaustTrailTexture;
        Sprite sprite = Sprite.Create(
            texture, 
            new Rect(0.0f, 0.0f, texture.width, texture.height), 
            new Vector2(0.5f, 0.5f),
            pixelsPerUnit
        );
        
        sr.sprite = sprite;
        sr.sortingOrder = -1;
        sr.color = new Color(1, 1, 1, 0.5f);
    }
    // Update is called once per frame
    void Update()
    {
        timeSinceSpawn += Time.deltaTime;
        transform.localScale = Vector3.one * (timeToLive - timeSinceSpawn) / timeToLive; 
        if(timeSinceSpawn > timeToLive)
            GameObject.Destroy(gameObject);
    }
}
