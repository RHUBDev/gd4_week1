using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public GameObject ball;
    public TMPro.TMP_Text goaltext;
    private Vector3 startspot = new Vector3(0, 3.69f, 0);
    public Rigidbody2D rig;
    private bool end = false;
    public Miss miss1;
    public Miss miss2;
    public Goal goal;
    private int score = 0;
    public TMPro.TMP_Text scoretext;
    public TMPro.TMP_Text timetext;
    private float timeleft = 60;
    public TMPro.TMP_Text finaltext;
    public GameObject restartButton;
    private bool doneend = false;

    private void Start()
    {
        restartButton.SetActive(false);
        goaltext.text = "";
        finaltext.text = "";
        ball.transform.position = startspot;
        rig.velocity = Vector2.zero;
        rig.angularVelocity = 0;
        end = false;
        goal.end = false;
        miss1.end = false;
        miss2.end = false;
        score = 0;
        timeleft = 60;
        Time.timeScale = 1.0f;
        doneend = false;
    }

    private void Update()
    {
        if (timeleft > 0)
        {
            timeleft -= Time.deltaTime;
            timetext.text = "" + timeleft.ToString("F2");
        }
        else
        {
            if (!doneend)
            {
                doneend = true;
                int record = 0;
                if (PlayerPrefs.HasKey("PachenkoScore"))
                {
                    record = PlayerPrefs.GetInt("PachenkoScore");
                }
                timeleft = 0;
                goaltext.text = "";
                if (score > record)
                {
                    finaltext.text = "New Record!\nYou Scored: " + score + "!\nPrevious Record: " + record;
                    PlayerPrefs.SetInt("PachenkoScore", score);
                }
                else
                {
                    finaltext.text = "You Scored: " + score + "!\nRecord: " + record;
                }
                Time.timeScale = 0.0f;
                restartButton.SetActive(true);
            }
        }
    }

    public void Restart1()
    {
        if (!end)
        {
            end = true;
            StartCoroutine(Restart());
        }
    }

    public IEnumerator Restart()
    {
        yield return new WaitForSeconds(2);
        goaltext.text = "";
        ball.transform.position = startspot;
        rig.velocity = Vector2.zero;
        rig.angularVelocity = 0;
        end = false;
        goal.end = false;
        miss1.end = false;
        miss2.end = false;
    }

    public void Goal()
    {
        score += 1;
        scoretext.text = "Goals: " + score;
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene("Pachinko");
    }
}
