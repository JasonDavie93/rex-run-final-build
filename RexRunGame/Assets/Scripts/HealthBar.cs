using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
	// Reference to the Slider component for the health bar
	public Slider slider;
	// Method to set the maximum value of the health bar
	public void SetMaxHealth(int health)
	{
		slider.maxValue = health;// Set the maximum value of the slider to the given health value
		slider.value = health;// Set the current value of the slider to the given health value
	}

	// Method to set the current value of the health bar
	public void SetHealth(int health)
	{
		slider.value = health;// Set the current value of the slider to the given health value
	}
}

