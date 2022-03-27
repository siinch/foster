using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    
    // Start is called before the first frame update
    private float pixelsPerUnit = 20.0f;
    void Start()
    {
        Texture2D texture = Game.instance.meteorTextures[
            Mathf.FloorToInt(
                Random.Range(0, Game.instance.meteorTextures.Length)
            )
        ];
        Sprite sprite = Sprite.Create(
            texture, 
            new Rect(0.0f, 0.0f, texture.width, texture.height), 
            new Vector2(0.5f, 0.5f),
            pixelsPerUnit
        );

        SpriteRenderer sr = gameObject.AddComponent<SpriteRenderer>();
        sr.sprite = sprite;
        Rigidbody2D rb = gameObject.AddComponent<Rigidbody2D>();
        rb.interpolation = RigidbodyInterpolation2D.Interpolate;
        rb.drag = 1.0f;

        CircleCollider2D collider = gameObject.AddComponent<CircleCollider2D>();
        collider.radius *= 0.80f;
    }
}
