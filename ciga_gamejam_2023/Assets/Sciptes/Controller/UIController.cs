using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Cecil;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    public Camera mainCamera;
    [Header("Prefabs")]
    public PopUpUI popUpPrefab; //结束弹窗
    public GameObject stopPrefab;   // 暂停弹窗
    public GameObject scorePrefab; //分数弹窗
    public GameObject chooseCardPrefab;   // 抽卡弹窗
    //public Button ReplayButton;
    [Header("GameObjects")]
    public Transform canvasRoot;
    public TextMeshProUGUI doctorScore;
    public TextMeshProUGUI patientScore;
    public TextMeshProUGUI turnNumber;
    public GameObject ContinueButton;

    private ScoreManager scoreManager;

    public float timeleft;
    public TextMeshProUGUI CountDown_tet;
    //private bool isCounting;

    public AudioManager audioManager;

    public void Awake()
    {
        audioManager = GetComponent<AudioManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //isCounting = true;
        //testScene(4);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (isCounting)
        {
            timeleft -= Time.deltaTime;
        }
        CountDown_tet.text = timeleft.ToString(format: "0");
        if(timeleft <= 0 && isCounting)
        {
            isCounting = false;
        }*/
    }


    public void stop()
    {
        audioManager.AudioPlay(6);
        //Time.timeScale = 0;
        Instantiate(stopPrefab, canvasRoot);
    }

    public void back()
    {
        audioManager.AudioPlay(6);
        SceneManager.LoadScene("Start game");
    }

    public void score()
    {
        audioManager.AudioPlay(6);
        Instantiate(scorePrefab, canvasRoot);
        Invoke("chooseCard", 3.1f);
    }

    public void chooseCard()
    {
        audioManager.AudioPlay(6);
        Instantiate(chooseCardPrefab, canvasRoot);
    }

    public void SetTimeText(float time){
        CountDown_tet.text = timeleft.ToString(format: "0");
    }

}

