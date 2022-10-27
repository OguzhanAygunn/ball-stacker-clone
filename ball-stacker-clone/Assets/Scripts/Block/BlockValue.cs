using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BlockValue : MonoBehaviour
{
    public enum TypeValue{
        plus,
        multipler,
        division
    }

    [SerializeField] public TypeValue typeValue;

    public int numberValue;

    [SerializeField] TextMeshPro text;
    string _operator;
    private void Start() {
        switch(typeValue){
            case TypeValue.division:
                _operator = "/";
            break;

            case TypeValue.multipler:
                _operator = "x";
            break;

            case TypeValue.plus:
                _operator = "+";
            break;
        }
        text.text = _operator.ToString() + numberValue.ToString();
    }
}
