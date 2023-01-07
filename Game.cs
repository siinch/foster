using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Game : MonoBehaviour
{

    public Texture2D playerTexture;
    public Texture2D backgroundTexture;
    public Texture2D exhaustTexture;
    public Texture2D exhaustTrailTexture;
    public Texture2D energyTexture;
    public Texture2D[] meteorTextures;
    public static Game instance;
    void Awake () {
        instance = this;
        GameObject player = new GameObject();
        player.AddComponent<Player>();

        for(int i = -Background.multiplier/2; i < Background.multiplier/2+1; i++) {
            for(int j = -Background.multiplier/2; j < Background.multiplier/2+1; j++) {
                GameObject background = new GameObject();
                background.AddComponent<Background>();
                background.transform
                .position = new Vector3(
                    backgroundTexture.width * i/Background.pixelsPerUnit,
                    backgroundTexture.height * j/Background.pixelsPerUnit,
                    0f
                );
            }
        }

        GameObject camara = new GameObject();
        camara.AddComponent<Cam>();

        GameObject meteorSpawner = new GameObject();
        meteorSpawner.AddComponent<MeteorSpawner>();

		Physics2D.gravity = Vector2.zero;

		var canvasObject = new GameObject();
		canvasObject.AddComponent<GameCanvas>();
	}
}
