using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonHidden : MonoBehaviour
{

    private Button button;
    [SerializeField] private bool selectOnEnable;


    private void Awake()
    {
        button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        if (selectOnEnable)
        {
            ButtonSelect();
        }
    }

    public void ButtonSelect()
    {
        button.Select();
    }

}
