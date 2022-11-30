using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
public class CRIPlaySoundBGM : MonoBehaviour
{
    [SerializeField,Tooltip("再生するナンバーを入れる")] int _playNum;
    private void Start()
    {
        CRIAudioManager.instance.CRIPlayBGM(_playNum);
        Debug.Log("CRIPlayBGM");
    }
}
