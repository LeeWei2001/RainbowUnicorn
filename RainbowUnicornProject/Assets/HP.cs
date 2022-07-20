using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    public const int maxHealth = 100;
    public Text healthvalue;
    public static int currentHealth ;

    //血量條

    public RectTransform HealthBar, Hurt;

    void Start()
    {
        healthvalue.text = currentHealth.ToString();
        currentHealth = PlayerPrefs.GetInt("HP");
    }
    void Update()

    {
        healthvalue.text = currentHealth.ToString();
        currentHealth = PlayerPrefs.GetInt("HP");
        //按下H鈕扣血

        /*if (Input.GetKeyDown(KeyCode.H))

        {

            //接受傷害

            currentHealth = currentHealth - 100;

        }
        if (currentHealth < maxHealth)
        {
            if (Input.GetKeyDown(KeyCode.Q))

            {

                //接受治癒

                currentHealth = currentHealth + 100;

            }
        }*/

        //將綠色血條同步到當前血量長度

        HealthBar.sizeDelta = new Vector2(currentHealth, HealthBar.sizeDelta.y);

        //呈現傷害量

        if (Hurt.sizeDelta.x > HealthBar.sizeDelta.x)

        {

            //讓傷害量(紅色血條)逐漸追上當前血量

            Hurt.sizeDelta += new Vector2(-1, 0) * Time.deltaTime * 100;

        }
        

    }

}
