using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelText : MonoBehaviour
{

    Text levelText;

    void Start()
    {
        levelText = gameObject.GetComponent<Text>();
        levelText.text = (SceneManager.GetActiveScene().buildIndex + 1) + "";
    }
}
