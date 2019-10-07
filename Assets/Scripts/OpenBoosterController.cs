using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine;

public class OpenBoosterController : MonoBehaviour
{
    public GameObject BoosterPrefab;
    private List<GameObject> Cards;
    public TearBoosterController TearBoosterController;
    private int currentCard = 0;
    public GameObject InnerGameObject;
    public GameObject ObjectForCards;
    private bool cardsEnabled;
    private GameObject boosterInstance;

    void Start()
    {

    }

    public void Next()
    {
        var tearBoosterEnum = TearBoosterController.TearNext();
        if (tearBoosterEnum == TearBoosterEnum.True)
        {

        }
        else 
        {
            //if (tearBoosterEnum == TearBoosterEnum.Last)
            if (!cardsEnabled)
            {
                ObjectForCards.SetActive(true);
                cardsEnabled = true;
                return;
            }

            if (OpenNextCard())
            {
            }
            else
            {
                Close();
            }
        }
    }

    public void Initialize(List<GameObject> gameObjects)
    {
        boosterInstance = Instantiate(BoosterPrefab, InnerGameObject.transform);
        TearBoosterController = boosterInstance.GetComponent<TearBoosterController>();
        TearBoosterController.Initialize();

        currentCard = 0;
        ObjectForCards.SetActive(false);
        Cards = new List<GameObject>();
        foreach(var card in gameObjects)
        {
            var newcard = Instantiate(card, ObjectForCards.transform);
            newcard.GetComponent<CardController>().SetToBack();
            Cards.Add(newcard);
        };
    }

    public void Close()
    {
        InnerGameObject.SetActive(false);
        foreach (var card in Cards)
        {
            Destroy(card);
        }
        Destroy(boosterInstance);

        cardsEnabled = false;
    }

public bool OpenNextCard()
    {
        if (Cards.Count <= currentCard)
            return false;

        Cards[currentCard].GetComponent<CardController>().SetToFront();
        currentCard++;

        return true;
    }
}