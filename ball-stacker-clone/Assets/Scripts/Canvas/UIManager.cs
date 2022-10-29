using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    HitEffectController hitEffectController;
    GameOverEffectController gameOverEffectController;
    // Start is called before the first frame update
    void Start()
    {
        hitEffectController = GameObject.FindObjectOfType<HitEffectController>();
        gameOverEffectController = GameObject.FindObjectOfType<GameOverEffectController>();
    }


    public void hitEffectActive(){
        hitEffectController.hitEffectActive();
    }

    public void gameOverEffectActive(){
        gameOverEffectController.effectActive();
    }
}
