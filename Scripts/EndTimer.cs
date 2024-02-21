using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTimer : MonoBehaviour
{
    public float timer;
    public GameObject Boss3;

    public GameObject Tilemap3;
    public GameObject TreeForeground1;
    public GameObject TreeForeground2;
    public GameObject TreeForeground3;
    public GameObject TreeForeground4;
    public GameObject TreeForeground5;
    public GameObject TreeForeground6;
    public GameObject EndTrigger;

    public GameObject End2Trigger;
    public GameObject MusicStopTrigger;

    // Start is called before the first frame update
    void Start()
    {
        timer = 60f;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > -20f)
        {
            BOSS3 boss3 = Boss3.GetComponent<BOSS3>();
            if (boss3.broken == false)
            {
                timer -= Time.deltaTime;
                if (timer < 0f)
                {
                    TreeForeground1.SetActive(false);
                    TreeForeground2.SetActive(false);
                    TreeForeground3.SetActive(false);
                    TreeForeground4.SetActive(true);
                    TreeForeground5.SetActive(true);
                    TreeForeground6.SetActive(true);
                    EndTrigger.SetActive(false);

                    Tilemap3.SetActive(true);
                    MusicStopTrigger.SetActive(true);
                    End2Trigger.SetActive(true);
                }
            }
        }
    }
}
