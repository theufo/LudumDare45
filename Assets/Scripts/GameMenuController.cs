using UnityEngine;

public class GameMenuController : MonoBehaviour
{
    public Canvas UICanvas;
    public Canvas GameMenuCanvas;
    public GameObject Inventory;
    public PopulateGrid PopulateGrid;

    public void OpenInventory()
    {
        Inventory.gameObject.SetActive(true);
        UICanvas.gameObject.SetActive(false);
        //PopulateGrid.Populate(DeckController.CardsList);
    }

    public void CloseInventory()
    {
        Inventory.gameObject.SetActive(false);

        UICanvas.gameObject.SetActive(true);
    }

    public void OpenGameMenu()
    {
        UICanvas.gameObject.SetActive(false);
        GameMenuCanvas.gameObject.SetActive(true);
    }


    public void CloseGameMenu()
    {
        UICanvas.gameObject.SetActive(true);
        GameMenuCanvas.gameObject.SetActive(false);
    }
}