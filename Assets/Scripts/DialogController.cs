using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogController : MonoBehaviour
{
    public GameController GameController;
    private PlayerController playerController;
    private StoryController storyController;
    private MapItemController mapItemController;

    public GameObject FreeDeckButton;
    public Canvas Canvas;

    private bool firstTime = true;

    void Start()
    {
        playerController = GameController.PlayerController;
        storyController = GameController.StoryController;
    }

    public void GetFreeDeck()
    {
        playerController.GetStarterCards();

        FreeDeckButton.gameObject.SetActive(false);

        CloseDialog();
        storyController.SetStoryText("Now you have your first ten cards out of 150 and can challenge in clubs to become the best player!\n" +
            "To unlock new clubs you must upgrade your deck by winning new cards in challenges. There are four types of card rarity: common, uncommon, rare and mythic. Each type adds different amount of prestige points to your deck. \n Selling cards gives you experience points. \n " +
            "Both experience and prestige will help you to reach new clubs.   \n " +
            "Collect them all! \n\n " +
            "Come back to the club for more cards.");
        GameController.UIMenuController.OpenInventory();
    }

    public void Challenge()
    {
        if (firstTime)
        {
            var gameController = GameObject.FindGameObjectWithTag("GameGO").GetComponent<GameController>();
            gameController.StoryController.SetStoryText("Since this is your first tournament, let me explain the rules.\n During the whole play, sometimes when your opponent will try to cast a spell the witchcraft fluent will appear. If you are lucky enough to click on that fluent, your chance to win new cards will be higher.");
            firstTime = false;
        }
        else
            GameController.ChallengeController.StartChallenge();
    }

    public void CloseDialog()
    {
        Canvas.gameObject.SetActive(false);
    }
}