using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject MapItemPrefab;
    public List<GameObject> MapItems;

    public PlayerController PlayerController;


    void Start()
    {
        PlayerController = GameObject.FindGameObjectWithTag("PlayerGO").GetComponent<PlayerController>();

        DontDestroyOnLoad(this);

        UpdateMapItems();
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