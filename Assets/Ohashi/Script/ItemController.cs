using System.Collections;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField, Tooltip("無敵時間のインターバル")]
    private float _godInterval = 5f;
    [SerializeField, Tooltip("集金率アップのインターバル")]
    private float _itemUpInterval = 5f;
    [SerializeField]
    private GameManager _gameManager;
    [SerializeField]
    private float _money = 10f;

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
            _gameManager.UseMoney(_money);
            StartCoroutine(EventInterval());
            Debug.Log("護衛");
        }
    }

    /// <summary>
    /// お金を使い集金率をアップ
    /// </summary>
    public void OnItemUp()
    {
        if(!_isItemUp && _gameManager.IsGame)
        {
            _gameManager.UseMoney(_money);
            StartCoroutine(EventInterval2());
            //集金率を上げる
            _gameManager.MoneyValueUp(0.2f);
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
