using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private Transform[] movTraps;
    [SerializeField] private Transform players;
    [SerializeField] private GameObject[] TrapTriggers;

    [Header("Panels")]
    public GameObject PausePanel;
    public GameObject GameOverPanel;
    public GameObject HtpPanel;

    [Header("Game Over UI")]
    public GameObject YouWinUI;
    public GameObject YouLoseUI;
    public GameObject nextLevel;

    public bool isDie;
    public bool isWin;

    Scene scene;

    //private Vector3[] trapOriginalPos;
    //private Vector3 playerOriginalPos;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        scene = SceneManager.GetActiveScene();
       

        if (HtpPanel.activeInHierarchy)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }


        //trapOriginalPos = new Vector3[movTraps.Length];
       
        
        for (int i = 0; i < movTraps.Length; i++)
        {
            //trapOriginalPos[i] = movTraps[i].position;
            movTraps[i].gameObject.SetActive(false);  
        }
        PausePanel.SetActive(false);
        GameOverPanel.SetActive(false);
        YouWinUI.SetActive(false);
        YouLoseUI.SetActive(false);
        nextLevel.SetActive(false);
        isDie = false;
        isWin = false;

        //playerOriginalPos = players.position;
        
    }
    

    // Update is called once per frame
    void Update()
    {
        if (isDie || isWin) 
        {
            gameOver();
        }

        if(Input.GetKeyDown(KeyCode.H))
        {
            HtpPanelActive();
        }
       
    }

    public void pauseButton()
    {
        Time.timeScale = 0;
        PausePanel.SetActive(true);
    }

    public void resumeButton()
    {
        Time.timeScale = 1;
        PausePanel.SetActive(false);
    }

    public void restartButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(scene.name);
    }

    public void quitButton()
    {
        Application.Quit();
    }

    private void gameOver()
    {
        Time.timeScale = 0;
        GameOverPanel.SetActive(true);
        if (isDie)
        {
            YouLoseUI.SetActive(true);
        }
        else if (isWin) 
        {
            YouWinUI.SetActive(true);
            nextLevel.SetActive(true);
        }
    }

    public void NextLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Level1")
        {
            SceneManager.LoadScene("Level2");
        }

        if (scene.name == "Level2")
        {
            SceneManager.LoadScene("Level1");
        
        }
    }

    public void closeButton()
    {
        Time.timeScale = 1;
        HtpPanel.SetActive(false);
    }

    public void HtpPanelActive()
    {
        Time.timeScale = 0;
        HtpPanel.SetActive(true);
    }

}
