using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CriWare;
using System;
using UniRx;
public class CRIAudioManager : MonoBehaviour
{
    //シングルトン
    public static CRIAudioManager instance;
    //パスの指定
    [SerializeField] string _streamingAssetsPathACF;
    [SerializeField] string _cueSheetBGM;
    [SerializeField] string _cueSheetSE;
    //ボリューム
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

            //acfのパス指定
            string path = Common.streamingAssetsPath + $"/{_streamingAssetsPathACF}.acf";
            CriAtomEx.RegisterAcf(null,path);

            //CriAtom追加
            new GameObject().AddComponent<CriAtom>();

            //BGM.acbのCueSheetを追加
            CriAtom.AddCueSheet(_cueSheetBGM, $"{_cueSheetBGM}.acb", null, null);
            //SE.acbのCueSheetを追加
            CriAtom.AddCueSheet(_cueSheetSE, $"{_cueSheetSE}.acb", null, null);

            //CriAtomSourceBGMにCriAtomSourceBGMの追加
            _criAtomSourceBGM = gameObject.AddComponent<CriAtomSource>();
            _criAtomSourceBGM.cueSheet = _cueSheetBGM;
            //CriAtomSourceSEにCriAtomSourceBGMの追加
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
        //ゲーム内プレビュー用のレベルモニター機能を追加
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
    /// BGMの再生
    /// </summary>
    /// <param name="index">再生ナンバー</param>
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
    /// BGMの再生
    /// </summary>
    /// <param name="index">再生ナンバー</param>
    /// <param name="delayTime">待ち時間</param>
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
    /// BGMの一時停止
    /// isTrueがtrueだと一時停止
    /// </summary>
    /// <param name="isTrue"></param>
    public void CRIPauseBGM(bool isTrue)
    {
        _criAtomSourceBGM.Pause(isTrue);
    }
    /// <summary>
    /// BGMを完全に止めます
    /// </summary>
    public void CRIStopBGM()
    {
        _criAtomSourceBGM.Stop();
    }
    /// <summary>
    /// SEの再生
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
