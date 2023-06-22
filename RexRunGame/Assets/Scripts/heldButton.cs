using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//This line means that thi script can only be attatched
//To a GameObject that has a button component
[RequireComponent(typeof(Button))]


//The additional items in this list let us respond to mouse/touch events
public class heldButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    //We will store our button here so we can use it
    private Button button;

    private bool buttonPressed = false; //Use this to track whether the button is pressed

    //This function gets called by unity when the user first clicks the button
    public void OnPointerDown(PointerEventData eventData)
	{
        //Ignore if the button is not interactable
        if (!button.interactable) return;

        //Record that the button is being pressed
        buttonPressed = true;
	}

    //Called by Unity when the user moves their funger off the button,
    //While it was still held down
    public void OnPointerExit(PointerEventData eventData)
    {
        //Will record that the button is no longer pressed
        buttonPressed = false;
    }

    //Called by Unity when the user releases the button
    public void OnPointerUp(PointerEventData eventData)
    {
        //Will record that the button is no longer pressed
        buttonPressed = false;
    }

    // Awake is called before anything else on this script
    void Awake()
    {
        button = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        //If we recorded that the button has been pressed
       if (buttonPressed)
		{
            //Call the onClick function set up in unity for this button
            button.onClick?.Invoke();
		}
    }
}
