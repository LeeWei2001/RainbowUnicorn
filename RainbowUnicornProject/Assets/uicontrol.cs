using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uicontrol: MonoBehaviour
{
    public Text library;
    public static float m_attacklibrary = 0;
    public Text attack;
    public static float m_speciallibrary = 0;
    public Text defense;
    public static float m_defenselibrary = 0;
    

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        attack.text = m_speciallibrary.ToString();
        defense.text = m_defenselibrary.ToString();
        library.text = m_attacklibrary.ToString();
    }
}
