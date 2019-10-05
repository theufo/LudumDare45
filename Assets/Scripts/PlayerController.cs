using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int PlayerLevel; 
    public int DeckLevel;
    public List<GameObject> CardDeck;
    public int UniqueCardsCount;

    public GameController GameController;
    public GameObject InventoryPopulateGrid;


    void Start()
    {
        CardDeck = new List<GameObject>();
        GameController = GameObject.FindGameObjectWithTag("GameGO").GetComponent<GameController>();
        DontDestroyOnLoad(this);
    }

    public void GetStarterCards()
    {
        var cards = DeckController.GetStarterCards();
        foreach (var card in cards)
        {
            var copy = Instantiate(card, InventoryPopulateGrid.transform); 
            CardDeck.Add(copy);
        }
    }

    public bool CheckLevels(int playerLevel, int playerDeck)
    {
        if (PlayerLevel >= playerDeck && DeckLevel >= playerDeck)
            return true;

        return false;
    }

    public void ChangePlayerLevel(int value)
    {
        PlayerLevel += value;
    }

    public void ChangeDeckLevel(int value)
    {
        DeckLevel += value;
    }
}