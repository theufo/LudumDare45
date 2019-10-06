using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int PlayerLevel; 
    public int DeckLevel;
    public List<GameObject> CardDeck;
    public int UniqueCardsCount;
    public int minDeck = 10;

    public GameController GameController;
    public GameObject InventoryPopulateGrid;

    public UIMenuController UIMenuController;


    void Start()
    {
        CardDeck = new List<GameObject>();
        GameController = GameObject.FindGameObjectWithTag("GameGO").GetComponent<GameController>();
        UIMenuController = GameObject.FindGameObjectWithTag("UIMenuGO").GetComponent<UIMenuController>();
        DontDestroyOnLoad(this);
    }

    public void GetStarterCards()
    {
        var cards = DeckController.GetStarterCards();
        SortCards(ref cards);
        foreach (var card in cards)
        {
            var copy = Instantiate(card, InventoryPopulateGrid.transform);
            copy.GetComponent<CardController>().SetSellable(true);
            CardDeck.Add(copy);
        }
    }

    public void SortCards(ref List<GameObject> gameObjects)
    {
        gameObjects.Sort((a, b) => {
            var asd =  a.GetComponent<CardController>().CompareTo(b.GetComponent<CardController>());
            return asd;
        });
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
        UIMenuController.UpdatePlayerLevel(PlayerLevel);
        GameController.UpdateMapItems();
    }

    public void ChangeDeckLevel(int value)
    {
        DeckLevel += value;
        UIMenuController.UpdateDeckLevel(DeckLevel);
        GameController.UpdateMapItems();
    }

    public void UpdateDeckLevel(GameObject card)
    {
        var cardController = card.GetComponent<CardController>();

        int value = (int)cardController.Rarity;
        if (cardController.IsFoil)
            value *= 2;

        DeckLevel += value;
        UIMenuController.UpdateDeckLevel(DeckLevel);
        GameController.UpdateMapItems();
    }
}