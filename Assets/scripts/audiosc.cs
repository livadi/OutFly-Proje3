using UnityEngine.Audio;
using UnityEngine;

public class audiosc : MonoBehaviour
{
    public static AudioClip boom,human,up,coin;
    public static bool isMute;
   public  static AudioSource audioSource;
    void Start()
    {

        boom = Resources.Load<AudioClip>("boom");
        human = Resources.Load<AudioClip>("human");
        up = Resources.Load<AudioClip>("up");
        coin = Resources.Load<AudioClip>("coin");
        audioSource = GetComponent<AudioSource>();
    }
    public void Mute()
    {
        isMute = !isMute;
        AudioListener.volume = isMute ? 0 : 1;
    }
    public static void PlaySound(string clip)
    {
            switch (clip)
            {
                case "boom":
                    audioSource.PlayOneShot(boom);
                    break;
                case "coin":
                    audioSource.PlayOneShot(coin);
                    break;

                case "human":
                    audioSource.PlayOneShot(human);
                    break;        
                case "up":
                    audioSource.PlayOneShot(up);
                    break;
        

        }
        }
    
    
}