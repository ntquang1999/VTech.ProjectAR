using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Stack : MonoBehaviour
{

    [SerializeField]
    float moveSpeed = 5f;

    int side = 1;
    //float height = 5.5f;
    float x, y, z;
    bool moving = true;
    Vector3 direction;
    public int directionInt;
    float swingDistance = 2;

    void Start()
    {
        

        if (side == 1)
        {
            swingDistance = (transform.localScale.x/2) > 3 ? (transform.localScale.x / 2) : 3;
            transform.position = new Vector3(x - (transform.localScale.x + swingDistance), y, z);
            direction = transform.right;
            directionInt = 1;
        }
            
        else
        {
            swingDistance = (transform.localScale.z / 2) > 3 ? (transform.localScale.z / 2) : 3;
            transform.position = new Vector3(x, y, z+ (transform.localScale.z + swingDistance));
            direction = -transform.forward;
            directionInt = -1;
        }

        //GetComponent<Renderer>().material.color = new Color(UnityEngine.Random.Range(0,1f), UnityEngine.Random.Range(0, 1f), UnityEngine.Random.Range(0, 1f));
    }

    void Update()
    {
        if (transform.position.x >= x + (transform.localScale.x + swingDistance))
        {
            direction = -transform.right;
            directionInt = -1;
        }
            
        if (transform.position.x <= x -(transform.localScale.x + swingDistance))
        {
            direction = transform.right;
            directionInt = 1;
        }
            

        if (transform.position.z >= z + (transform.localScale.z + swingDistance))
        {
            direction = -transform.forward;
            directionInt = -1;
        }
            
        if (transform.position.z <= z -(transform.localScale.z + swingDistance))
        {
            direction = transform.forward;
            directionInt = 1;
        }
            

        if(moving) transform.position += direction * Time.deltaTime * moveSpeed;
    }

    public void setSide(int side)
    {
        this.side = side;
    }

    public void setState(bool state)
    {
        moving = state;
    }

    public void setDemension(float x, float y, float z, float scaleX, float scaleZ)
    {
        this.x = x;
        this.y = y;
        this.z = z;
        transform.localScale = new Vector3(scaleX, transform.localScale.y, scaleZ);
    }

    public void makeSpark()
    {
        transform.GetComponent<Renderer>().material.DOFade(0, 1);
    }
}
