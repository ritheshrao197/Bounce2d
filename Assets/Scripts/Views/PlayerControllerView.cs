using Bounce.Utilities;
using Bounce.ViewLayer;
using System;
using UnityEngine;
namespace Bounce
{
    public class PlayerControllerView : BaseView
    {
        public Rigidbody2D player;
        private PlayerControllerMediator mediator;

        private void Awake()
        {
            Initialize();
        }

        private void Start()
        {
            player = GetComponent<Rigidbody2D>();
            mediator.Start();
        }

        private void Update()
        {
            mediator.HandleInput();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            mediator.HandleGroundCollision(collision);
        }

        private void Initialize()
        {
            mediator = new PlayerControllerMediator(this);
        }

        internal void ResetPosition(Vector3 startPosition)
        {
            transform.position = startPosition;

        }
    }

}