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
    public Text Text;

    void Start()
    {
        Text.text = Name;
        GameController = GameObject.FindGameObjectWithTag("GameGO").GetComponent<GameController>();
        PlayerController = GameObject.FindGameObjectWithTag("PlayerGO").GetComponent<PlayerController>();
        //DialogController = GameObject.FindGameObjectWithTag("Dialog").GetComponent<DialogController>();

    }

    public void Initialized(string name, int Index, int requiredPlayerLevel, int requiredDeckLevel)
    {
        Name = name;
        RequiredPlayerLevel = requiredPlayerLevel;
        RequiredDeckLevel = requiredDeckLevel;
    }

    void OnMouseDown()
    {
        DialogController.gameObject.SetActive(true);

        if (Index == 1 && PlayerController.CardDeck.Count < 10)
        {
            var freeDeckButton = DialogController.transform.Find("FreeDeckButton");
            freeDeckButton.gameObject.SetActive(true);
        }
    }
}