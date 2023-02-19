using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lamya.whackamole
{
    public class Mole : MonoBehaviour
    {
        private Vector3 startingPos;
        private Collider collider;
        private bool movingUp;
        [SerializeField] private float posY = 1f;
        [SerializeField] private float speed = 5f;
        [SerializeField] private float timer = 2f;
        private float fixedTimer;
        public float FixedTimer
        {
            get  => fixedTimer;
            set
            {
                fixedTimer = value;
            }
        }
        public static event Action IncreaseScoreEvent;


        void Start()
        {
            collider = GetComponent<Collider>();
            startingPos = transform.position;
            collider.enabled = false;
            fixedTimer = timer;
        }

        void Update()
        {
            timer -= Time.deltaTime;
            MovingAnimation(movingUp);
        }



        public void SetMovingUp(bool cond)
        {
            movingUp = cond;
        }


        private void MovingAnimation(bool movingup)
        {
            if (movingUp)
            {
                if (transform.position.y < posY)
                {
                    MoveUp();
                    collider.enabled = true;
                    timer = fixedTimer;
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

            if (timer <= 0 && !GameManager.Instance.GameEnded)
            {
                movingUp = false;
            }
        }

        private void MoveUp()
        {
            transform.Translate(speed * Time.deltaTime * Vector3.up);
        }
        private void MoveDown()
        {
            transform.Translate(speed * Time.deltaTime * -Vector3.up);
        }


        void OnMouseDown()
        {
            movingUp = false;
            IncreaseScoreEvent?.Invoke();
        }
    }
}



/*
 * #close collider for moles that are down
 * 
 * #timer for moles that are up (timer in Mole script)
 * 
 * add event system
 * 
 * add particlesystem
 * 
 */