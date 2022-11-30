using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeSystem : MonoBehaviour
{
    void Start()
    {
        FadeIn();
    }
    public void FadeOut(string sceneName)
    {
        GameObject panel = GameObject.Find("Panel");
        panel.GetComponent<Image>().enabled = true;
        panel.GetComponent<Image>().DOFade(1, 1.5f)
            .SetDelay(0.5f)
            //fadeoutが終わったら呼ばれる
            .OnComplete(() => SceneManager.LoadScene(sceneName));
    }
    /// <summary>
    /// フェードイン
    /// </summary>
    public void FadeIn()
    {
        GameObject panel = GameObject.Find("InPanel");
        //パネルがあったらフェードインする
        if (panel == null)
        {
            return;
        }
        else
        {
            panel.GetComponent<Image>().enabled = true;
            panel.GetComponent<Image>().DOFade(0, 1.5f)
            .SetDelay(0.5f)
            .OnComplete(() => FadeInLast());
        }
    }
    void FadeInLast()
    {
        GameObject panel = GameObject.Find("InPanel");
        panel.GetComponent<Image>().enabled = false;
    }
}