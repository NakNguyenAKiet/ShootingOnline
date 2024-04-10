using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace ShootingGame
{
    public class RootModenScene : MonoBehaviour
    {
        private void Awake()
        {
        }
        private async void Start()
        {
            await UniTask.WaitUntil(() => UIFrameManager.Instance !=null);
            await UniTask.WaitUntil(() => UIFrameManager.Instance.HasScreenId(ScreenIds.UILobby));
            await UniTask.WaitUntil(() => PlayerController.Instance != null);

            await UIFrameManager.Instance.uIFrame.ShowPanel(ScreenIds.UILobby);
        }

    }
}