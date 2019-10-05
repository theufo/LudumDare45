using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int PlayerLevel; 
    public int DeckLevel;
    public List<object> CardDeck;

    public GameController GameController;


    void Start()
    {
        GameController = GameObject.FindGameObjectWithTag("GameGO").GetComponent<GameController>();
    }

    void Update()
    {
        
    }

    public bool CheckLevels(int playerLevel, int playerDeck)
    {
        if (PlayerLevel >= playerDeck && DeckLevel >= playerDeck)
            return true;

        return false;
    }

    public void ChangePlayerLevel(int value)
    {
        PlayerLevel += value;
    }

    public void ChangeDeckLevel(int value)
    {
        DeckLevel += value;
    }
}