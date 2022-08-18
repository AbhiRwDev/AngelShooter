using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelManager : MonoBehaviour
{
    public GameObject[] Levels;
   public int CurrentLevel;
    [SerializeField] Text lvltext;
    public int unlockedLvls;
    // Start is called before the first frame update
    private void Awake()
    {
    
        if(SceneManager.GetActiveScene().name=="game")Screen.SetResolution(1920,1080,FullScreenMode.ExclusiveFullScreen);
        foreach (var item in Levels)
        {
            item.SetActive(false);
        }
    }
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "game")
        {
            CurrentLevel = PlayerPrefs.GetInt("gg");


            Loadlevel(CurrentLevel);
        }
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown("a"))
        {
            NextLevel();
        }
       if(lvltext!=null)
        lvltext.text = (CurrentLevel + 1).ToString();
    }
    
    public void Loadlevel(int Lvl)
    {
       
        Levels[Lvl].SetActive(true);

        if (PlayerPrefs.GetInt("unLvls") < CurrentLevel)
        {
            unlockedLvls = CurrentLevel;
            PlayerPrefs.SetInt("unLvls", unlockedLvls);
        }


    }
    public void NextLevel()
    {
        if(CurrentLevel>=Levels.Length-1)
        {
            CurrentLevel =0;
        }
        else
        {
            CurrentLevel += 1;
        }
            
            PlayerPrefs.SetInt("gg", CurrentLevel);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void setlevel(int lvl)
    {
        CurrentLevel = lvl;
        PlayerPrefs.SetInt("gg", CurrentLevel);
        SceneManager.LoadScene("game");


    }
   public void openscene()
    {
        SceneManager.LoadScene("ui");
    }

}
