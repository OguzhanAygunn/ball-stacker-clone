using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TapToStart : MonoBehaviour
{
    public Image background;
    public Text text;
    bool disable,touchAble;

    private void Awake()
    {
        Invoke("TouchableActive",0.1f);
    }
    public void disableOP()
    {
        if (touchAble)
        {
            GameManager.Instance.GameStart = true;
            Color color = background.color;
            color.a = 0;
            background.DOColor(color, 0.6f).OnComplete(() => {
                Destroy(this.gameObject);
            });
            text.GetComponent<RectTransform>().DOScale(Vector3.zero, 0.55f);
        }
    }

    void TouchableActive()
    {
        touchAble = true;
    }
}
