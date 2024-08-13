using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager uIManagerInstance;
    [SerializeField]
    Text killerNumberText;
    int killerNumber;
    [SerializeField]
    Slider healthSlider;
    [SerializeField]
    GameObject panelGameOver;
    // Start is called before the first frame update
    private void Awake()
    {
        if (uIManagerInstance != null && uIManagerInstance != this)
        {
            Destroy(this);
        }
        else
        {
            uIManagerInstance = this;
        }
    }
    void Start()
    {
        killerNumber = 0;
        killerNumberText.text = "0";
        panelGameOver.SetActive(false);
    }

    public void UpdateKillNumber()
    {
        killerNumber++;
        killerNumberText.text = "" + killerNumber;
    }

    public void UpdateHealthSlider(float inputValue)
    {
        healthSlider.value = inputValue;
    }

    public void GameOver()
    {
        panelGameOver.SetActive(true);
    }

    public void Replay()
    {
        SceneManager.LoadScene("SampleScene");
    }
    
}
