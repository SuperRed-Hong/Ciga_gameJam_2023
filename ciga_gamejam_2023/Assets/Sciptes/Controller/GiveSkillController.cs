using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveSkillController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("222");
            PlayerController playerCaught = other.gameObject.GetComponent<PlayerController>();
            playerCaught.SetSkill(new Flash(playerCaught));
            //playerCaught.enabled=false;
            //yield return new WaitForSeconds(0.8f);
            //other.gameObject.GetComponent<PlayerController>().enabled=true;
            //playerCaught.offStunned();
            //Destroy(this.gameObject);
        }
        else
        {
            Debug.Log("111");
        }
    }
}