using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneChage : MonoBehaviour
{
    public TextMeshProUGUI count;
    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            count.text = "Special Bullet Count:" + BulletCount.bulletCount.ToString();
        }
    }

    public void startButton()
    {
        SceneManager.LoadScene(1);
    }

    public void restartButton()
    {
        SceneManager.LoadScene(0);
    }
}
