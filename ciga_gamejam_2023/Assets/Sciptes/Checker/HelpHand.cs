using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpHand : Checker
{
    private float growMaxDistance=4f;
    private int growMaxTime=200;
    private int growTime=0;
    public HelpHand(PlayerManager manager){
        this.manager=manager;
        growTime=0;
    }
    public override int Check(){
        if(manager.DetectDistance()<growMaxDistance){
            if(growTime<growMaxTime){
                ++growTime;
                manager.GetArm().GrowArmLength();
            }
        }else{
            growTime=0;
            manager.GetArm().ResetArmLength();
        }
        return 0;
    }
}
