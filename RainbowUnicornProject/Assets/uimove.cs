using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class uimove : MonoBehaviour
{
    //计时
    bool isBack; //是否已经执行过返回
    bool isTime; //是否开始计时
    float time; //长按持续的时间

    //返回退出进度条
    public RectTransform progressUI;
    public Image progressImage;

    private void Start()
    {
        progressUI.gameObject.SetActive(false);
    }

    void Update()
    {
        LongPressTime();
        progressUI.anchoredPosition3D = new Vector3(Input.mousePosition.x - Screen.width / 2, Input.mousePosition.y - Screen.height / 2, 0);
    }

    /// <summary>
    /// 计时（长按0.5s显示进度条UI,再持续1s执行返回方法）
    /// </summary>
    void LongPressTime()
    {
        if (!isTime)
            return;

        time += Time.deltaTime;
        progressImage.fillAmount = (time - 0.5f) / 1f; //长按0.5s之后，进度条才开始走

        if (time > 1.5f) //长按1.5s后执行返回方法，并重置
        {
            BackUp();

            progressUI.gameObject.SetActive(false);
            isBack = true;
            isTime = false;
        }
        else if (time > 0.5f) //长按0.5s之后，显示返回UI
        {
            progressUI.gameObject.SetActive(true);
        }
    }

    #region 长按
    private void OnMouseDrag()
    {
        Debug.Log("进入");
        if (isBack)
            return;

        isTime = true;

        //UI跟随鼠标移动
        progressUI.anchoredPosition3D = Input.mousePosition;
    }
    private void OnMouseUp()
    {
        progressUI.gameObject.SetActive(false);
        isTime = false;
        time = 0f;
        isBack = false;
    }
    #endregion

    /// <summary>
    /// 返回
    /// </summary>
    void BackUp()
    {
        Debug.Log("返回");
        //Application.Quit();
    }
}
