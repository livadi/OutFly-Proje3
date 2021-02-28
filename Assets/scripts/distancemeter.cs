
using UnityEngine;
using TMPro;

public class distancemeter : MonoBehaviour
{
    
    public TextMeshProUGUI distUI;
    public TextMeshProUGUI coinUI;
    public TextMeshProUGUI titleUI;
    public TextMeshProUGUI excoin;
    public TextMeshProUGUI bestUI;
    public TextMeshProUGUI bestoldUI;
    public TextMeshProUGUI firstcoin;
    public GameObject playerkite;
    public GameObject gameoverbutton;
   
    public  float height ;
   
    public static float coin;
    public float curheight;
    void Start()
    {
        
            colorset();
     
        coin = PlayerPrefs.GetFloat("coin");
    }

    void Update()
    {
       
            height = Mathf.Round(playerkite.transform.position.y);
        distUI.text = height.ToString();
        coinUI.text = Mathf.Round(coin).ToString();
        float ypos = Mathf.Clamp(Mathf.Abs(500 /height), 0, 1.6f);
        RenderSettings.skybox.SetFloat("_AtmosphereThickness",  ypos);
        
    }
  void colorset()
    {
        if (startscene.curlevel >= 0 && startscene.curlevel <= 5|| startscene.curlevel >= 50 && startscene.curlevel <= 55)
        {
            RenderSettings.skybox.SetColor("_SkyTint", new Color32(1, 1, 85, 255));
        }
        if (startscene.curlevel > 5 && startscene.curlevel <= 10 || startscene.curlevel >= 55 && startscene.curlevel <= 60)
        {
            RenderSettings.skybox.SetColor("_SkyTint", new Color32(103, 1, 85, 255));
        }
        if (startscene.curlevel > 10 && startscene.curlevel <= 15 || startscene.curlevel >= 60 && startscene.curlevel <= 65)
        {
            RenderSettings.skybox.SetColor("_SkyTint", new Color32(94, 147, 166, 255));
        }
        if (startscene.curlevel > 20 && startscene.curlevel <= 25 || startscene.curlevel >= 65 && startscene.curlevel <= 70)
        {
            RenderSettings.skybox.SetColor("_SkyTint", new Color32(0, 203, 81, 255));
        }
        if (startscene.curlevel > 25 && startscene.curlevel <= 30 || startscene.curlevel >= 70 && startscene.curlevel <= 75)
        {
            RenderSettings.skybox.SetColor("_SkyTint", new Color32(0, 202, 5, 255));
        }
        if (startscene.curlevel > 30 && startscene.curlevel <= 35 || startscene.curlevel >= 75 && startscene.curlevel <= 80)
        {
            RenderSettings.skybox.SetColor("_SkyTint", new Color32(252, 255, 9, 255));
        }
        if (startscene.curlevel > 35 && startscene.curlevel <= 40 || startscene.curlevel >= 80 && startscene.curlevel <= 85)
        {
            RenderSettings.skybox.SetColor("_SkyTint", new Color32(3, 3, 3, 255));
        }
        if (startscene.curlevel > 40 && startscene.curlevel <= 45 || startscene.curlevel >= 85 && startscene.curlevel <= 90)
        {
            RenderSettings.skybox.SetColor("_SkyTint", new Color32(255, 255, 255, 255));
        }
        if (startscene.curlevel > 45 && startscene.curlevel <= 50 || startscene.curlevel >= 90 && startscene.curlevel <= 95)
        {
            RenderSettings.skybox.SetColor("_SkyTint", new Color32(203, 203, 255, 255));
        }
        if (startscene.curlevel > 95 && startscene.curlevel <= 100)
        {
            RenderSettings.skybox.SetColor("_SkyTint", new Color32(172, 0, 203, 255));
        }

    }

}
