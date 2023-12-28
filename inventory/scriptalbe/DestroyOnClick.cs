using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DestroyOnClick : MonoBehaviour
{
    void Update()
    {
        if (Input.touchCount > 0) // Check if there is any touch
        {
            Touch touch = Input.GetTouch(0); // Get the first touch

            if (touch.phase == TouchPhase.Began) // Check if the touch phase is began
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject == gameObject) // Check if the hit object is this object
                    {
                        Destroy(gameObject); // Destroy this object
                    }
                }
            }
        }
    }
}
