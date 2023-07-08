using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    public Rigidbody2D elevator;
    private int state;//运行状态
    private bool inElevator;//人物是否在电梯内
    // Start is called before the first frame update
    void Start()
    {
        state=0;//初始状态（停在底部）
        inElevator=false;//初始无人在电梯内
    }

    // Update is called once per frame
    void Update()
    {

    }
    private IEnumerator OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag=="Player"){
            Debug.Log("222");
            inElevator=true;
            return ElevatorUp();
        }else{
            Debug.Log("111");
            return null;
        }
    }

    private IEnumerator ElevatorUp(){
        if(state==0 && inElevator){//从底部开始运行
            state=1;//上升状态
            elevator.velocity=new Vector2(0f, 5f);
            yield return new WaitForSeconds(1);
            elevator.velocity=new Vector2(0f, 0f);
            state=2;//到站状态
            yield return ElevatorDown();
        }
        
    }
 
    private IEnumerator OnTriggerExit2D(Collider2D other){
        if(other.gameObject.tag=="Player"){
            Debug.Log("333");
            inElevator=false;
            return ElevatorDown();
        }else{
            Debug.Log("000");
            return null;
        }
    }

    private IEnumerator ElevatorDown(){
        if(state==2 && !inElevator){//从顶部开始运行
            state=3;//下降状态
            elevator.velocity=new Vector2(0f, -5f);
            yield return new WaitForSeconds(1);
            elevator.velocity=new Vector2(0f, 0f);
            state=0;//初始状态
            yield return ElevatorUp();
        }
    }

}
