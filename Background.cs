using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private SpriteRenderer sr;
    private static Sprite sprite;
    private static Texture2D texture;
    private static float width;
    private static float height;
    public static int multiplier = 3;

    private static float xJumpLenght;
    private static float yJumpLenght;
    private static float xJumpThreshold;
    private static float yJumpThreshold;
    public static float pixelsPerUnit = 20.0f;
    private float scrollSpeed = 0.9f;

    void Awake() {
        sr = gameObject.AddComponent<SpriteRenderer>();
        texture = Game.instance.backgroundTexture;
        width = texture.width / pixelsPerUnit;
        height = texture.height / pixelsPerUnit;
        xJumpLenght = width * multiplier;
        yJumpLenght = height * multiplier;
        xJumpThreshold = xJumpLenght / 2.0f;
        yJumpThreshold = yJumpLenght / 2.0f;

    }
    void Start()
    {   
        sprite = Sprite.Create(
            texture, 
            new Rect(0.0f, 0.0f, texture.width, texture.height), 
            new Vector2(0.5f, 0.5f),
            pixelsPerUnit
        );
        sr.sprite = sprite;
        sr.sortingOrder = -2;
    }
    

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Cam.instance.deltaPosition * scrollSpeed);
        if(xJumpThreshold < transform.position.x - Cam.instance.transform.position.x) {
            transform.Translate(Vector3.left * xJumpLenght);
        }
        else if(xJumpThreshold < Cam.instance.transform.position.x - transform.position.x) {
            transform.Translate(Vector3.right * xJumpLenght);
        }
        else if(yJumpThreshold < transform.position.y - Cam.instance.transform.position.y) {
            transform.Translate(Vector3.down * yJumpLenght);
        }
        else if(yJumpThreshold < Cam.instance.transform.position.y - transform.position.y) {
            transform.Translate(Vector3.up * yJumpLenght);
        }
    }
}
