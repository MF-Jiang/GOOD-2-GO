using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullRodStyle1 : MonoBehaviour
{
    public GameObject Style1Cubefather;
    public PullRodStyle1Cube[] Style1Cubes;

    public AudioClip[] triggersounds;
    private AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        Style1Cubes = Style1Cubefather.gameObject.GetComponentsInChildren<PullRodStyle1Cube>();
        //Debug.Log(Style1Cubes[0].name);
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            source.clip = triggersounds[Random.Range(0, triggersounds.Length)];
            source.PlayOneShot(source.clip);

            for (int i = 0; i < Style1Cubes.Length; i++) {
                Style1Cubes[i].GetComponent<PullRodStyle1Cube>().MovePosition();
            }
            
        }
    }
}
