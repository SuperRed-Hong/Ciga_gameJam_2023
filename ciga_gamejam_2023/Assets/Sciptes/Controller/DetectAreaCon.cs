using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectAreaCon : MonoBehaviour
{
    public GameObject Playerhand;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Detecting player : " + collision.ToString());

            Playerhand.GetComponent<ArmController>().GrowArmLength();
        }
    }
    
}
