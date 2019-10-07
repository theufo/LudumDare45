using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChallengeController : MonoBehaviour
{
    private float prepareTime = 2f;
    private float challengeTime = 10f;
    private float startTime;
    private float currentTime;
    private bool started;
    private ChallengeState ChallengeState;
    private int reactonCount = 3;

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
        Initialize("Pro tour tournament");
        StartCoroutine(Challenge());
    }

    public void Initialize(string name)
    {
        var multiplier = (PlayerController.PlayerLevel / 10) > 1 ? (PlayerController.PlayerLevel / 10) : 1;
        reactonCount = (int)(reactonCount + multiplier);
        Reactions = new float?[reactonCount];

        ChallengeName.text = name;
        for(int i = 0; i < reactonCount; i++)
        {
            var xAxis = Random.Range(-620, 620) / 100;
            var yAxis = Random.Range(-460, 460) / 100;

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
                var prizeCards = new List<GameObject>();

                foreach (var reaction in Reactions)
                {
                    if (reaction != null)
                    {
                        var card = DeckController.GetRandomCard();
                        prizeCards.Add(card);
                        PlayerController.ReceiveCard(card);
                    }
                }

                if (prizeCards.Count > 0)
                {
                    GameController.OpenBoosterController.Initialize(prizeCards);
                    GameController.OpenBoosterController.InnerGameObject.SetActive(true);
                    CloseChallenge();
                }
                else
                {
                    GameController.StoryController.SetStoryText("Bad luck this time. Maybe, you will win in the next challenge!");
                    CloseChallenge();
                }

                started = true;
            }
            yield return new WaitForSeconds(2);
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
        Reactions = new float?[reactonCount];

        Canvas.gameObject.SetActive(false);
    }
}