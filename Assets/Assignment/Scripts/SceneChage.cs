using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChage : MonoBehaviour
{
   public void startButton()
    {
        SceneManager.LoadScene(1);
    }

    public void restartButton()
    {
        SceneManager.LoadScene(0);
    }
}
