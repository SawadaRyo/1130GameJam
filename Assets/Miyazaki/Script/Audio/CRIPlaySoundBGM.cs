using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
public class CRIPlaySoundBGM : MonoBehaviour
{
    [SerializeField,Tooltip("Ä¶‚·‚éƒiƒ“ƒo[‚ğ“ü‚ê‚é")] int _playNum;
    private void Start()
    {
        CRIAudioManager.instance.CRIPlayBGM(_playNum);
    }
}
