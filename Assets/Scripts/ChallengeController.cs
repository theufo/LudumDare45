using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChallengeController : MonoBehaviour
{
    private float prepareTime = 2f;
    private float challengeTime = 15f;
    private float startTime;
    private float currentTime;
    private bool started;
    private ChallengeState ChallengeState;
    private int reactons = 3;

    public Canvas Canvas;
    public Text ChallengeName;
    public Text TimeText;
    public Text StateText;
    public Text Results;
    public GameObject ReactionUnitPrefab;
    public List<GameObject> ReactionUnits;
    public float?[] Reactions;
    public GameController GameController;
    public PlayerController PlayerController;

    void Start()
    {
        PlayerController = GameController.PlayerController;
    }

    public void StartChallenge()
    {
        Canvas.gameObject.SetActive(true);
        Results.gameObject.SetActive(false);

        ChallengeState = ChallengeState.Prepare;
        Initialize("123");
        StartCoroutine(Challenge());
    }

    public void Initialize(string name)
    {
        Reactions = new float?[reactons];

        ChallengeName.text = name;
        for(int i = 0; i < reactons; i++)
        {
            var xAxis = Random.Range(20, 620) / 100;
            var yAxis = Random.Range(20, 460) / 100;

            var gameObject = Instantiate(ReactionUnitPrefab, new Vector3(xAxis, yAxis, 0), Quaternion.identity, this.transform);
            gameObject.SetActive(false);
            ReactionUnits.Add(gameObject);
            var controller = gameObject.GetComponent<ReactionUnitController>();
            controller.Initialize(this, i, Random.Range(0,challengeTime - controller.Duration+1));
        }
    }

    IEnumerator Challenge()
    {
        while(ChallengeState == ChallengeState.Prepare)
        {
            currentTime = startTime + prepareTime - Time.realtimeSinceStartup;
            TimeText.text = (prepareTime - currentTime).ToString("n2");
            if (!started)
            {
                startTime = Time.realtimeSinceStartup;
                StateText.text = ChallengeState.ToString();
                started = true;
            }
            else if (Time.realtimeSinceStartup >= startTime + prepareTime)
            {
                ChallengeState = ChallengeState.Challenge;
                started = false;
            }

            yield return null;
        }
        while (ChallengeState == ChallengeState.Challenge)
        {
            currentTime = challengeTime - (startTime + challengeTime - Time.realtimeSinceStartup);
            TimeText.text = currentTime.ToString("n2");
            if (!started)
            {
                startTime = Time.realtimeSinceStartup;
                StateText.text = ChallengeState.ToString();
                started = true;
            }
            else if (Time.realtimeSinceStartup >= startTime + challengeTime)
            {
                ChallengeState = ChallengeState.Reward;
                started = false;
            }

            foreach(var unit in ReactionUnits)
            {
                var controller = unit.GetComponent<ReactionUnitController>();
                if (currentTime >= controller.StartTime && currentTime < (controller.StartTime + controller.Duration))
                {
                    unit.gameObject.SetActive(true);
                }
                else
                {
                    if(unit.gameObject.activeSelf)
                        unit.gameObject.SetActive(false);
                }
            }

            yield return null;
        }
        while(ChallengeState == ChallengeState.Reward)
        {
            if(!started)
            {
                string results = string.Empty;
                ChallengeName.text = string.Empty;
                foreach (var reaction in Reactions)
                {
                    if (reaction != null)
                    {
                        var card = DeckController.GetRandomCard();
                        results += card.GetComponent<CardController>().Name + "\n";
                        PlayerController.ReceiveCard(card);
                    }
                }

                Results.text = results;
                Results.gameObject.SetActive(true);

                started = true;
            }
            yield return null;
        }

        yield return null;
    }

    public void React(int index, float time)
    {
        Reactions[index] = time; //TODO check reaction time
    }

    public void CloseChallenge()
    {
        foreach (var unit in ReactionUnits)
            Destroy(unit);

        ReactionUnits = new List<GameObject>();
        Reactions = new float?[reactons];

        Canvas.gameObject.SetActive(false);
    }
}