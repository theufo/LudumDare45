using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine;

public class DeckController : MonoBehaviour
{
    public GameObject Card; 
    public static List<GameObject> CardsList; 
    public Sprite CommonCard;
    public Sprite UncommonCard;
    public Sprite RareCard;
    public Sprite MythicCard;
    public Sprite FoilTexture;
    public GameObject PopulateGrid;

    private int totalCards = 150;

    void Start()
    {
        CardsList = new List<GameObject>(); 
    }

    void Update()
    {
        
    }

    public void GenerateInitialCardSet()
    {
        if (CardsList == null)
            CardsList = new List<GameObject>();

        for (int i = 1; i <= totalCards; i= i+2)
        {
            var name = "name";
            var card = Instantiate(Card, PopulateGrid.gameObject.transform);
            var cardController = card.GetComponent<CardController>();
            if (i <= 80) {
                cardController.Initialize(name, i, RarityEnum.Common, CommonCard);
                cardController.Initialize(name, i, RarityEnum.Common, CommonCard, true);
            }
            else if (i > 80 && i <=120)
            {
                cardController.Initialize(name, i, RarityEnum.Uncommon, UncommonCard);
                cardController.Initialize(name, i, RarityEnum.Uncommon, UncommonCard, true);
            }
            else if (i > 120 && i <=140)
            {
                cardController.Initialize(name, i, RarityEnum.Rare, RareCard);
                cardController.Initialize(name, i, RarityEnum.Rare, RareCard, true);
            }
            else if (i > 120 && i <=140)
            {
                cardController.Initialize(name, i, RarityEnum.Mythic, MythicCard);
                cardController.Initialize(name, i, RarityEnum.Mythic, MythicCard, true);
            }

            CardsList.Add(card);
        }
    }
}