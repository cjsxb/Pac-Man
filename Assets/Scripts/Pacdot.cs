using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pacdot : MonoBehaviour
{
    public static int pacdotsCollected;

    public Text text;

    // Check if collided
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.name == "pacman")
        {
            if (pacdotsCollected == 329)
            {
                Time.timeScale = 0;
                Debug.Log("330 Reached!");
                text.text = "You Win!";
                Destroy(gameObject);
            }
            else
            {
                pacdotsCollected = pacdotsCollected + 1;
                Debug.Log(pacdotsCollected);
                Destroy(gameObject);
            }
        }
    }
}