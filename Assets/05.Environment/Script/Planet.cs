using System;
using System.Collections;
using System.Collections.Generic;
using CropTogether.Input;
using Mirror;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;


namespace CropTogether
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(Collider2D))]
    public class Planet : MonoBehaviour
    {
        private static bool _isInit;
        private static InputAction _rightClickAction;

        private void Awake()
        {
            if (!_isInit)
            {
                _rightClickAction = GamerInput.Controls.UI.RightClick;
                _rightClickAction.performed += OnRightClick;
            }
        }

        private static void OnRightClick(InputAction.CallbackContext context)
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
                if (hit.collider != null &&
                    hit.collider.gameObject.TryGetComponent(typeof(Planet), out Component planet))
                {
                    // ShowContextMenu(mousePosition);
                    Debug.Log("点到了");
                    Fun1(planet.transform.position);
                }
                // else if (currentMenu != null)
                // {
                //     Destroy(currentMenu);
                // }
            }
        }

        private static void Fun1(Vector2 position)
        {
            GameObject localPlayer = NetworkClient.localPlayer?.gameObject;
            if (localPlayer != null)
            {
                localPlayer.GetComponent<ShipController>().targetPosition = position;
            }
        }
    }
}