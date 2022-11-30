using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RandomImage : MonoBehaviour
{
    [SerializeField] Image _image;
    [SerializeField] Sprite _sprite1;
    [SerializeField] Sprite _sprite2;
    [SerializeField] Sprite _sprite3;

    private void Start()
    {
        RandomSprite();
    }

    void RandomSprite()
    {
        int rnd = UnityEngine.Random.Range(1, 4);
        Debug.Log(rnd);
        switch (rnd)
        {
            case 1:
                _image.sprite = _sprite1;
                break;
            case 2:
                _image.sprite = _sprite2;
                break;
            case 3:
                _image.sprite = _sprite3;
                break;
        }
    }
}
