using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatterySpawner : MonoBehaviour
{

	public static int count = 0;
	public static int maxCount = 20;
	void Update()
	{
		if (count < maxCount)
		{
			Vector2 playerPosition = Player.instance.transform.position;

			Vector2 offsetDirection = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
			offsetDirection.Normalize();
			float offsetMagnitude = Random.Range(20.0f, 100.0f);

			count++;
			GameObject battery = new GameObject();
			battery.transform.position = playerPosition + offsetDirection * offsetMagnitude; ;
			battery.AddComponent<Battery>();
		}
	}
}
