using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour
{
    public Rigidbody2D rb2D;//自己的刚体
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GateUp",2.0f,4.0f);
        InvokeRepeating("GateStop",2.8f,2.0f);
        InvokeRepeating("GateDown",4.0f,4.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GateUp(){
        rb2D.velocity=new Vector2(0f, 5f);
    }

    public void GateDown(){
        rb2D.velocity=new Vector2(0f, -5f);
    }

    public void GateStop(){
        rb2D.velocity=new Vector2(0f,0f);
    }

}
