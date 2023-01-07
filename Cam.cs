using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    private Camera cam;
    private AudioListener audioListener;
    private float speed = 3.0f;
    private float offset = 6.0f;
    public static Cam instance;
    public Vector3 deltaPosition = Vector3.zero;
    private Vector3 lastPosition;

    private Vector3 offsetDirection = new Vector3(0.0f, 0.0f, -10.0f);

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        name = "Cam";
        audioListener = gameObject.AddComponent<AudioListener>();
        cam = gameObject.AddComponent<Camera>();
        cam.clearFlags = CameraClearFlags.SolidColor;
        cam.orthographic = true;
        transform.Translate(Vector3.back * 10);
        tag = "MainCamera";
        cam.depth = -1.0f;
        cam.backgroundColor = Color.black;
        cam.orthographicSize = 8.0f;
        lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var velocity = Player.instance.rigidbody.velocity;
            offsetDirection = new Vector3(
                velocity.x,
				velocity.y, 
                -10.0f
            );

        transform.position = Vector3.Lerp(
            transform.position, 
            Player.instance.transform.position + offsetDirection,
            speed * Time.deltaTime
        );
        deltaPosition = transform.position - lastPosition;
        lastPosition = transform.position;
    }
}
