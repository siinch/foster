using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Energy : MonoBehaviour
{
	private float max = 100.0f;
	public float energy;
	public float flyCost = 0.02f; 

	void Start ()
	{
		energy = max;
	}

	public void Change (float amount)
	{
		energy += amount;
		GameCanvas.energyText.text = $"{energy}";
		if (energy < 0.0f)
		{
			Time.timeScale = 0.0f;
		}
	}
}
