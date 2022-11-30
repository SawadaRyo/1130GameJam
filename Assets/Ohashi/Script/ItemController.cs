using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class ItemController : MonoBehaviour
{
    [SerializeField, Tooltip("無敵時間のインターバル")]
    float _godInterval = 5f;
    [SerializeField, Tooltip("集金率アップのインターバル")]
    float _itemUpInterval = 5f;
    [SerializeField, Tooltip("GameManagerを格納")]
    GameManager _gameManager;
    [SerializeField, Tooltip("アイテム購入に必要なお金1")]
    float _needMoney1 = 10f;
    [SerializeField, Tooltip("アイテム購入に必要なお金2")]
    float _needMoney2 = 10f;

    public FloatReactiveProperty NeedMoney1 = null;
    public FloatReactiveProperty NeedMoney2 = null;

    bool _isGod = false;
    bool _isItemUp = false;

    public bool IsGod => _isGod;
    private void Start()
    {
        NeedMoney1 = new FloatReactiveProperty(_needMoney1);
        NeedMoney2 = new FloatReactiveProperty(_needMoney2);
    }
    /// <summary>
    /// お金を使い一定時間無敵になる
    /// </summary>
    public void OnGodItem()
    {
        if (!_isGod)
        {
            _gameManager.UseMoney(NeedMoney1.Value);
            StartCoroutine(EventInterval());
            Debug.Log("護衛");
        }
    }

    /// <summary>
    /// お金を使い集金率をアップ
    /// </summary>
    public void OnItemUp()
    {
        if (!_isItemUp && _gameManager.IsGame)
        {
            _gameManager.UseMoney(NeedMoney2.Value);
            StartCoroutine(EventInterval2());
            //集金率を上げる
            _gameManager.MoneyValueUp(0.1f);
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

    private void OnDisable()
    {
        NeedMoney1.Dispose();
        NeedMoney2.Dispose();
    }
}
