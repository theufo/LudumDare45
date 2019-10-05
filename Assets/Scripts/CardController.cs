using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class CardController : MonoBehaviour
{
    public string Name;
    public int Number;
    public RarityEnum Rarity;
    public bool IsFoil;
    public bool Discovered;

    public Sprite  CardSprite;
    public GameObject FoilGameObject;
    public GameObject UndiscoveredGameObject;
    public Text NameText;
    public Text NumberText;
    public Text RarityText;

    public void Initialize(string name, int number, RarityEnum rarityEnum, Sprite cardSprite, bool isFoil = false)
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
        var image = gameObject.GetComponent<Image>();
        image.sprite = CardSprite;

        NameText.text = name;
        RarityText.text = Rarity.ToString();
        if (Rarity == RarityEnum.Uncommon)
            RarityText.fontSize = 16;
        NumberText.text = Number + " / 150";
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
}
