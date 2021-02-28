
using UnityEngine;


public class kiterun : MonoBehaviour
{
    public powerup pwup;
    public distancemeter distUI;
   private Rigidbody rb;
    public float speed ;
    float airstack;
    public GameObject _ballonblow;
    public GameObject bot;  
   public static ParticleSystem aireffect;
    public GameObject baloonspeed;
    public Animator anim;
    public GameObject camera1;
    public GameObject camera2;
    float dirx;
    public admanager adManager;
    int adcount;
    void Start()
    {
       adcount= PlayerPrefs.GetInt("adc");
        aireffect = GetComponent<ParticleSystem>();
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        Vector3 curPos = transform.position;
        curPos.y = Mathf.Clamp(curPos.y, -10, 1500);
        curPos.x = Mathf.Clamp(curPos.x, -5, 5);
        transform.position = curPos;
         dirx = Input.acceleration.x * 100;
        //dirx = Input.GetAxis("Horizontal") * speed;
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    ballonblow();
        //}
    }
    void FixedUpdate()
    {
       
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        rb.velocity = new Vector2(dirx, rb.velocity.y);
    }

    private void OnTriggerEnter(Collider other)
    {
        var part = aireffect.main;
        if (other.tag == "wind")
        {         
            rb.velocity = Vector3.up * other.GetComponent<wind>().move;
            Destroy(other.gameObject);  
            part.startColor = Color.white;
            aireffect.Play();
            audiosc.audioSource.pitch = 1f;
            audiosc.PlaySound("up");
        }
        if (other.tag == "windo")
        {
            rb.velocity = Vector3.down * other.GetComponent<wind>().move;
            Destroy(other.gameObject);
            part.startColor = Color.gray;
            aireffect.Play();            
            audiosc.audioSource.pitch = 0.6f;
            audiosc.PlaySound("up");          
        }
        if (other.tag == "endwall")
        {
            Time.timeScale = 0.5f;
            rb.velocity = new Vector3(0, 0, 0);
            Destroy(bot.GetComponent<HingeJoint>());
            Invoke("baloonbom", 1f);
            _ballonblow.SetActive(true);                
        }
        if (other.tag == "coin")
        {
            distancemeter.coin += other.gameObject.GetComponent<wind>().coinvalue+pwup.pwcoin;         
            audiosc.audioSource.pitch =1f;
            audiosc.PlaySound("coin");        
            Destroy(other.gameObject);     
        }
       
        if (other.tag == "speed")
        {
            Destroy(other.gameObject);           
            speed += other.gameObject.GetComponent<wind>().move;
            rb.velocity = Vector3.up * Mathf.Abs( other.GetComponent<wind>().move);
            Invoke("speedstop", 2f);
            baloonspeed.SetActive(true);
           
        }
        
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "crash")
        {
            adcount++;
            audiosc.PlaySound("boom");
            gameObject.SetActive(false);
         
            PlayerPrefs.SetFloat("coin", distancemeter.coin);
            PlayerPrefs.SetInt("adc", adcount);
            PlayerPrefs.Save();
            if (adcount == 3)
            {
                adManager.RequestInterstitial();
                adcount = 0;
                PlayerPrefs.SetInt("adc", adcount);
            }
            Invoke("tryagain", 2);
          

        }
    }
    void tryagain()
    {
        distUI.gameoverbutton.SetActive(true);
    }
    void baloonbom()
    {        
        camera2.GetComponent<Camera>().enabled = true;
        camera1.SetActive(false);
        Time.timeScale = 1f;
        bot.GetComponentInChildren<human>().enabled = true;  
        distUI.curheight =Mathf.Round( distUI.height/15);
        bot.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, distUI.height/10*airstack*pwup.pwblow);
        if (airstack >= 0 && airstack<= 5)
        {
            distUI.titleUI.color = Color.red;
            distUI.titleUI.text = ("Bad").ToString();
        }
        else if(airstack >= 6 && airstack <= 10)
        {
            distUI.titleUI.color = Color.yellow;
            distUI.titleUI.text = ("Good").ToString();
        }
        else if (airstack >= 11)
        {
            distUI.titleUI.color = Color.green;
            distUI.titleUI.text = ("Perfect!").ToString();
        }
        gameObject.SetActive(false);
        _ballonblow.SetActive(false);
        Invoke("closetitle", 2f);
    }
    void closetitle()
    {
        distUI.titleUI.text = ("").ToString();
    }
    public void ballonblow()
    {
        audiosc.PlaySound("up");     
        rb.velocity = new Vector3(0, 20, 0);
        transform.localScale += new Vector3(30, 30,30) / 450;
        airstack += 1;
        anim.Play("1",0,0.01f);
     
    }
    void speedstop()
    {
        speed = 20;
       baloonspeed.SetActive(false);
    }
  

}
