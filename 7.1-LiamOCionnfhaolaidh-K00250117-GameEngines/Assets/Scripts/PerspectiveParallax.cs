using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerspectiveParallax : MonoBehaviour
{


    public GameObject player;
    private Vector3 movedPosition;

    private void Start()
    {
        movedPosition = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + movedPosition;
    }
}
