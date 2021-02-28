
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class scenemanager : MonoBehaviour
{

    public TextMeshProUGUI levelUI;
    public GameObject startbutton;

    void Start()
    {
      
        levelUI.text =startscene.curlevel.ToString();      
        Time.timeScale = 0;    
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void startbut()
    {
     
        Time.timeScale = 1;
        startbutton.SetActive(false);
    }
    public void restartbut()
    {

   
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.Save();
    }
    public void nextlevel()
    {       
        startscene. curlevel++;
        PlayerPrefs.SetInt("savedscene", startscene.curlevel);
        PlayerPrefs.Save();
        if (startscene.curlevel > 50)
        {
            SceneManager.LoadScene(Random.Range(5,50));
        }
        else
        {
            SceneManager.LoadScene(startscene.curlevel);
        }
    }
   
 
    
}
