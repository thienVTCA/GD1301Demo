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
    [SerializeField]
    Text textPlayerTakeDam;
    [SerializeField]
    AudioListener audioListener;
    [SerializeField]
    List<GameObject> listBGGameObject;
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
        InitAllInfor();
        killerNumber = 0;
        killerNumberText.text = "0";
        panelGameOver.SetActive(false);
        textPlayerTakeDam.gameObject.SetActive(false);
    }

    void InitAllInfor()
    {
        audioListener.enabled = PlayerPrefs.GetInt("GameSound", 0) == 1?true:false;
        for(int i = 0; i < listBGGameObject.Count; i++)
        {
            listBGGameObject[i].SetActive(false);
        }
        int indexBG = PlayerPrefs.GetInt("indexChooseTheme", 0);
        listBGGameObject[indexBG].SetActive(true);
    }

    public void UpdateKillNumber()
    {
        killerNumber++;
        killerNumberText.text = "" + killerNumber;
    }

    public void OnSliderValueChanged()
    {
        textPlayerTakeDam.gameObject.SetActive(true);
        
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
        SceneManager.LoadScene("GamePlay");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
    
}
