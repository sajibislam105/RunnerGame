using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public Animator _animator;

    //movement of animations
    private float velocityZ = 0.0f;
    private float velocityX = 0.0f;
    
    //movement of rigidbody
    [SerializeField] float moveSpeed = 5f;     // The speed at which the character moves
    [SerializeField] float sidewaysLimit = 2f;
    public bool isPlayerMoving = false; 
   
    
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPlayerMoving && Input.GetKey(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            isPlayerMoving = true;
        }
        // Move the character forward
        if (isPlayerMoving)
        {
            // Get the horizontal and vertical inputs
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = 1f;

            // Move the character only forward
            Vector3 forwardMovement = transform.forward * (verticalInput * moveSpeed * Time.deltaTime);
            _rigidbody.MovePosition(_rigidbody.position + forwardMovement);

            // Move the character sideways within the limit
            Vector3 sidewaysMovement = transform.right * (horizontalInput * moveSpeed * Time.deltaTime);
            Vector3 newPosition = _rigidbody.position + sidewaysMovement;
            //clamp restricts value within range here, limiting range is 'sidewaysLimit'
            newPosition.x = Mathf.Clamp(newPosition.x, -sidewaysLimit, sidewaysLimit);
            
            //animation code part
            if (Input.GetKey(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                velocityZ = 1f;
            }
            
            
            //for going left animation
            var left = Input.GetKey(KeyCode.A);
            if (left)
            {
                velocityX -= 3f * Time.deltaTime;
            }
            //for decreasing left
            else if(!left &&  velocityX <= 0f )
            {
                velocityX += 3f * Time.deltaTime;
            }
            //for going right animation
            var right = Input.GetKey(KeyCode.D);
            if (right)
            {
                velocityX += 3f *Time.deltaTime ;
            }
            //for decreasing right 
            else if (!right && velocityX >= 0f)
            {
                velocityX -= 3f *Time.deltaTime ;
            }
            _animator.SetFloat("Velocity Z",1.0f); //for going forward
            _animator.SetFloat("Velocity X",velocityX);
            
            _rigidbody.MovePosition(newPosition);
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            _animator.SetFloat("Velocity X",0f);
            _animator.SetFloat("Velocity Z",0f);
            _animator.Play("Pain Gesture");
            
        }
        _animator.SetFloat("Velocity Z",velocityZ);
        _animator.SetFloat("Velocity X",velocityX);
        
        
        if (collision.gameObject.CompareTag("Finish"))
        {
            _animator.SetFloat("Velocity X",0f);
            _animator.SetFloat("Velocity Z",0f);
            isPlayerMoving = false;
            _animator.Play("Victory"); 
        }
        
    }
        
    }
