
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class powerup : MonoBehaviour
{
    private int curskin;
    private int pwskin;
    private float pwskinvalue;
    public Button pwsdpbut;
    public TextMeshProUGUI spdtxt;
    public float pwblow;
    private float pwblowvalue;
    public Button pwblowbut;
    public TextMeshProUGUI blowtxt;
    public float pwcoin;
    private float pwcoinvalue;
    public Button pwcoinbut;
    public TextMeshProUGUI cointxt;
    float red;
    float blue;
    float green;
    public Material kitmat;
    public Button curskinbutton;
    public GameObject []skinlist;

    void Start()
    {
        
      
 
        red = PlayerPrefs.GetFloat("redo");
        blue = PlayerPrefs.GetFloat("blueo");
        green = PlayerPrefs.GetFloat("greeno");
        pwskin = PlayerPrefs.GetInt("pwskin");
        pwskinvalue = PlayerPrefs.GetFloat("pwskinlvl");
        kitmat.color = new Color(red, blue, green);
        curskin = PlayerPrefs.GetInt("cursk");
        pwblow = PlayerPrefs.GetFloat("pwbl");
        pwblowvalue = PlayerPrefs.GetFloat("pwblvl");
        pwcoin = PlayerPrefs.GetFloat("pwco");
        pwcoinvalue = PlayerPrefs.GetFloat("pwcovl");
        if (pwcoinvalue == 0)
        {
            pwcoinvalue = 100;
            PlayerPrefs.SetFloat("pwcovl", pwcoinvalue);
        }
        if (pwskinvalue == 0)
        {
            pwskinvalue = 1000;
            PlayerPrefs.SetFloat("pwskinlvl", pwskinvalue);
        }
        if (pwblowvalue == 0)
        {
            pwblowvalue = 100;
            PlayerPrefs.SetFloat("pwblvl", pwblowvalue);
        }
        if (skinlist[curskin])
        {
            skinlist[curskin].SetActive(true);
        }
        buttons();
    }
    public void speedup()
    {
        if(distancemeter.coin >= pwskinvalue)
        {
            audiosc.audioSource.pitch = 0.5f;
            audiosc.PlaySound("coin");
            distancemeter.coin-= pwskinvalue;
            pwskin += 1;
            pwskinvalue += Mathf.Round(pwskinvalue*3);
            PlayerPrefs.SetFloat("coin", distancemeter.coin);
            PlayerPrefs.SetInt("pwskin", pwskin);
            PlayerPrefs.SetFloat("pwskinlvl", pwskinvalue);    
            PlayerPrefs.Save();
            buttons();
        }       
    }
    public void blowup()
    {
        if (distancemeter.coin >= pwblowvalue)
        {
            audiosc.audioSource.pitch = 1.5f;
            audiosc.PlaySound("coin");
            distancemeter.coin -= pwblowvalue;
            pwblow += 0.1f;
            pwblowvalue += Mathf.Round(pwblowvalue/2);
            PlayerPrefs.SetFloat("coin", distancemeter.coin);
            PlayerPrefs.SetFloat("pwbl", pwblow);
            PlayerPrefs.SetFloat("pwblvl", pwblowvalue);          
            PlayerPrefs.Save();
            randomcolor();
        }
    }
    public void coinup()
    {
        if (distancemeter.coin >= pwcoinvalue)
        {
            audiosc.audioSource.pitch = 1.5f;
            audiosc.PlaySound("coin");
            distancemeter.coin -= pwcoinvalue;
            pwcoin += 1f;
            pwcoinvalue += Mathf.Round(pwcoinvalue/2);
            PlayerPrefs.SetFloat("coin", distancemeter.coin);
            PlayerPrefs.SetFloat("pwco", pwcoin);
            PlayerPrefs.SetFloat("pwcovl", pwcoinvalue);         
            PlayerPrefs.Save();
            randomcolor();  
        }
    }
    void randomcolor()
    {
        red = Random.Range(0f, 1f);
        blue = Random.Range(0f, 1f);
        green = Random.Range(0f, 1f);
        PlayerPrefs.SetFloat("blueo", blue);
        PlayerPrefs.SetFloat("greeno", green);
        PlayerPrefs.SetFloat("redo", red);
        kitmat.color = new Color(red, blue, green);
        buttons();
    }
    public void changeskin()
    {
        if (curskin != pwskin)
        {
            skinlist[curskin].SetActive(false);
            curskin++;
            if (curskin == skinlist.Length)
                curskin = 0;
            skinlist[curskin].SetActive(true);
            PlayerPrefs.SetInt("cursk",curskin);

        }
    else
        {
            skinlist[curskin].SetActive(false);            
            curskin = 0;
            skinlist[curskin].SetActive(true);
            PlayerPrefs.SetInt("cursk", curskin);
        }
     
    }
    void buttons()
    {
        
            blowtxt.text = pwblowvalue.ToString();
            cointxt.text = pwcoinvalue.ToString();
            spdtxt.text = pwskinvalue.ToString();
        
            
        if (distancemeter.coin <= pwskinvalue)
        {
            pwsdpbut.interactable = false;
        }
        else
        {
            pwsdpbut.interactable = true;
        }
        if (distancemeter.coin <= pwcoinvalue)
        {
            pwcoinbut.interactable = false;
        }
        else
        {
            pwcoinbut.interactable = true;
        }
        if (distancemeter.coin <= pwblowvalue)
        {
            pwblowbut.interactable = false;
        }
        else
        {
            pwblowbut.interactable = true;
        }
        if (pwskin == 0)
        {
            curskinbutton.interactable = false;
        }
        else
        {
            curskinbutton.interactable = true;
        }
    }

}
