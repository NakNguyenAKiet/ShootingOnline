using ShootingGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootingGame
{
    public class ItemPickUpAble : MonoBehaviour
    {
        public ItemCode ItemCode;
        public bool ShowMessageOnPickUP = true;
        public async void Picked()
        {
            if (ShowMessageOnPickUP)
            {
                await UIFrameManager.Instance.uIFrame.ShowPanel(ScreenIds.UIPopUpMessage, new UIPopUpMessageProperties {Message = DefineStrings.PickUpItemMessage});
            }
            PlayerController.Instance.SoundFXManager.PlaySoundAtPos(transform.position,SoundType.PickUpItem,1f);
            GameObject.Destroy(gameObject);
        }
    }
}
