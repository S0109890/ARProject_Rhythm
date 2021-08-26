using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OffsetManager : MonoBehaviour
{
    float timer;
    public float setOffset = 2.5f;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        //OffsetManager를 먼저 실행한뒤, 일정시간이 지난뒤 NoteManager를 실행하고 싶다.
        
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.Play();

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
