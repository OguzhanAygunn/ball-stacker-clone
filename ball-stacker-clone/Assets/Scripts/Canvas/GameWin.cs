using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameWin : MonoBehaviour
{
    public static GameWin Instance;
    [SerializeField] Image background;
    [SerializeField] RectTransform OtherObjs;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        OtherObjs.localScale = Vector3.zero;
    }
    public void ActiveOP()
    {
        Color imageColor = background.color;
        imageColor.a = 0.85f;
        background.DOColor(imageColor,0.6f);
        OtherObjs.DOScale(Vector3.one,1.25f).SetEase(Ease.OutElastic);
    }

    public void NextLevel()
    {
        int levelIndex = SceneManager.GetActiveScene().buildIndex;
        levelIndex = (levelIndex + 1 > 4) ? 0 : levelIndex + 1;
        SceneManager.LoadScene(levelIndex);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
