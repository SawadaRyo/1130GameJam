using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
public class CRIPlaySoundBGM : MonoBehaviour
{
    [SerializeField,Tooltip("�Đ�����i���o�[������")] int _playNum;
    private void Start()
    {
        CRIAudioManager.instance.CRIPlayBGM(_playNum);
    }
}
