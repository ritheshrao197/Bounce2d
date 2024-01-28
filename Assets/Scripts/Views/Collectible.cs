using Bounce.DataLayer;
using Bounce.MediatorLayer;
using Bounce.Utilities;
using Bounce.ViewLayer;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Collectible : BaseView
{
    private CollectibleMediator mediator;
    

   
    private Vector2 startPosition; // Initial position of the obstacle
    private bool movingRight; // Tracks direction for X-axis movement (true: right, false: left)

    public CollectibleType CollectibleType;
    public enum CollectibleState { Idle, XAxis, YAxis }
    public CollectibleState collectibleState = CollectibleState.Idle; // Default to idle

    public Axis movementAxis = Axis.X; // Choose X or Y axis for movement
    public float movementOffset = 2f; // Distance to move in chosen direction
    public float moveSpeed = 2f;

  
    private void Initialize()
    {
        mediator = new CollectibleMediator(this);
    }
    private void Start()
    {
        Initialize();
        mediator.Start();
    }

   

    void Update()
    {
        if (collectibleState == CollectibleState.XAxis)
        {
            MoveXAxis();
        }
        else if (collectibleState == CollectibleState.YAxis)
        {
            MoveYAxis();
        }
    }
    void MoveXAxis()
    {
        float targetX = startPosition.x + (movingRight ? movementOffset : -movementOffset);
        transform.position = Vector2.Lerp(transform.position, new Vector2(targetX, transform.position.y), Time.deltaTime * moveSpeed);

        if (Mathf.Abs(transform.position.x - targetX) < 0.1f) 
        {
            movingRight = !movingRight; 
        }
    }

    void MoveYAxis()
    {
        float targetY = startPosition.y + (movementOffset * (int)(movementAxis == Axis.Y ? 1 : -1)); 
        transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x, targetY), Time.deltaTime * moveSpeed);

        if (Mathf.Abs(transform.position.y - targetY) < 0.1f) 
        {
            movementAxis = (movementAxis == Axis.Y ? Axis.X : Axis.Y); 
        }
    }



    public enum Axis { X, Y }; 
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            mediator.HandleCollectible();
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
                mediator.HandleCollectible();
        }
    }
    public void OnCollected()
    {
        gameObject.SetActive(false);

    }


}
