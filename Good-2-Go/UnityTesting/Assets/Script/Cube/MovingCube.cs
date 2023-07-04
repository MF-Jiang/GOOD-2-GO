using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCube : MonoBehaviour
{
    public float movspeed = 0.5f;
    GameObject Pos1;
    GameObject Pos2;

    public bool gofirstPos1 = true;
    public bool hasSomethinginCenter = false;

    public AudioClip[] movesounds;
    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        Pos1 = transform.parent.GetChild(1).gameObject;
        Pos2 = transform.parent.GetChild(2).gameObject;

        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gofirstPos1 == false)
        {
           gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, Pos2.transform.position, movspeed * Time.deltaTime);

        }

        if (gofirstPos1 ==true)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, Pos1.transform.position, movspeed * Time.deltaTime);

        }
    }

    private void OnTriggerStay(Collider other)
    {

        if (((other.gameObject.tag != "Cube" && other.gameObject.tag != "Goal" && other.gameObject.transform.parent.parent.gameObject.tag == "FakeEnemy") || (other.gameObject.tag != "Cube" && other.gameObject.tag != "Goal" && other.gameObject.transform.parent.parent.gameObject.tag == "P1Enemy") || (other.gameObject.tag != "Cube" && other.gameObject.tag != "Goal" && other.gameObject.transform.parent.parent.gameObject.tag == "P2Enemy") || other.gameObject.tag == "Player") && other.transform.position.x == gameObject.transform.position.x && other.transform.position.z == gameObject.transform.position.z)
        {
            hasSomethinginCenter = true;
        }

        if (((other.gameObject.tag == "Player" && ((other.transform.parent.gameObject.GetComponent<Playermovement1>() && other.transform.parent.gameObject.GetComponent<Playermovement1>().movetoanotherCube == false) || (other.transform.parent.gameObject.GetComponent<Playermovement2>() && other.transform.parent.gameObject.GetComponent<Playermovement2>().movetoanotherCube == false))) && hasSomethinginCenter == true))
        {
            Vector3 tempPos = gameObject.transform.position;
            tempPos.y = tempPos.y + 1.5f;
            other.transform.parent.gameObject.transform.position = tempPos;
        }

        if (((other.gameObject.tag != "Cube" && other.gameObject.tag != "Goal" && other.gameObject.transform.parent.parent.gameObject.tag == "FakeEnemy") || (other.gameObject.tag != "Cube" && other.gameObject.tag != "Goal" && other.gameObject.transform.parent.parent.gameObject.tag == "P1Enemy") || (other.gameObject.tag != "Cube" && other.gameObject.tag != "Goal" && other.gameObject.transform.parent.parent.gameObject.tag == "P2Enemy")) && hasSomethinginCenter == true)
        {
            Vector3 tempPos = gameObject.transform.position;
            tempPos.y = tempPos.y + 0.88f;
            other.gameObject.transform.parent.parent.gameObject.transform.position = tempPos;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if ((other.gameObject.tag != "Cube" && other.gameObject.tag != "Goal" && other.gameObject.transform.parent.parent.gameObject.tag == "FakeEnemy") || (other.gameObject.tag != "Cube" && other.gameObject.tag != "Goal" && other.gameObject.transform.parent.parent.gameObject.tag == "P1Enemy") || (other.gameObject.tag != "Cube" && other.gameObject.tag != "Goal" && other.gameObject.transform.parent.parent.gameObject.tag == "P2Enemy") || other.gameObject.tag == "Player")
        {
            hasSomethinginCenter = false;

        }
    }

    public void MovePosition() {
        source.clip = movesounds[Random.Range(0, movesounds.Length)];
        source.PlayOneShot(source.clip);

        if (gameObject.transform.position == Pos1.transform.position) {
            gofirstPos1 = false;

        }

        if (gameObject.transform.position == Pos2.transform.position) {
            gofirstPos1 = true;
        }
    }
}
