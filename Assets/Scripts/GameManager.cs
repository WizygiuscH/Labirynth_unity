using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gamemanager;

    bool gamePaused = false;
    bool endGame = false;
    bool win = false;

    public int points = 0;

    public int redKey = 0;
    public int greenKey = 0;
    public int goldKey = 0;

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

    public void AddPoints(int point)
    {
        points += point;
    }

    public void AddTime(int time)
    {
        timeToEnd += time;
    }

    public void FreezeTime(int freeze)
    {
        CancelInvoke("Stopper");
        InvokeRepeating("Stopper", freeze, 1);
    }

    public void AddKey(KeyColor color)
    {
        if (color == KeyColor.Green)
        {
            greenKey++;
        }
        else if (color == KeyColor.Gold)
        {
            goldKey++;
        }
        else if (color == KeyColor.Red)
        {
            redKey++;
        }
    }

        void Stopper()
        {
            timeToEnd--;
            Debug.Log("TIME: " + timeToEnd + " sec");

            if (timeToEnd <= 0)
            {
                timeToEnd = 0;
                endGame = true;
            }
            if (endGame)
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
                if (gamePaused)
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



    void PickUpCheck()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("Actual Time: " + timeToEnd);
            Debug.Log("Key red: " + redKey + " green: " + greenKey + " gold: " + goldKey);
            Debug.Log("Points: " + points);
        }
    }
}
