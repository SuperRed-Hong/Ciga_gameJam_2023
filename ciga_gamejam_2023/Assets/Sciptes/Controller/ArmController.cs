using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmController : MonoBehaviour
{
    //[SerializeField] private CapsuleCollider2D hand;
    [SerializeField] private float growthRate;
    private Transform player; // 玩家的Transform组件
    private Vector3 originalScale;
    private bool canCatch; 

    public void SetPlayer(Transform p){
        player=p;
        originalScale=transform.localScale;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            if(canCatch){
                Debug.Log("Catch!");
                //catch!
            }
        }
        // 计算玩家相对于箭头的方向
        Vector3 direction = player.position - transform.position;

        // 将箭头旋转到指向玩家的方向
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    private void OnTriggerEnter2D(Collider2D collider){
        if(collider.transform==player){
            canCatch=true;
        }
    }
    private void OnTriggerExit2D(Collider2D collider){
        if(collider.transform==player){
            canCatch=false;
        }
    }
    public void GrowArmLength()
    {
        Vector3 newScale = transform.localScale;
        newScale.x += growthRate * Time.deltaTime;
        newScale.y += growthRate * Time.deltaTime;

        transform.localScale = newScale;
    }
    public void ResetArmLength(){
        transform.localScale = originalScale;
    }
    
}
