using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private float rotation;
    private Vector2 force;
    private float speed;
    public static Player instance;
    private float pixelsPerUnit = 100;

    void Awake() {
        rb = gameObject.AddComponent<Rigidbody2D>();
        sr = gameObject.AddComponent<SpriteRenderer>();
        Player.instance = this;
    }
    void Start()
    {   
        Texture2D texture = Game.instance.playerTexture;
        Sprite sprite = Sprite.Create(
            texture, 
            new Rect(0.0f, 0.0f, texture.width, texture.height), 
            new Vector2(0.5f, 0.5f),
            pixelsPerUnit
        );
        CircleCollider2D collider = gameObject.AddComponent<CircleCollider2D>();
        collider.radius *= 0.66f;
        
        sr.sprite = sprite;
        speed = 10f;
        rb.drag = 1;
        rb.gravityScale = 0;
        rb.interpolation = RigidbodyInterpolation2D.Interpolate;
        rotation = -52;
        GameObject exhaust = new GameObject();
        exhaust.AddComponent<Exhaust>();
        exhaust.transform.position = transform.position + Vector3.down * 0.5f;
        exhaust.transform.parent = transform;
    }

    // Update is called once per frame
    void Update()
    {
        force = new Vector2(
            Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical")
        ).normalized * speed;

        if(Input.GetButton("Horizontal") || Input.GetButton("Vertical")) {
            rotation = Vector2.SignedAngle(Vector2.up, force);
        }
    }

    void FixedUpdate()
    {
        rb.AddForce(force);
        rb.MoveRotation(rotation);
    }
}
