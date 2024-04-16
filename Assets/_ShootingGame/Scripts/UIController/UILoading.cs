using Cysharp.Threading.Tasks;
using deVoid.UIFramework;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ShootingGame {
    public class UILoading : APanelController
    {
        public Image image;
        public float rotationSpeed = 50f;

        async void Start()
        {
            await UniTask.WaitForSeconds(2f);
            Hide();
        }
        private void Update()
        {
            float currentRotation = image.rectTransform.localEulerAngles.z;

            float newRotation = currentRotation + (rotationSpeed * Time.deltaTime);

            image.rectTransform.localEulerAngles = new Vector3(0f, 0f, newRotation);
        }
    }
}