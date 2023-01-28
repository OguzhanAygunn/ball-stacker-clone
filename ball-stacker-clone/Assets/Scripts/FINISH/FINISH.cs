using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FINISH : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!GameManager.Instance.GameWin && other.gameObject.CompareTag("Collected"))
        {
            GameManager.Instance.GameWin = true;
            ENEMYHANDLER.Instance.AllEnemyDead();
            CameraController.Instance.WinFunc();
            UIManager.Instance.gameWinActive();
        }
    }

}
