using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AdaptivePerformance.VisualScripting;

public class kuniMover : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip kuniaAudioClip;
    public AudioSource kuniaAudio;
    void Start()
    {
        kuniaAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * 15f);
    }
    private void OnTriggerEnter(Collider other)
    {
        
        Destroy(gameObject);
        Destroy(other.gameObject);
        kuniaAudio.PlayOneShot(kuniaAudioClip, 1.0f);
    }
}