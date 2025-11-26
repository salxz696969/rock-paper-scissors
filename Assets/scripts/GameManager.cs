using UnityEngine;   // base stuff
using UnityEngine.UI;
using TMPro;

public class RPSGameManager : MonoBehaviour
{
    public Button rockButton;   // btn for rock
    public Button paperButton;  // btn for paper
    public Button scissorsButton; // btn for scissors, kinda obvious

    public RawImage userChoiceImage;      // show what user picked
    public RawImage computerChoiceImage;  // show what pc picked

    public Texture rockTexture;      // rock pic
    public Texture paperTexture;     // paper pic
    public Texture scissorsTexture;  // scissors pic

    public Button userScoreButton;        // score ui user
    public Button computerScoreButton;    // score ui pc

    private TMP_Text userScoreButtonText;     // text ref user
    private TMP_Text computerScoreButtonText; // text ref comp

    private int userScore = 0;         // user points
    private int computerScore = 0;       // computer points, no spaces here on purpose
    private bool gameOver = false;     // stop when done

    public GameSceneManager sceneManager;

    enum Choice { Rock, Paper, Scissors }

    void Start()
    {
        // hook up buttons here
        rockButton.onClick.AddListener(() => OnUserChoose(Choice.Rock));
        paperButton.onClick.AddListener(() => OnUserChoose(Choice.Paper));
        scissorsButton.onClick.AddListener(() => OnUserChoose(Choice.Scissors));

        // cache text once, no need every frame
        userScoreButtonText = userScoreButton.GetComponentInChildren<TMP_Text>();
        computerScoreButtonText = computerScoreButton.GetComponentInChildren<TMP_Text>();

        userScoreButton.interactable = false;
        computerScoreButton.interactable = false;

        UpdateScoreUI();
    }

    int GetRoundResult(Choice user, Choice computer)
    {
        // 0 = draw, 1 = user win, -1 = user lose
        if (user == computer) return 0;

        if ((user == Choice.Rock && computer == Choice.Scissors) ||
            (user == Choice.Scissors && computer == Choice.Paper) ||
            (user == Choice.Paper && computer == Choice.Rock))
        {
            return 1;
        }
        else
        {
            return -1;
        }
    }

    Texture GetTexture(Choice choice)
    {
        // lil map from choice to tex
        switch (choice)
        {
            case Choice.Rock: return rockTexture;
            case Choice.Paper: return paperTexture;
            case Choice.Scissors: return scissorsTexture;
            default: return null; // should not really hit
        }
    }

    void OnUserChoose(Choice userChoice)
    {
        // game already done, no more input
        if (gameOver) return;

        Choice computerChoice = (Choice)Random.Range(0, 3);

        userChoiceImage.texture = GetTexture(userChoice);
        computerChoiceImage.texture = GetTexture(computerChoice);

        int roundResult = GetRoundResult(userChoice, computerChoice);

        if (roundResult == 1) userScore++;
        else if (roundResult == -1) computerScore++;

        UpdateScoreUI();   // push scores to ui

        CheckGameOver();   // see if we finish here
    }

    void UpdateScoreUI()
    {
        // just simple text, single space for quick padding
        userScoreButtonText.text = " " + userScore;
        computerScoreButtonText.text = " " + computerScore;
    }

    void CheckGameOver()
    {
        // 3 is target score here
        if (userScore >= 3)
        {
            gameOver = true;
            Invoke(nameof(LoadGameWinScene), 1f);
        }
        else if (computerScore >= 3)
        {
            gameOver = true;
            Invoke(nameof(LoadGameOverScene), 1f);
        }
    }

    void LoadGameOverScene()
    {
        // go to lose scene
        sceneManager.LoadGameOverScene();
    }

    void LoadGameWinScene()
    {
        // go to win scene
        sceneManager.LoadGameWinScene();
    }
}
