using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveKeyObject : MonoBehaviour
{
    Vector2 mousePos;
    Vector2 distance;
    Vector2 orPos;
    Rigidbody2D rb2d;
    private float movspeed = 3.0f;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        orPos = transform.position;
    }

    private void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        OnMouseUpAsButton();
    }

    private void OnMouseDown()
    {
        distance = new Vector2(transform.position.x, transform.position.y) - mousePos;
    }

    private void OnMouseDrag()
    {
        transform.position = mousePos + distance;
        rb2d.velocity = Vector2.zero;
    }

    private void OnMouseUpAsButton()
    {
        this.transform.position = Vector2.MoveTowards(this.transform.position, orPos, movspeed * Time.deltaTime);
    }


}
