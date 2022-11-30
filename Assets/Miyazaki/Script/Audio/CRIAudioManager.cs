using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CriWare;
using System;
using UniRx;
public class CRIAudioManager : MonoBehaviour
{
    //�V���O���g��
    public static CRIAudioManager instance;
    //�p�X�̎w��
    [SerializeField] string _streamingAssetsPathACF;
    [SerializeField] string _cueSheetBGM;
    [SerializeField] string _cueSheetSE;
    //�{�����[��
    [SerializeField, Range(0f, 1f)] float _volumeBGM;
    [SerializeField, Range(0f, 1f)] float _volumeSE;

    CriAtomExPlayback _criAtomExPlayback;
    CriAtomEx.CueInfo _cueInfo;

    CriAtomSource _criAtomSourceBGM;
    CriAtomSource _criAtomSourceSE;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);

            //acf�̃p�X�w��
            string path = Common.streamingAssetsPath + $"/{_streamingAssetsPathACF}.acf";
            CriAtomEx.RegisterAcf(null,path);

            //CriAtom�ǉ�
            new GameObject().AddComponent<CriAtom>();

            //BGM.acb��CueSheet��ǉ�
            CriAtom.AddCueSheet(_cueSheetBGM, $"{_cueSheetBGM}.acb", null, null);
            //SE.acb��CueSheet��ǉ�
            CriAtom.AddCueSheet(_cueSheetSE, $"{_cueSheetSE}.acb", null, null);

            //CriAtomSourceBGM��CriAtomSourceBGM�̒ǉ�
            _criAtomSourceBGM = gameObject.AddComponent<CriAtomSource>();
            _criAtomSourceBGM.cueSheet = _cueSheetBGM;
            //CriAtomSourceSE��CriAtomSourceBGM�̒ǉ�
            _criAtomSourceSE = gameObject.AddComponent<CriAtomSource>();
            _criAtomSourceSE.cueSheet = _cueSheetSE;


        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        //�Q�[�����v���r���[�p�̃��x�����j�^�[�@�\��ǉ�
        CriAtom.SetBusAnalyzer(true);

        _criAtomSourceBGM.loop = true;
        _criAtomSourceSE.loop = false;
        _criAtomSourceBGM.volume = _volumeBGM;
        _criAtomSourceSE.volume = _volumeSE;
    }
    private void Update()
    {
        _criAtomSourceBGM.volume = _volumeBGM;
        _criAtomSourceSE.volume = _volumeSE;
    }
    /// <summary>
    /// BGM�̍Đ�
    /// </summary>
    /// <param name="index">�Đ��i���o�[</param>
    public void CRIPlayBGM(int index)
    {
        CriAtomSource.Status status = _criAtomSourceBGM.status;
        if ((status == CriAtomSource.Status.Stop) || (status == CriAtomSource.Status.PlayEnd))
        {
            _criAtomExPlayback = _criAtomSourceBGM.Play(index);
            Debug.Log("neko");
        }
        else
        {
            _criAtomSourceBGM.Stop();
            _criAtomExPlayback = _criAtomSourceBGM.Play(index);
        }
    }
    /// <summary>
    /// BGM�̍Đ�
    /// </summary>
    /// <param name="index">�Đ��i���o�[</param>
    /// <param name="delayTime">�҂�����</param>
    public void CRIPlayBGM(int index,float delayTime)
    {
        StartCoroutine(CRIDelayPlaySound(index, delayTime));
    }
    private IEnumerator CRIDelayPlaySound(int index, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        CRIPlayBGM(index);
    }
    /// <summary>
    /// BGM�̈ꎞ��~
    /// isTrue��true���ƈꎞ��~
    /// </summary>
    /// <param name="isTrue"></param>
    public void CRIPauseBGM(bool isTrue)
    {
        _criAtomSourceBGM.Pause(isTrue);
    }
    /// <summary>
    /// BGM�����S�Ɏ~�߂܂�
    /// </summary>
    public void CRIStopBGM()
    {
        _criAtomSourceBGM.Stop();
    }
    /// <summary>
    /// SE�̍Đ�
    /// </summary>
    /// <param name="index"></param>
    public void CRIPlaySE(int index)
    {
        _criAtomExPlayback = _criAtomSourceSE.Play(index);
    }
    public void CRIRandomBGM()
    {
        int rnd = UnityEngine.Random.Range(0, 8);
        Debug.Log(rnd);
        CRIPlayBGM(rnd);
    }
}
