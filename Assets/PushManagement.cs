using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushManagement : MonoBehaviour
{
    private Rigidbody2D _rb;


    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    } 


    public void Pushback(float scale)
    {
        //float dir = scale * transform.localScale.x;
        //_rb.AddForce(new Vector2(-5, 0), ForceMode2D.Impulse);
        _rb.AddForce(new Vector2(-scale * this.gameObject.transform.localScale.x, 0), ForceMode2D.Impulse);
        //Debug.Log(gameObject);
        //Debug.Log("Push triggered");
    }
}
