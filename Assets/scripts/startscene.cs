using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startscene : MonoBehaviour
{
    public static int curlevel;
    void Start()
    {
      
        Time.timeScale = 1;
        curlevel = PlayerPrefs.GetInt("savedscene");
         Invoke("startlvl", 1f);
     
    }
    public void startlvl()
    {

        if (curlevel == 0)
        {
            SceneManager.LoadSceneAsync(curlevel+1);

        }
        if(curlevel >0 && curlevel <=50)
        {
            SceneManager.LoadSceneAsync( curlevel);
        }
        if (curlevel >= 51)
        {
            SceneManager.LoadSceneAsync(Random.Range(5,50));
        }
    }
}
