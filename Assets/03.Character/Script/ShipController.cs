using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using Unity.VisualScripting;

namespace CropTogether
{
    public class ShipController : NetworkBehaviour
    {
        public Vector2 targetPosition;

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
        }

        private void FixedUpdate()
        {
            MoveTo();
        }

        private void MoveTo()
        {
            if (!isLocalPlayer)
            {
                return;
            }

            // transform.position = Vector2.Lerp(transform.position, targetPosition, Time.deltaTime * 10);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, 0.1f);
        }
    }
}