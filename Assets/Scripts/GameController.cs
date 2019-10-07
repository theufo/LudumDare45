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
    public OpenBoosterController OpenBoosterController;

    void Start()
    {
        DontDestroyOnLoad(this);

        DeckController.GenerateInitialCardSet();

        UpdateMapItems();

        StoryController.SetStoryText("You have moved to your new room and found some stuff leaved here by previous tenant. Among these things you found a Witchcraft: the Collecting card \"Start with nothing\" and a flyer from some local club, where you can receive your first deck for free \n\n Let's have a look at your inventory!");
        UIMenuController.OpenInventory();
    }

    public void UpdateMapItems()
    {
        foreach( var mapItem in MapItems)
        {
            var controller = mapItem.GetComponent<MapItemController>();
            if (PlayerController.CheckLevels(controller.RequiredPlayerLevel, controller.RequiredDeckLevel))
            {
                if (!mapItem.activeSelf)
                {
                    mapItem.gameObject.SetActive(true);
                    if (controller.Index == 7)
                    {
                        StoryController.SetStoryText("CONGRATULATIONS!!! \n" +
                            "Now you can compete with the best Witchery players in the world! \n\n" +
                            "Check out the map" );
                    }
                }
            }
            else
            {
                if(mapItem.activeSelf)
                    mapItem.gameObject.SetActive(false);
            }
        }
    }
}