using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameExit : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(ButtonExit);

    }
    public void ButtonExit()
    {
        Debug.Log("EXIT");
        Application.Quit();
    }
}
