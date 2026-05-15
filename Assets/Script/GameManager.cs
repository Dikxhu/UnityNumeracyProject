using UnityEngine;
using TMPro;
using StarterAssets;

public class GameManager : MonoBehaviour
{
    [Header("START UI")]
    public GameObject startText;

    // PLAYER
    public ThirdPersonController playerController;

    [Header("NUMERACY UI")]
    public GameObject questionText;

    public GameObject option1;
    public GameObject option2;
    public GameObject option3;

    public TextMeshProUGUI resultText;

    [Header("LITERACY UI")]
    public GameObject wordPuzzleText;

    public TextMeshProUGUI answerText;

    // LETTER BUTTON GROUP
    public GameObject letterButtons;

    public GameObject submitButton;

    public TextMeshProUGUI endText;

    [Header("APPLE SYSTEM")]
    public int applesCollected = 0;
    public int totalApples = 4;

    private bool gameStarted = false;

    private string currentWord = "";

    void Start()
    {
        // STOP PLAYER AT START
        playerController.enabled = false;

        // HIDE NUMERACY UI
        questionText.SetActive(false);

        option1.SetActive(false);
        option2.SetActive(false);
        option3.SetActive(false);

        resultText.gameObject.SetActive(false);

        // HIDE LITERACY UI
        wordPuzzleText.SetActive(false);

        answerText.gameObject.SetActive(false);

        // HIDE LETTER BUTTONS
        letterButtons.SetActive(false);

        submitButton.SetActive(false);

        // HIDE END TEXT
        endText.gameObject.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // START GAME
        if (!gameStarted && Input.GetKeyDown(KeyCode.E))
        {
            gameStarted = true;

            // ENABLE PLAYER MOVEMENT
            playerController.enabled = true;

            startText.SetActive(false);

            resultText.gameObject.SetActive(true);

            resultText.text = "Collect 4 Apples";

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        // REMOVE LETTER
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            RemoveLetter();
        }
    }

    // APPLE COLLECTION
    public void CollectApple()
    {
        if (!gameStarted)
            return;

        applesCollected++;

        resultText.text =
            "Apples Collected: " + applesCollected;

        // SHOW QUESTION
        if (applesCollected >= totalApples)
        {
            resultText.text =
                "Choose The Correct Answer";

            questionText.SetActive(true);

            option1.SetActive(true);
            option2.SetActive(true);
            option3.SetActive(true);
        }
    }

    // WRONG ANSWER
    public void WrongAnswer()
    {
        resultText.text = "Wrong!";
        resultText.color = Color.red;
    }

    // CORRECT ANSWER
    public void CorrectAnswer()
    {
        resultText.text = "Correct!";
        resultText.color = Color.green;

        questionText.SetActive(false);

        option1.SetActive(false);
        option2.SetActive(false);
        option3.SetActive(false);

        Invoke("StartLiteracyGame", 2f);
    }

    // START WORD GAME
    void StartLiteracyGame()
    {
        resultText.gameObject.SetActive(false);

        wordPuzzleText.SetActive(true);

        answerText.gameObject.SetActive(true);

        // SHOW LETTER BUTTONS
        letterButtons.SetActive(true);

        submitButton.SetActive(true);

        endText.gameObject.SetActive(false);

        ClearAnswer();
    }

    // ADD LETTER
    public void AddLetter(string letter)
    {
        if (currentWord.Length >= 5)
            return;

        currentWord += letter;

        UpdateAnswerText();
    }

    // REMOVE LETTER
    void RemoveLetter()
    {
        if (currentWord.Length <= 0)
            return;

        currentWord =
            currentWord.Substring(0, currentWord.Length - 1);

        UpdateAnswerText();
    }

    // UPDATE ANSWER DISPLAY
    void UpdateAnswerText()
    {
        string display = "";

        for (int i = 0; i < 5; i++)
        {
            if (i < currentWord.Length)
            {
                display += currentWord[i] + " ";
            }
            else
            {
                display += "_ ";
            }
        }

        answerText.text = display;
    }

    // CLEAR ANSWER
    void ClearAnswer()
    {
        currentWord = "";

        answerText.text = "_ _ _ _ _";
    }

    // SUBMIT WORD
    public void SubmitWord()
    {
        endText.gameObject.SetActive(true);

        // CORRECT WORD
        if (currentWord == "APPLE")
        {
            // HIDE ALL WORD UI
            wordPuzzleText.SetActive(false);

            answerText.gameObject.SetActive(false);

            letterButtons.SetActive(false);

            submitButton.SetActive(false);

            // STOP PLAYER
            playerController.enabled = false;

            // FINAL MESSAGE
            endText.text =
                "BRAVO! YOU COMPLETED THE GAME";

            endText.color = Color.green;

            // FREEZE GAME
            Time.timeScale = 0f;
        }
        else
        {
            // SHOW WRONG MESSAGE
            endText.text =
                "WRONG WORD! TRY AGAIN";

            endText.color = Color.red;

            // CLEAR WORD
            ClearAnswer();

            // HIDE MESSAGE AFTER 3 SECONDS
            Invoke("HideWrongMessage", 3f);
        }
    }

    // HIDE WRONG MESSAGE
    void HideWrongMessage()
    {
        endText.gameObject.SetActive(false);
    }
}