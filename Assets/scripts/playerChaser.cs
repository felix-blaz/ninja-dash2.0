using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class playerChaser : MonoBehaviour
{
    public GameObject Player;
    private Vector3 chasePos = new Vector3(0, 2, -8);
    private float seconds = 0f;
    public AudioClip chasserAudioClip;
    public AudioClip catchAudio;
    public AudioSource chaserAudio;
    bool audioPlaying = false;
    public ParticleSystem chaserParticle;

    //private Vector3 NewchasePos = new Vector3 (0, 0, )
    public float speed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        chaserAudio = GetComponent<AudioSource>();
        transform.position = Player.transform.position + chasePos;
    }

    // Update is called once per frame
    void Update()
    {

        Chase();
    }

    void Chase()
    {
        float chaseWait = 10;
        playerDamage manager = FindObjectOfType<playerDamage>();
        if (manager.isGameActive == true)
        {
            transform.position = Player.transform.position + chasePos;

            seconds += Time.deltaTime;
            if (seconds >= chaseWait)
            {
                chasePos.z += speed;
                seconds = 0f;
            }

         if(manager.tookDamage == true)
            {
               chaseWait--;
            }

         if(manager.tookHealth == true)
            {
                chaseWait++;

                chasePos.z = -8;
            }
            if (chasePos.z > -5 && !audioPlaying)
            {
                PlayChaserAudio();
            }
        }

    }
    void PlayChaserAudio()
    {
        chaserAudio.PlayOneShot(chasserAudioClip, 1.0f);
        audioPlaying = true;
    }
    private void OnTriggerEnter(Collider other)
    {

        playerDamage manager = FindObjectOfType<playerDamage>();
        if (other.CompareTag("Player"))
        {
            chaserAudio.PlayOneShot(catchAudio, 1.0f);
            chaserParticle.Play();
           // Destroy(other.gameObject);
            StartCoroutine(chill());
        }
    }

        IEnumerator chill()
        {

        yield return new WaitForSeconds(0.5f);
        playerDamage manager = FindObjectOfType<playerDamage>();
        manager.GameOver();

        }
}