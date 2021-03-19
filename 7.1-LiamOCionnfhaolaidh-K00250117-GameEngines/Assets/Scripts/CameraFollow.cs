using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    // The player GameObject that I want the camera to follow
    public GameObject player;

    // If the disableVerticalFollow boolean is set to true (which you can do via the 
    // inspector) then the camera won't follow the player vertically
    public bool disableVerticalFollow;

    // If you rather not have the camera positions at the exact centre of your player
    // then you can use these offsets. Note the vertical offset does not work if 
    // disableVerticalFollow is true.
    public float horizontalOffset;
    public float verticalOffset;

    // This is the amount the character can move before the camera will start to follow it
    public float verticalBuffer;



    // LateUpdate is called after all Update functions have been called
    // See: https://docs.unity3d.com/ScriptReference/MonoBehaviour.LateUpdate.html
    //
    void LateUpdate()
    {
        // I better check to make sure the player game object is not null (maybe it was
        // destroyed)
        if (player != null)
        {
            // Set the camera's x pos to be the same as the players plus any offset BUT only if the
            // player's x has moved greater than the horizontalBuffer

            // Set camXPos to be the camera's current x position
            float camXPos = player.transform.position.x + horizontalOffset;

            float camYPos;

            if (disableVerticalFollow == true)
            {
                // Set the camera's y position to be what it currently is (i.e. don't change it)
                camYPos = transform.position.y;
            }
            else
            {
                camYPos = transform.position.y;


                if (Mathf.Abs(camYPos - player.transform.position.y) > verticalBuffer)
                {
                    // Set the camera's y position to be the same as the players plus any offset
                    camYPos = player.transform.position.y + verticalOffset;

                }

            }

            // Update my (the camera) position to reflect the players position
            transform.position = Vector3.Lerp(transform.position, new Vector3(camXPos, camYPos, transform.position.z), 0.2f);

        }
    }
}