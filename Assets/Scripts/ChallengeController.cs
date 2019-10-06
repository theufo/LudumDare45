using Assets.Scripts;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChallengeController : MonoBehaviour
{
    private float prepareTime = 2f;
    private float challengeTime = 2f;
    private float time;
    private bool started;
    private ChallengeState ChallengeState;

    void Start()
    {
        StartCoroutine(Challenge());
    }

    IEnumerator Challenge()
    {
        if(ChallengeState == ChallengeState.Prepare)
        {
            if (!started)
            {
                time = Time.realtimeSinceStartup;
            }
            //if (time >= time + )
        }
        yield return null;
    }

    public void CloseChallenge()
    {
        SceneManager.LoadScene("GameScene");
    }
}