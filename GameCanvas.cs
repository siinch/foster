using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AdaptivePerformance.Provider;
using UnityEngine.UI;

public class GameCanvas : MonoBehaviour
{
    private float pixelsPerUnit = 20.0f;
    public static Text energyText;
    void Awake()
    {
        name = "Canvas";

        gameObject.AddComponent<Canvas>();
        var canvas = gameObject.GetComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;

        gameObject.AddComponent<CanvasScaler>();
        var scaler = gameObject.GetComponent<CanvasScaler>();
        scaler.screenMatchMode = CanvasScaler.ScreenMatchMode.MatchWidthOrHeight;
        scaler.matchWidthOrHeight = 0.5f;
        scaler.referenceResolution = new Vector2(1920.0f, 1080.0f);

        var energyIcon = new GameObject();
        energyIcon.transform.parent = transform;
        energyIcon.AddComponent<Image>();
        var energyImage = energyIcon.GetComponent<Image>();
        var texture = Game.instance.energyTexture;
        Sprite sprite = Sprite.Create(
        texture,
        new Rect(0.0f, 0.0f, texture.width, texture.height),
			new Vector2(0.5f, 0.5f),
			pixelsPerUnit
		);
        energyImage.sprite = sprite;
        var energyIconRT = energyIcon.GetComponent<RectTransform>();
        energyIconRT.sizeDelta = new Vector2(texture.width, texture.height);
        energyIconRT.localPosition = new Vector2(-900.0f, 500.0f);

        var energyValue = new GameObject();
        energyValue.transform.parent = transform;
        energyValue.AddComponent<Text>();
        energyText = energyValue.GetComponent<Text>();
        energyText.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
		var energyValueRT = energyValue.GetComponent<RectTransform>();
		energyValueRT.localPosition = new Vector2(-820.0f, 465.0f);
	}
}
