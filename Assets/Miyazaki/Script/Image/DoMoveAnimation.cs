using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using DG.Tweening;
public class DoMoveAnimation : MonoBehaviour
{
    [SerializeField] Transform _parentTransform;
    private void Awake()
    {

        foreach (Transform childTransfom in _parentTransform)
        {

            childTransfom.transform.DOLocalMoveX(0.2f, 6f)
                .SetLoops(-1, LoopType.Yoyo);
        }
    }
}
