using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gamemanager;

    bool gamePaused = false;
    bool endGame = false;
    bool win = false;
    

    [SerializeField] int timeToEnd;
    void Start()
    {
        if (gamemanager == null)
        {
            gamemanager = this;
        }

        InvokeRepeating("Stopper", 2, 1);

        if (timeToEnd <= 0)
        {
            timeToEnd = 100;
        } 
       
    }

    void Stopper()
    {
        timeToEnd--;
        Debug.Log("TIME: " + timeToEnd + " sec");

        if(timeToEnd <= 0 )
        {
            timeToEnd = 0;
            endGame = true;
        }
        if(endGame)
        {
            EndGame();
        }
    }

    // Update is called once per frame
    void Update()
    {
        PauseCheck();
    }

    void PauseCheck()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {
            if(gamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        Debug.Log("Pause Game");
        Time.timeScale = 0f;
        gamePaused = true;
    }

    public void ResumeGame()
    {
        Debug.Log("Resume Game");
        Time.timeScale = 1f;
        gamePaused = false;
    }

    public void EndGame()
    {
        CancelInvoke("Stopper");
        if(win)
        {
            Debug.Log("You won");
        }
        else
        {
            Debug.Log("You lost");
        }
    }
}
