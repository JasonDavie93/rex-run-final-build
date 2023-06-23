using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmourBar : MonoBehaviour
{

	//declare a public slider variable named "slider"
	public Slider slider;
	// Define a public method named "SetMaxArmour" that takes an integer parameter "armour"
	public void SetMaxArmour(int armour)
	{
		// Set the maximum value of the slider to the given armour value
		slider.maxValue = armour;
		// Set the current value of the slider to the given armour value
		slider.value = armour;
	}
	// Define a public method named "SetArmour" that takes an integer parameter "armour"
	public void SetArmour(int armour)
	{// Set the current value of the slider to the given armour value
		slider.value = armour;
	}
}
