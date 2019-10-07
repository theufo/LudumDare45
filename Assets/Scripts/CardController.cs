using Assets.Scripts;
using System;
using UnityEngine;
using UnityEngine.UI;

public class CardController : MonoBehaviour, IComparable<CardController>
{
    public string Name;
    public int Number;
    public RarityEnum Rarity;
    public bool IsFoil;
    public bool Discovered;
    private bool sellable;

    public Sprite  CardSprite;
    public GameObject FoilGameObject;
    public GameObject UndiscoveredGameObject;
    public GameObject Back;
    public Text NameText;
    public Text NumberText;
    public Text RarityText;
    public Button SellButton;

    public GameController GameController;
    public PlayerController PlayerController;

    void Start()
    {
        PlayerController = GameObject.FindGameObjectWithTag("PlayerGO").GetComponent<PlayerController>();
        GameController = GameObject.FindGameObjectWithTag("GameGO").GetComponent<GameController>();
    }

    public void Initialize(string name, int number, RarityEnum rarityEnum, Sprite cardSprite,bool sellable = false, bool isFoil = false)
    {
        Name = name;
        Number = number;
        Rarity = rarityEnum;
        CardSprite = cardSprite;
        if (isFoil)
        {
            IsFoil = isFoil;
            FoilGameObject.SetActive(true);
        }
        SetSellable(sellable);
        var image = gameObject.GetComponent<Image>();
        image.sprite = CardSprite;

        NameText.text = name;
        RarityText.text = Rarity.ToString();
        if (Rarity == RarityEnum.Uncommon)
            RarityText.fontSize = 16;
        NumberText.text = Number + " / 150";
    }

    public void SetSellable(bool sellable)
    {
        this.sellable = sellable;

        if (sellable)
            SellButton.gameObject.SetActive(true);
        else
            SellButton.gameObject.SetActive(false);
    }

    public void Discover()
    {
        if (!Discovered)
        {
            Discovered = true;
            NameText.gameObject.SetActive(true);
            NumberText.gameObject.SetActive(true);
            RarityText.gameObject.SetActive(true);
            UndiscoveredGameObject.SetActive(false);
        }
    }
    public int CompareTo(CardController p)
    {
        if (this.Number > p.Number)
            return 1;
        else if (this.Number < p.Number)
            return -1;
        else
            return 0;
    }

    public void SellCard()
    {
        if (PlayerController.CardDeck.Count > PlayerController.minDeck)
        {
            var value = (int)Rarity;
            if (IsFoil)
                value *= 2;

            PlayerController.ChangePlayerLevel(value);
            PlayerController.CardDeck.Remove(this.gameObject);
            Destroy(this.gameObject);
        }
        else
            GameController.StoryController.SetStoryText("To be able to play tournaments, player's deck must consist at least 10 cards!");

    }
}