using UnityEngine;

public class UIMenuController : MonoBehaviour
{
    public Canvas UICanvas;
    public Canvas GameMenuCanvas;
    public GameObject Inventory;
    public GameObject CardDex;

    public void OpenInventory()
    {
        Inventory.gameObject.SetActive(true);
        UICanvas.gameObject.SetActive(false);
    }

    public void CloseInventory()
    {
        Inventory.gameObject.SetActive(false);
        UICanvas.gameObject.SetActive(true);
    }
    public void OpenCardDex()
    {
        CardDex.gameObject.SetActive(true);
        UICanvas.gameObject.SetActive(false);
    }

    public void CloseCardDex()
    {
        CardDex.gameObject.SetActive(false);
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