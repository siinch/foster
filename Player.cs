using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private float rotation;
    private Vector2 force;
    private float speed;
    public static Player instance;
    private float pixelsPerUnit = 100.0f;
    public Energy energy;
    public Rigidbody2D rigidbody; 

    void Awake() {
        rb = gameObject.AddComponent<Rigidbody2D>();
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.AddComponent<SpriteRenderer>();
        instance = this;
        tag = "Player";
    }
    void Start()
    {
        name = "Player";
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
        rb.drag = 1.0f;
        rb.gravityScale = 0.0f;
        rb.interpolation = RigidbodyInterpolation2D.Interpolate;
        rotation = -52.0f;
        GameObject exhaust = new GameObject();
        exhaust.AddComponent<Exhaust>();
        exhaust.transform.position = transform.position + Vector3.down * 0.5f;
        exhaust.transform.parent = transform;

        this.AddComponent<Energy>();
        energy= this.GetComponent<Energy>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("p"))
        {
            Time.timeScale = 0.0f;
        }

		if (Input.GetKeyUp("p"))
		{
			Time.timeScale = 1.0f;
		}
	}

    void FixedUpdate()
    {
		force = new Vector2(
			Input.GetAxis("Horizontal"),
			Input.GetAxis("Vertical")
		).normalized * speed;

		if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
		{
			rotation = Vector2.SignedAngle(Vector2.up, force);
			energy.Change(-energy.flyCost);
		}

		rb.AddForce(force);
        rb.MoveRotation(rotation);

	}
}
