using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public CardController cardControllerPrefab;
    public static CardManager instance;
    
    public Transform player1Hand, player2Hand;
    public List<Card>    catchCardDeck = new List<Card>(), runCardDeck = new List<Card>();
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }
    public void GenerateCardsForCatcher(bool chara)
    {
        Transform playArea;
        if (chara)
        {
            playArea = player1Hand;
        }
        else
        {
            playArea = player2Hand;
        }
        int i = Random.Range(0,4);
        Card newCard = catchCardDeck[i];
        CardController cardController = Instantiate(cardControllerPrefab , playArea);
        cardController.transform.localPosition = Vector3.zero;
        cardController.Initialize(newCard);
    }
    public void GenerateCardsForRunner(bool chara)
    {
        Transform playArea;
        if (chara)
        {
             playArea = player1Hand;
        }
        else
        {
             playArea = player2Hand;
        }

        int i = Random.Range(0, 4);
        Card newCard = runCardDeck[i];
        CardController cardController = Instantiate(cardControllerPrefab, playArea);
        cardController.transform.localPosition = Vector3.zero;
        cardController.Initialize(newCard);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
