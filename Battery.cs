using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
	private float pixelsPerUnit = 40.0f;
	private float energyValue = 5.0f;
	void Start()
	{
		name = "Battery";
		var texture = Game.instance.batteryTexture;
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

	void FixedUpdate()
	{
		Vector2 playerPosition = Player.instance.transform.position;
		Vector2 batteryPosition = transform.position;
		if (Vector2.Distance(playerPosition, batteryPosition) > 100.0f)
		{
			BatterySpawner.count--;
			Destroy(gameObject);
		}
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if(col.gameObject.tag == "Player")
		{
			col.gameObject.GetComponent<Energy>().Change(energyValue);
			Destroy(gameObject);
		}
	}
}
