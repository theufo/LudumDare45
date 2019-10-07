using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine;

public class TearBoosterController : MonoBehaviour
{
    public List<GameObject> Sprites;

    private int currentSprite = 0;

    public void Initialize()
    {
        currentSprite = 0;
        Sprites[currentSprite].SetActive(true);
    }

    public TearBoosterEnum TearNext()
    {
        if (Sprites.Count <= currentSprite)
            return TearBoosterEnum.False;

        Sprites[currentSprite].SetActive(false);

        if (Sprites.Count > currentSprite + 1)
            Sprites[currentSprite + 1].SetActive(true);
        else
            return TearBoosterEnum.Last;

        if (Sprites.Count <= currentSprite)
            return TearBoosterEnum.False;

        currentSprite++;

        return TearBoosterEnum.True;
    }
}