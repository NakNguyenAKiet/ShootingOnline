using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace ShootingGame
{
    public class RootModenScene : MonoBehaviour
    {
        private async void Awake()
        {
            await WaitForUIFrame();
            UIFrameManager.Instance.uIFrame.ShowPanel(ScreenIds.UILobby);
        }
        private async Task WaitForUIFrame()
        {
            await UniTask.WaitUntil(() =>UIFrameManager.Instance != null);
            await UniTask.WaitUntil(() => UIFrameManager.Instance.HasScreenId(ScreenIds.UILobby));
        }
    }
}