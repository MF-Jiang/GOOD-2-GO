using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullRodStyle2 : MonoBehaviour
{
    public GameObject Style2Cubefather;
    public PullRodStyle2Cube[] Style2Cubes;

    public AudioClip[] triggersounds;
    private AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        Style2Cubes = Style2Cubefather.gameObject.GetComponentsInChildren<PullRodStyle2Cube>();
        //Debug.Log(Style1Cubes[0].name);
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) {
            source.clip = triggersounds[Random.Range(0, triggersounds.Length)];
            source.PlayOneShot(source.clip);

            for (int i = 0; i < Style2Cubes.Length; i++) {
                Style2Cubes[i].GetComponent<PullRodStyle2Cube>().couldMove = !Style2Cubes[i].GetComponent<PullRodStyle2Cube>().couldMove;
            }
            
        }
    }
}
