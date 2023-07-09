using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCountDown : Checker
{
    private float RemainTime=10;
    private int timeCount=0;
    private int RefreshCount;
    private ArmController arm;
    public TimeCountDown(PlayerManager manager){
        this.manager=manager;
        RefreshCount=(int)(1f/Time.deltaTime);
        timeCount=0;
        Debug.Log(RefreshCount);
        Debug.Log(Time.deltaTime);
    }
    public override int Check(){
        RemainTime-=Time.deltaTime;
        if((timeCount++)%RefreshCount==0){
            manager.RefreshTime(RemainTime);
        }
        if(RemainTime<=0){
            manager.EndGame(false);
        }
        return 0;
    }
}
