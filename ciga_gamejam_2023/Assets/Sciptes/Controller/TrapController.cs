using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag=="Player"){
            PlayerController playerCaught=other.gameObject.GetComponent<PlayerController>();
            //playerCaught.InDizziness();
            yield return new WaitForSeconds(0.8f);
            //playerCaught.OutDizziness();
            Destroy(this.gameObject);
        }
    }
}
