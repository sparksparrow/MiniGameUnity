using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonFX : MonoBehaviour
{
    [SerializeField]
    public AudioSource _audioSource;

    [SerializeField]
    public AudioClip _clickSound;

    [SerializeField]
    public Button _button;

    public void OnHover() 
    {
        _audioSource.PlayOneShot(_clickSound);
        _button.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
    }

    public void OnExit()
    {
        _button.transform.localScale -= new Vector3(0.5f, 0.5f, 0.5f);
    }


}
