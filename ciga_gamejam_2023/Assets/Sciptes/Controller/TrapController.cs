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
            Debug.Log("222");
            PlayerController playerCaught=other.gameObject.GetComponent<PlayerController>();
            playerCaught.InDizziness();
            //playerCaught.enabled=false;
            yield return new WaitForSeconds(0.8f);
            //other.gameObject.GetComponent<PlayerController>().enabled=true;
            playerCaught.OutDizziness();
            Destroy(this.gameObject);
        }else{
            Debug.Log("111");
        }
    }
}
