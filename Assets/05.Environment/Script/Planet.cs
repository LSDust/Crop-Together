using System;
using System.Collections;
using System.Collections.Generic;
using CropTogether.Input;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;


namespace CropTogether
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Planet : MonoBehaviour
    {
        private InputAction _rightClickAction;

        private void Awake()
        {
            _rightClickAction = GamerInput.Controls.UI.RightClick;
        }

        private void OnEnable()
        {
            _rightClickAction.performed += OnRightClick;
            _rightClickAction.Enable();
        }

        private void OnDisable()
        {
            _rightClickAction.performed -= OnRightClick;
            _rightClickAction.Disable();
        }

        private void OnRightClick(InputAction.CallbackContext context)
        {
            // 检查是否点击了UI元素
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }

            // 将鼠标位置转换为世界坐标
            Vector2 mousePosition = Mouse.current.position.ReadValue();
            if (Camera.main != null)
            {
                Ray ray = Camera.main.ScreenPointToRay(mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

                // 检查是否点击了这个Sprite
                if (hit.collider != null && hit.collider.gameObject == gameObject)
                {
                    // ShowContextMenu(mousePosition);
                    Debug.Log("点到了");
                    Fun1(transform.position);
                }
                // else if (currentMenu != null)
                // {
                //     Destroy(currentMenu);
                // }
            }
        }

        private void Fun1(Vector2 position)
        {
            GameObject[] player = GameObject.FindGameObjectsWithTag("Player");
            Debug.Log(player);
            foreach (GameObject p in player)
            {
                p.GetComponent<ShipController>().targetPosition = position;
            }
        }
    }
}