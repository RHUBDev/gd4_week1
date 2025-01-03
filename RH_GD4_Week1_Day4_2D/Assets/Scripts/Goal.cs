using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    public TMPro.TMP_Text goaltext;
    public Game game;
    public bool end = false;
    public AudioSource sound;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            if (!end)
            {
                end = true;
                goaltext.text = "Goal!";
                sound.Play();
                game.Goal();
                game.Restart1();
            }
        }
    }
}
