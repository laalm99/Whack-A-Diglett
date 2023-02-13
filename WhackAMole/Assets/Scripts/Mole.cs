using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : MonoBehaviour
{
    private Vector3 startingPos;
    [SerializeField] private float posY = 1f;
    [SerializeField] private float speed = 5f;
    [SerializeField] private bool movingUp;
    private Collider collider;
    
   // private float timer = 2f;

    void Start()
    {
        collider = GetComponent<Collider>();
        startingPos = transform.position;
        collider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //timer -= Time.deltaTime;


        if (movingUp)
        {
            if (transform.position.y < posY)
            {
                MoveUp();
                collider.enabled = true;
            }
            else
            {
                transform.position = new Vector3(startingPos.x, posY, startingPos.z);
            }
        }
        else
        {
            if (transform.position.y > startingPos.y)
            {
                MoveDown();
                collider.enabled = false;
            }
            else
            {
                transform.position = startingPos;
            }
        }

    }

    public void SetMovingUp(bool cond)
    {
        movingUp = cond;
    }

    private void MoveUp()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    private void MoveDown()
    {
        transform.Translate(-Vector3.up * speed * Time.deltaTime);
    }

    void OnMouseDown()
    {
        movingUp = false;
        GameManager.Instance.IncreaseScore();
    }
}


/*
 * 
 * close collider for moles that are down
 * 
 * timer for moles that are down (timer in Mole script)
 * 
 * flag for when the mole is up or down
 * 
 * 3d assets:
 * cgtrailer tablesquid .fpx .obj
 */