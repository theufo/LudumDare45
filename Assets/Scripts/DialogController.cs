using UnityEngine;

public class DialogController : MonoBehaviour
{
    private PlayerController playerController;
    public MapItemController MapItemController;

    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("PlayerGO").GetComponent<PlayerController>();
    }

    public void GetFreeDeck()
    {
        playerController.GetStarterCards();

        var freeDeckButton = this.transform.Find("FreeDeckButton");
        freeDeckButton.gameObject.SetActive(false);

        var uIMenuController = GameObject.FindGameObjectWithTag("UIMenuGO").GetComponent<UIMenuController>();
        uIMenuController.CloseDialog();
        uIMenuController.OpenInventory();
    }


    public void Challenge()
    {
        Debug.Log("Challange!");
    }
}
