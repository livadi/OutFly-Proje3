
using UnityEngine;

public class human : MonoBehaviour
{
    public GameObject nextlevel;
    public distancemeter distUI;
    public static float excoinint;
    private float bestscore;
    public GameObject fire;
    public GameObject curoint;
    public ParticleSystem part;
    Rigidbody rb;
    bool stopmove;
    float humanspeed;
    private bool humanstop;
    int videoadcount;
    public admanager adManager;
    private void Start()
    {
      

        videoadcount = PlayerPrefs.GetInt("vidad");
        rb = GetComponent<Rigidbody>();
        curoint.SetActive(true);
        bestscore = PlayerPrefs.GetFloat("best");
        audiosc.audioSource.pitch = Random.Range(0.8f, 1.2f);
        audiosc.PlaySound("boom");
    }
    private void Update()
    {
        humanspeed = rb.velocity.magnitude;
        
        if (humanspeed < 0.1f)
        {
            if (humanstop==false)
            {
                humanstop = true;
                Invoke("deget", 2f);
            }
        }
        if (!stopmove)
        {
            float dirx = Input.acceleration.x * 20;
            rb.velocity = new Vector3(dirx, rb.velocity.y, rb.velocity.z);
        }
       
    }
    void OnCollisionEnter(Collision col)
    {
       
        if (col.gameObject.tag == "coin")
            {
            stopmove = true;
            part.Play();              
                excoinint += col.gameObject.GetComponent<wind>().coinvalue;
            distUI.firstcoin.color = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f), 1f);

            distUI.firstcoin.text = excoinint.ToString();
            curoint.GetComponent<Animator>().Play("gold", 0, 0.25f);
            col.gameObject.tag = "Untagged";
            audiosc.audioSource.pitch = Random.Range(0.6f, 1.4f) ;
            audiosc.PlaySound("human");
           
            
            distUI.excoin.text = excoinint.ToString();

            
            }
    }
   void deget()
    {
        excoinint += distUI.curheight;
       
        
        distUI.firstcoin.text = "".ToString();
        distancemeter.coin += excoinint/3;
            PlayerPrefs.SetFloat("coin", distancemeter.coin);
            if (excoinint > bestscore)
            {
                bestscore = excoinint;
        
            fire.SetActive(true);
                distUI.bestUI.text = ("New High Score").ToString();
                PlayerPrefs.SetFloat("best", bestscore);
                

            }
        else
        {
            distUI.bestoldUI.text = ("Best Score",bestscore).ToString();
        }
        videoadcount++;
        PlayerPrefs.SetInt("vidad", videoadcount);
        if (videoadcount == 3)
        {
            adManager.RequestRewardBasedVideo();
            videoadcount = 0;
            PlayerPrefs.SetInt("vidad", videoadcount);
        }
        PlayerPrefs.Save();
        Invoke("next", 2);
    }
   void next()
    {
        nextlevel.SetActive(true);
    }

}
