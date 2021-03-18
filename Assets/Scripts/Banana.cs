using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Banana : MonoBehaviour
{
    [SerializeField]
    GameObject _banana;

    [SerializeField]
    public AudioSource _audioSource;

    [SerializeField]
    private AudioClip _spawnSound;

    [SerializeField]
    public AudioClip _destroySound;

    [SerializeField]
    public AudioClip _timeOutSound;

    private Text _score;

    private Image _lifeImage;

    private int lifeTime = 2000;

    private static int life = 3;

    private void Start()
    {
        _audioSource.PlayOneShot(_spawnSound);
        _score = GameObject.Find("Score").GetComponent<Text>();
    }

    void Update()
    {
        lifeTime -= 1;
        if(life==0)
        {
            life = 3;
            SceneManager.LoadScene("MenuScene");
        }

        if (lifeTime == 0)
        {
            _lifeImage = GameObject.Find($"ImageBananaHealth{life}").GetComponent<Image>();
            life -= 1;
            playClipBeforeDestroy(_timeOutSound);
            Destroy(_lifeImage);
            Destroy(_banana);            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
            return;

        _score.text = (int.Parse(_score.text)+1).ToString();
        playClipBeforeDestroy(_destroySound);
        Destroy(_banana);
    }


    private void playClipBeforeDestroy(AudioClip sound)
    {
        GameObject soundAfterDestroy = new GameObject("TempAudio");
        soundAfterDestroy.transform.position = this.transform.position;
        AudioSource audioSource = soundAfterDestroy.AddComponent<AudioSource>();
        audioSource.clip = sound;
        audioSource.volume = 0.6f;
        audioSource.Play();
        Destroy(soundAfterDestroy, sound.length);
    }

    public static void RefreshLife() => life = 3;

}
