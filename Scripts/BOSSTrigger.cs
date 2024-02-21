using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSSTrigger : MonoBehaviour
{
    public GameObject backgroundMusic2;
    public GameObject BOSSMusic;
    public GameObject BOSSDecoy;
    public GameObject BOSS;
    public GameObject BOSSHealthBar;
    public GameObject Arena;

    void OnTriggerEnter2D(Collider2D other)
    {
        RubyController player = other.gameObject.GetComponent<RubyController>();

        if (player != null)
        {
            BOSSHealthBar.SetActive(true);
            backgroundMusic2.SetActive(false);
            BOSSMusic.SetActive(true);
            BOSSDecoy.SetActive(false);
            BOSS.SetActive(true);
            Arena.SetActive(true);

            Destroy(gameObject, 1f);
        }
    }
}
