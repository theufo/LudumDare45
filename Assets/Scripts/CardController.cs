using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class CardController : MonoBehaviour
{
    public string Name;
    public int Number;
    public RarityEnum Rarity;
    public bool IsFoil;

    public Sprite  CardSprite;
    public GameObject FoilGameObject;

    void Start()
    {
        
    }

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
    }


    void Update()
    {
        
    }
}
