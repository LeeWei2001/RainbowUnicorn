using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selcount : MonoBehaviour
{
    //public GameObject muteButton;
    //public GameObject selButton;
    private AudioSource audioSource;
    private bool muteState;
    private float preVolume;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();//audioSource抓volume(音量)的數值
        audioSource.volume = 0.3f;//初始音量
        muteState = false;//muteState判斷目前靜音的狀態
        preVolume = audioSource.volume;//preVolume紀錄靜音前的音量
    }
    public void VolumeChanged(float newVolume)
    {
        audioSource.volume = newVolume;//當被呼叫時把newVolume帶入audioSource.volume改變音量
        muteState = false;//以及將靜音狀態設為false
    }
    //public void MuteClick()
    //{
    //    muteState = !muteState;//先做muteState != muteState 的true false的切換
    //    if (muteState)//muteState為true，也就是靜音時，將目前的音量存在preVolume變數中，再將音量audioSource.volume設為0
    //    {
    //        selButton.SetActive(false);//把原本音量鍵的圖案消失
    //        muteButton.SetActive(true);//換成靜音的圖
    //        preVolume = audioSource.volume;
    //        audioSource.volume = 0;
            
    //    }
    //    else
    //        audioSource.volume = preVolume;
    //    selButton.SetActive(true);//換成音量的圖
    //    muteButton.SetActive(false);//把原本靜音鍵的圖案消失
    //}

    // Update is called once per frame
    void Update()
    {
        
    }
}
