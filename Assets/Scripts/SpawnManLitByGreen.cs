using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManLitByGreen : MonoBehaviour
{
    
    GameObject greenMan;
    GameObject greenManTwo;
    GameObject cameraDetector;

    private AudioSource audioSource;

    public bool soundPlayed;

    float despawnTimer = 3f;


    // Start is called before the first frame update
    void Start()
    {
        soundPlayed = false;

        greenMan = GameObject.Find("GreenMan");
        greenManTwo = GameObject.Find("GreenManTwo");

        cameraDetector = GameObject.Find("CameraDetector");
        greenMan.SetActive(false);
        greenManTwo.SetActive(false);

        audioSource = greenManTwo.GetComponent<AudioSource>();        
    }

    // Update is called once per frame
    void Update()
    {
        if(despawnTimer > 0 && soundPlayed)
        {
            despawnTimer -= Time.deltaTime;
        }

        if(cameraDetector != null && cameraDetector.GetComponent<Renderer>().isVisible && !soundPlayed)
        {
            Debug.Log("VISIBLE");
            audioSource.PlayOneShot(audioSource.clip, 1f);
            soundPlayed = true;
        }
        if(despawnTimer < 0)
        {
            Destroy(greenManTwo);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (greenManTwo != null && other.gameObject.CompareTag("SpawnGreenMan"))
        {
            greenMan.SetActive(true);
            greenManTwo.SetActive(true);
        }                                   
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (greenManTwo != null && other.gameObject.CompareTag("SpawnGreenMan"))
        {
            greenMan.SetActive(false);
        }
    }

}
