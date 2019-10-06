using Assets.Scripts;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChallengeController : MonoBehaviour
{
    private float prepareTime = 2f;
    private float challengeTime = 15f;
    private float time;
    private bool started;
    private ChallengeState ChallengeState;

    public Canvas Canvas;
    public Text ChallengeName;
    public Text TimeText;
    public Text StateText;

    void Start()
    {
    }

    public void StartChallenge()
    {
        Canvas.gameObject.SetActive(true);
        ChallengeState = ChallengeState.Prepare;
        StartCoroutine(Challenge());
    }

    public void Initialize(string name)
    {
        ChallengeName.text = name;
    }

    IEnumerator Challenge()
    {
        while(ChallengeState == ChallengeState.Prepare)
        {
            TimeText.text = (time + prepareTime - Time.realtimeSinceStartup).ToString("n2");
            if (!started)
            {
                time = Time.realtimeSinceStartup;
                StateText.text = ChallengeState.ToString();
                started = true;
            }
            else if (Time.realtimeSinceStartup >= time + prepareTime)
            {
                ChallengeState = ChallengeState.Challenge;
                started = false;
            }

            yield return null;
        }
        while (ChallengeState == ChallengeState.Challenge)
        {
            TimeText.text = (time + challengeTime - Time.realtimeSinceStartup).ToString("n2");
            if (!started)
            {
                time = Time.realtimeSinceStartup;
                StateText.text = ChallengeState.ToString();
                started = true;
            }
            else if (Time.realtimeSinceStartup >= time + challengeTime)
            {
                ChallengeState = ChallengeState.Reward;
                started = false;
            }

            yield return null;
        }
        while(ChallengeState == ChallengeState.Reward)
        {

            yield return null;
        }

        yield return null;
    }

    public void CloseChallenge()
    {
        Canvas.gameObject.SetActive(false);
    }
}