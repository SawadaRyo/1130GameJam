using System.Collections;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField, Tooltip("無敵時間のインターバル")]
    private float _godInterval = 5f;
    [SerializeField, Tooltip("集金率アップのインターバル")]
    private float _itemUpInterval = 5f;

    private bool _isGod = false;
    private bool _isItemUp = false;

    public bool IsGod => _isGod;
    /// <summary>
    /// お金を使い一定時間無敵になる
    /// </summary>
    public void OnGodItem()
    {
        if(!_isGod)
        {
            StartCoroutine(EventInterval());
            Debug.Log("護衛");
            //お金を減らす
        }
    }

    /// <summary>
    /// お金を使い集金率をアップ
    /// </summary>
    public void OnItemUp()
    {
        if(!_isItemUp)
        {
            StartCoroutine(EventInterval2());
            //集金率を上げる
            //お金を減らす
            Debug.Log("集金率アップ");
        }
    }

    /// <summary>
    /// イベントのインターバル
    /// </summary>
    private IEnumerator EventInterval()
    {

        _isGod = true;
        yield return new WaitForSeconds(_godInterval);
        _isGod = false;
    }

    /// <summary>
    /// イベントのインターバル
    /// </summary>
    private IEnumerator EventInterval2()
    {
        _isItemUp = true;
        yield return new WaitForSeconds(_itemUpInterval);
        _isItemUp = false;
    }
}
