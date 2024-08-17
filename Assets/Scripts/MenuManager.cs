using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    Slider sliderLoadGame;
    [SerializeField]
    GameObject panelMainMenu, panelLoadGame, 
        panelChangeTheme, panelSoundSetting;
    [SerializeField]
    Toggle toggleSoundOn, toggleSoundOff;
    [SerializeField]
    List<Toggle> listThemeChooseToggle;
    // Start is called before the first frame update
    void Start()
    {
        MainMenu();
    }

    public void StartGame()
    {
        //SceneManager.LoadScene("GamePlay");
        panelMainMenu.SetActive(false);
        panelLoadGame.SetActive(true);
        panelSoundSetting.SetActive(false);
        panelChangeTheme.SetActive(false);
        StartCoroutine(LoadYourAsyncScene());
    }

    void MainMenu()
    {
        panelMainMenu.SetActive(true);
        panelLoadGame.SetActive(false);
        panelSoundSetting.SetActive(false);
        panelChangeTheme.SetActive(false);
        if (PlayerPrefs.GetInt("GameSound", 0) == 1)
        {
            toggleSoundOn.isOn = true;
        }
        else
        {
            toggleSoundOff.isOn = true;
        }
        int indexBG = PlayerPrefs.GetInt("indexChooseTheme", 0);
        listThemeChooseToggle[indexBG].isOn = true;
    }

    public void SoundSetting()
    {
        panelMainMenu.SetActive(false);
        panelLoadGame.SetActive(false);
        panelChangeTheme.SetActive(false);
        panelSoundSetting.SetActive(true);
    }

    public void ChangeTheme()
    {
        panelMainMenu.SetActive(false);
        panelLoadGame.SetActive(false);
        panelChangeTheme.SetActive(true);
        panelSoundSetting.SetActive(false);
    }

    IEnumerator LoadYourAsyncScene()
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("GamePlay");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            sliderLoadGame.value = asyncLoad.progress;
            yield return null;
        }
    }

    public void SoundSettingOK()
    {
        if(toggleSoundOff.isOn)
        {
            PlayerPrefs.SetInt("GameSound", 0);
        }
        else
            if(toggleSoundOn.isOn)
        {
            PlayerPrefs.SetInt("GameSound", 1);
        }
        MainMenu();
    }

    public void ThemeChooseOK()
    {
        for(int i = 0; i < listThemeChooseToggle.Count; i++)
        {
            if (listThemeChooseToggle[i].isOn)
            {
                PlayerPrefs.SetInt("indexChooseTheme", i);
                break;
            }
        }
        MainMenu();
    }
}
