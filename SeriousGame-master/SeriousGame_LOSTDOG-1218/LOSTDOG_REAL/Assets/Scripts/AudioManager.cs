using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public AudioClip bgm;
    public AudioSource audioSource;
    public int n = 0;

    int[] changePoint = { 0, 7, 15, 24, 29, 41, 54 };

    void Awake()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
        audioSource.volume = 1f;
        DontDestroyOnLoad(this.gameObject); // 이렇게 하면 다음 scene으로 넘어가도 오브젝트가 사라지지 않습니다.
    }

    void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == changePoint[n] && n == 0)
        {
            bgm = Resources.Load("Audio/Arms_of_Heaven") as AudioClip;
            audioSource.clip = bgm;
            audioSource.volume = 1f;
            audioSource.Play();
            n++;
        }

        if(SceneManager.GetActiveScene().buildIndex == changePoint[n] && n == 1)
        {
            bgm = Resources.Load("Audio/Sunrise_Over_Big_Data_Country(2)") as AudioClip;
            this.gameObject.GetComponent<AudioSource>().clip = bgm;
            audioSource.volume = 1f;
            audioSource.Play();
            n++;
        }

        if (SceneManager.GetActiveScene().buildIndex == changePoint[n] && n == 2)
        {
            bgm = Resources.Load("Audio/Window_Demons(3)") as AudioClip;
            this.gameObject.GetComponent<AudioSource>().clip = bgm;
            audioSource.volume = 1f;
            audioSource.Play();
            n++;
        }

        if (SceneManager.GetActiveScene().buildIndex == changePoint[n] && n == 3)
        {
            bgm = Resources.Load("Audio/Dancing_Star(4)") as AudioClip;
            this.gameObject.GetComponent<AudioSource>().clip = bgm;
            audioSource.volume = 1f;
            audioSource.Play();
            n++;
        }

        if (SceneManager.GetActiveScene().buildIndex == changePoint[n] && n == 4)
        {
            bgm = Resources.Load("Audio/Waterfall(5)") as AudioClip;
            this.gameObject.GetComponent<AudioSource>().clip = bgm;
            audioSource.volume = 1f;
            audioSource.Play();
            n++;
        }

        if (SceneManager.GetActiveScene().buildIndex == changePoint[n] && n == 5)
        {
            bgm = Resources.Load("Momentous(6)") as AudioClip;
            this.gameObject.GetComponent<AudioSource>().clip = bgm;
            audioSource.volume = 1f;
            audioSource.Play();
            n++;
        }

        if (SceneManager.GetActiveScene().buildIndex == changePoint[n] && n == 6)
        {
            bgm = Resources.Load("Audio/Epilog_Ghostpocalypse") as AudioClip;
            this.gameObject.GetComponent<AudioSource>().clip = bgm;
            audioSource.volume = 1f;
            audioSource.Play();
            n++;
        }
    }
}