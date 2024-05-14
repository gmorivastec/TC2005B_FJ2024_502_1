using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

public class GUIManager : MonoBehaviour
{

    [SerializeField]
    private TMP_Text _texto;

    public static GUIManager Instance { 
        get;
        private set;    
    }

    void Awake() 
    {
        if(Instance == null) 
            Instance = this;
        else 
            Destroy(gameObject);

        Assert.IsNotNull(_texto, "TEXTO NO PUEDE SER NULO EN GUIMANAGER");
    }

    public void SetText(string text)
    {
        _texto.text = text;
    }
}
