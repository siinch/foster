using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    private Camera cam;
    private AudioListener audioListener;
    private float speed = 3.0f;
    private float offset = 2.0f;
    public static Cam instance;
    public Vector3 deltaPosition = Vector3.zero;
    private Vector3 lastPosition;

    private Vector3 offsetDirection = new Vector3(0.0f, 0.0f, -10.0f);

    // Start is called before the first frame update
    void Start()
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
        //transform.position = Player.instance.transform.position + Vector3.back * 10;
        if(Input.GetButton("Horizontal") || Input.GetButton("Vertical")) 
            offsetDirection = new Vector3(
                Input.GetAxis("Horizontal") * offset, 
                Input.GetAxis("Vertical") * offset, 
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
