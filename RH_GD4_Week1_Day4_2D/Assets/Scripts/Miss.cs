using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Miss : MonoBehaviour
{
    public TMPro.TMP_Text goaltext;
    public Game game;
    public bool end = false;
    public AudioSource sound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!end)
        {
            end = true;
            if (collision.gameObject.tag == "Ball")
            {
                goaltext.text = "Miss!";
                sound.Play();
                game.Restart1();
            }
        }
    }
}
