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
            //fadeout���I�������Ă΂��
            .OnComplete(() => SceneManager.LoadScene(sceneName));
    }
    /// <summary>
    /// �t�F�[�h�C��
    /// </summary>
    public void FadeIn()
    {
        GameObject panel = GameObject.Find("InPanel");
        //�p�l������������t�F�[�h�C������
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