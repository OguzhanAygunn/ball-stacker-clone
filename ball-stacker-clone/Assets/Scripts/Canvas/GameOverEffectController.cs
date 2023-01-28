using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameOverEffectController : MonoBehaviour
{
    Image image;
    void Start()
    {
        image = transform.GetChild(0).gameObject.GetComponent<Image>();
    }

    public void effectActive(){
        image.DOColor(Color.black,1f).SetDelay(1f).OnComplete( () => {
            StopAllCoroutines();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        });
    }
}
