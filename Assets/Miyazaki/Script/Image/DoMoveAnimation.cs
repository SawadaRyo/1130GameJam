using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using DG.Tweening;
public class DoMoveAnimation : MonoBehaviour
{
    private void Start()
    {
        transform.DOLocalMove(new Vector3(10f, 0, 0), 1f)
    .SetLoops(-1, LoopType.Yoyo);
    }
}
