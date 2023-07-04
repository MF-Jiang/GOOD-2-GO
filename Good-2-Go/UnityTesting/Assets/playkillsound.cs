using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playkillsound : MonoBehaviour
{
    public AudioClip[] killsounds;
    private AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void kill()
    {
        source.clip = killsounds[Random.Range(0, killsounds.Length)];
        source.PlayOneShot(source.clip);
    }
}
