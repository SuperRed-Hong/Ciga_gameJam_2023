using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : PlayerController
{
    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal2");
        moveVertical = Input.GetAxisRaw("Vertical2");
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(currentOneWayPlayform != null && currentOneWayPlayform.tag!= "Platform" && !dizziness)
            {
                StartCoroutine(DisableCollision());
            }
        }

    }
}
