using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmController : MonoBehaviour
{
    [SerializeField]
    private float growthRate = 0.1f;
    private Transform player; // 玩家的Transform组件
    [SerializeField] private Collider2D DetectArea;

    public void SetPlayer(Transform p){
        player=p;
    }

    private void Update()
    {
        if (player != null)
        {
            // 计算玩家相对于箭头的方向
            Vector3 direction = player.position - transform.position;

            // 将箭头旋转到指向玩家的方向
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            GrowArmLength();


        }
    }
    public void GrowArmLength()
    {
        Vector3 newScale = transform.localScale;
        newScale.x += growthRate * Time.deltaTime;
        newScale.y += growthRate * Time.deltaTime;

        transform.localScale = newScale;
    }
  
}
