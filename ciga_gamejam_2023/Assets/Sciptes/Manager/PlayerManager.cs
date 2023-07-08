using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject player1Prefab, player2Prefab;
    [SerializeField] private Transform player1SpawnPoint, player2SpawnPoint;
    private void Awake()
    {
        SpawnPlayer();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnPlayer()
    {
        Instantiate(player1Prefab, player1SpawnPoint.position, player1SpawnPoint.rotation);
        Instantiate(player2Prefab, player2SpawnPoint.position, player2SpawnPoint.rotation);
    }

}
