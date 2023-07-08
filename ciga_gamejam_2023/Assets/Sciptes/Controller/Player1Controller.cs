using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : PlayerController
{
    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal1");
        moveVertical = Input.GetAxisRaw("Vertical1");
        if(Input.GetKeyDown(KeyCode.S))
        {
            if(currentOneWayPlayform != null && currentOneWayPlayform.tag!= "Platform")
            {
                StartCoroutine(DisableCollision());
            }
        }

    }
}
