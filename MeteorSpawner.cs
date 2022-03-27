using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    
    public static int count = 0;
    public  static int maxCount = 100;
    void Update () {
        if(MeteorSpawner.count < MeteorSpawner.maxCount) {
            Vector2 playerPosition = Player.instance.transform.position;

            Vector2 offsetDirection = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
            offsetDirection.Normalize();
            float offsetMagnitude = Random.Range(20, 100);

            MeteorSpawner.count++;
            GameObject meteor = new GameObject();
            meteor.transform.position = playerPosition + offsetDirection * offsetMagnitude;;
            meteor.AddComponent<Meteor>();

        }
    }
}
