using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject MapItemPrefab;
    public List<GameObject> MapItems;

    public PlayerController PlayerController;
    public DeckController  DeckController;
    public DialogController DialogController;
    public StoryController StoryController;
    public UIMenuController UIMenuController;
    public ChallengeController ChallengeController;


    void Start()
    {
        //PlayerController = GameObject.FindGameObjectWithTag("PlayerGO").GetComponent<PlayerController>();
        //DeckController = GameObject.FindGameObjectWithTag("DeckGO").GetComponent<DeckController>();
        //DialogController = GameObject.FindGameObjectWithTag("Dialog").GetComponent<DialogController>();
        //StoryController = GameObject.FindGameObjectWithTag("StoryGO").GetComponent<StoryController>();

        DontDestroyOnLoad(this);

        DeckController.GenerateInitialCardSet();

        UpdateMapItems();

        StoryController.SetStoryText("You have moved to your new room and found some stuff leaved here by previous tenant. Among these things you found a WtC card \"Start with nothing\" and a flyer from some local club, where you can receive your first deck for free \n\n Let's have a look at your inventory!");
        UIMenuController.OpenInventory();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadPlus)) {
            PlayerController.ChangePlayerLevel(1);
            PlayerController.ChangeDeckLevel(1);
        }
        if (Input.GetKeyDown(KeyCode.KeypadMinus)) {
            PlayerController.ChangePlayerLevel(-1);
            PlayerController.ChangeDeckLevel(-1);
        }
    }

    public void UpdateMapItems()
    {
        foreach( var mapItem in MapItems)
        {
            var controller = mapItem.GetComponent<MapItemController>();
            if (PlayerController.CheckLevels(controller.RequiredPlayerLevel, controller.RequiredDeckLevel))
                mapItem.gameObject.SetActive(true);
            else
                mapItem.gameObject.SetActive(false);
        }
    }
}