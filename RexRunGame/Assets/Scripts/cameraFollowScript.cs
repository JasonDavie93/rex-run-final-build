using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollowScript : MonoBehaviour
{
    public Transform followTransform;   // Declare a public Transform variable named "followTransform"
    //public BoxCollider2D mapBounds;
    // Declare private float variables for camera bounds and camera properties
    private float xMin, xMax, yMin, yMax;
    private float camY, camX;
    private float camOrthsize;
    private float cameraRatio;
    private Camera mainCam;

	private void Start()
	{

        //xMin = mapBounds.bounds.min.x;
        // xMax = mapBounds.bounds.max.x;
        //yMin = mapBounds.bounds.min.y;
        //yMax = mapBounds.bounds.max.y;
      
        // Get the Camera component attached to the same GameObject and assign it to the "mainCam" variable
        mainCam = GetComponent<Camera>();
        // Get the orthographic size of the Camera and assign it to the "camOrthsize" variable
        camOrthsize = mainCam.orthographicSize;
        // Calculate the camera ratio based on the maximum x value and the camera orthographic size
        cameraRatio = (xMax + camOrthsize) / 2.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Check if the "followTransform" variable is not null, indicating there is a transform to follow
        if (followTransform != null)
        {
            // Clamp the y position of the followTransform between the camera's vertical bounds
            camY = Mathf.Clamp(followTransform.position.y, yMin + camOrthsize, yMax - camOrthsize);
            // Clamp the x position of the followTransform between the camera's horizontal bounds
            camX = Mathf.Clamp(followTransform.position.x, xMin + cameraRatio, xMax - cameraRatio);
            // Update the position of the camera to follow the followTransform's position, while maintaining the z position
            this.transform.position = new Vector3(followTransform.position.x, followTransform.position.y, this.transform.position.z);
        }
    }
}
