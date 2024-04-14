using Cysharp.Threading.Tasks;
using ShootingGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootingGame
{
    public class MouseFollower : MonoBehaviour
    {
        [SerializeField]
        private Canvas canvas;

        [SerializeField]
        private UIInventoryItem item;

        public async void Awake()
        {
            await UniTask.WaitForSeconds(1);
            GameObject cur = gameObject;
            GameObject parentGameObject = null;

            while (cur.transform.parent != null)
            {
                parentGameObject = cur.transform.parent.gameObject;
                if (cur.transform.parent.gameObject.TryGetComponent<Canvas>(out canvas))
                {
                    break;
                }
                else
                {
                    cur = parentGameObject;
                }
            }
            item = GetComponentInChildren<UIInventoryItem>();
        }

        public void SetData(ItemInventory itemInventory)
        {
            item.SetData(itemInventory);
        }
        void Update()
        {
            if(canvas != null)
            {
                Vector2 position;
                RectTransformUtility.ScreenPointToLocalPointInRectangle((RectTransform)canvas.transform,Input.mousePosition,canvas.worldCamera,
                    out position
                        );
                transform.position = canvas.transform.TransformPoint(position);
            }
        }
        public void Toggle(bool val)
        {
            gameObject.SetActive(val);
        }
    }
}