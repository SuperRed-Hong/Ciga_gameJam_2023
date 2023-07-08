using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject player1Prefab, player2Prefab;
    [SerializeField] private Transform player1SpawnPoint, player2SpawnPoint;
    [SerializeField] private float growMaxDistance;
    [SerializeField] private int growMaxTime;
    private int growTime;
    private GameObject player1;//抓人者
    private GameObject player2;//被抓者
    private ArmController arm1;

    private void Awake()
    {
        SpawnPlayer();
    }
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CheckByTime",0f,Time.deltaTime);
        //Debug.Log(Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnPlayer()
    {
        player1 = Instantiate(player1Prefab, player1SpawnPoint.position, player1SpawnPoint.rotation);
        player2 = Instantiate(player2Prefab, player2SpawnPoint.position, player2SpawnPoint.rotation);
        player1.transform.SetParent(GameObject.Find("PlayGround").transform);
        player2.transform.SetParent(GameObject.Find("PlayGround").transform);
        player1.GetComponent<PlayerController>().SetOpponent(player2.GetComponent<PlayerController>());
        player2.GetComponent<PlayerController>().SetOpponent(player1.GetComponent<PlayerController>());
        arm1=player1.GetComponentInChildren<ArmController>();
        arm1.SetPlayer(player2.transform);
    }

    public void CheckByTime(){
        if(DetectDistance()<growMaxDistance){
            if(growTime < growMaxTime){
                ++growTime;
                arm1.GrowArmLength();
            }
        }else{
            growTime=0;
            arm1.ResetArmLength();
        }
    }

    public float DetectDistance(){
        return (player1.transform.position - player2.transform.position).magnitude;
    }

    public void GiveSkill(PlayerController player, Skill skill){
        player.SetSkill(skill);
    }

}
