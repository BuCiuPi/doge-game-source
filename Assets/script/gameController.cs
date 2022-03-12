using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameController : MonoBehaviour
{
    public GameObject m_sheep;
    public GameObject m_tutorial;
    public GameObject m_scoreUI;
    public GameObject m_panelEndGame;
    public GameObject[] m_wolfs;

    private TextMeshProUGUI m_scoreUI_TMP;
    public TextMeshProUGUI m_finalScoreUI_TMP;

    private int m_score;

    private bool m_isStarted;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;

        // construct value
        m_isStarted = false;
        m_score = 0;
        m_scoreUI_TMP = m_scoreUI.GetComponent<TextMeshProUGUI>();
        m_wolfs = GameObject.FindGameObjectsWithTag("enemy");
    }

    // Update is called once per frame
    void Update()
    {
        // Start game when click on screen
        if (!m_isStarted && Input.GetMouseButtonDown(0))
        {
            // avtive & deactive UI
            m_scoreUI.SetActive(true);
            m_tutorial.SetActive(false);

            // play enemy
            foreach (GameObject wolf in m_wolfs)
            {
                wolf.GetComponent<wolfController>().StartThrowingBoom();
            }
            m_sheep.GetComponent<PlayerController>().StartPlayer();

            Time.timeScale = 1;

            //set value
            m_isStarted = true;
        }
    }

    public void GOTOMousePos(GameObject i_obj, float i_moveSpeed, float i_z)
    {
        Vector3 mousePOS;
        // get mouse position on world
        mousePOS = Camera.main.ScreenToWorldPoint(Input.mousePosition);

/*        mousePOS = new Vector3(Mathf.Clamp(mousePOS.x, -5, 5), Mathf.Clamp(mousePOS.y, -3, 3), i_z);*/

        // set i_obj to mouse position
        i_obj.transform.position = Vector3.Lerp(i_obj.transform.position, mousePOS, i_moveSpeed * 0.1f);
    }

    public void endGame()
    {
        // stop Time Scale
        Time.timeScale = 0;

        // set enemy
        foreach (GameObject wolf in m_wolfs)
        {
            wolf.GetComponent<wolfController>().StopThrowingBoom();
        }
        m_sheep.GetComponent<PlayerController>().StopPlayer();

        // set total score
        m_finalScoreUI_TMP.SetText("Final Score: " + m_score);

        // active & deactive UI
        m_panelEndGame.SetActive(true);
        m_scoreUI.SetActive(false);

        //debug
        Debug.Log("end Game");
    }

    public void AddScore()
    {
        // plus score & refresh score UI
        m_score++;
        m_scoreUI_TMP.SetText("Score: " + m_score);
    }

    public void Restart()
    {
        // reload screen
        SceneManager.LoadScene(0);
        Debug.Log("load Scene");
    }
}
