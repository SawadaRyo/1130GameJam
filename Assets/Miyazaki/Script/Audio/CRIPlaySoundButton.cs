using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CRIPlaySoundButton : MonoBehaviour
{
    [SerializeField, Tooltip("�Đ�����i���o�[������")] int _playName;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(ClickPlay);

    }
    void ClickPlay()
    {
        CRIAudioManager.instance.CRIPlaySE(_playName);
    }
}
