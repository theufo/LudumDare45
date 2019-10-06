using UnityEngine;
using UnityEngine.UI;

public class MapItemController : MonoBehaviour
{
    public string Name;
    public int Index;
    public int RequiredPlayerLevel;
    public int RequiredDeckLevel;

    public GameController GameController;
    public PlayerController PlayerController;
    public DialogController DialogController;
    public StoryController StoryController;
    public Text Text;

    void Start()
    {
        Text.text = Name;
        GameController = GameObject.FindGameObjectWithTag("GameGO").GetComponent<GameController>();
        PlayerController = GameObject.FindGameObjectWithTag("PlayerGO").GetComponent<PlayerController>();
        DialogController = GameController.DialogController;
        StoryController = GameController.StoryController;
    }

    public void Initialized(string name, int Index, int requiredPlayerLevel, int requiredDeckLevel)
    {
        Name = name;
        RequiredPlayerLevel = requiredPlayerLevel;
        RequiredDeckLevel = requiredDeckLevel;
    }

    void OnMouseDown()
    {
        DialogController.Canvas.gameObject.SetActive(true);

        if (Index == 1 && PlayerController.CardDeck.Count < 10)
        {
            DialogController.FreeDeckButton.gameObject.SetActive(true);
            StoryController.SetStoryText("Welcome to our club! \n Have you ever played Witchcraft: the collecting? \n We have free decks for newcomers");
        }
        else
            DialogController.FreeDeckButton.gameObject.SetActive(false);
    }
}