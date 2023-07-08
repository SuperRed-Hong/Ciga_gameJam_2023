using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmController : MonoBehaviour
{
    private Transform player; // 玩家的Transform组件

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
        }
    }
}
