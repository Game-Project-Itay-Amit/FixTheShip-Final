using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject winPanel;
    public GameObject lostPanel;
    public GameObject loadingPanel;
    public float TimeSet;
    public int Min;
    public int addZero;
    public Text txtTimer;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        txtTimer.text = "" + Min + ":00";
    }

    // Update is called once per frame
    void Update()
    {
        if(Min <= 0 && TimeSet <= 0)
        {
            txtTimer.text = Min + ":" + 00;

            SetLostPanel();
        }
        else
        {
            if(TimeSet > 0)
            {
                TimeSet -= Time.fixedDeltaTime;
            }
            else
            {
                Min -= 1;
                TimeSet = 60f;
            }
            txtTimer.text = Min + ":" +TimeSet;
        }
    }
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
       GameObject SDAS = GameObject.Find("GameManager");
    }
    public void SetLostPanel()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        lostPanel.SetActive(true);
    }
    public void SetWinPanel()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        winPanel.SetActive(true);
    }

    public void SetNextLevel()
    {
        Time.timeScale = 0;
        // Cursor.lockState = CursorLockMode.None;
        // Cursor.visible = true;
        loadingPanel.SetActive(true);
        SceneManager.LoadScene("SampleScene");
    }

}
