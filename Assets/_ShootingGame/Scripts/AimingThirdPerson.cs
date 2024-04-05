using Cinemachine;
using StarterAssets;
using System.Collections.Generic;
using System.Security.Claims;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.InputSystem;
using UnityEngine.VFX;

namespace ShootingGame
{
    public class AimingThirdPerson : MonoBehaviour
    {
        private float _nomalSensitivity = 1;
        private float _aimSensitivity = 0.5f;

        [SerializeField] private Rig _aimRig;
        [SerializeField] private CinemachineVirtualCamera _aimCamera;
        [SerializeField] private StarterAssetsInputs _starterAssetsInputs;
        [SerializeField] private ThirdPersonController _thirdPersonController;
        [SerializeField] private Animator _animator;
        [SerializeField] private LayerMask _aimLayerMask;
        [SerializeField] private PlayerInput _playerInput;
        [SerializeField] private Transform targetTransform;
        [SerializeField] private Transform _bulletSpawner;
        [SerializeField] private VisualEffect HitVFX;
        [SerializeField] private VisualEffect FlameVFX;
        [SerializeField] private PoolsHelper _bulletPool;

        private Vector3 _mouseWorldPos = Vector3.zero;
        private Vector3 _aimTargetPos;
        private Vector3 _aimDir;
        private Vector3 _bulletDir;
        private Vector2 _centerScreen;
        private Ray _ray;

        private string _idAim = "Aim";
        private float _aimRigWeight = 0;

        private void Awake()
        {
            _starterAssetsInputs = GetComponent<StarterAssetsInputs>();
            _thirdPersonController = GetComponent<ThirdPersonController>();
            _animator = GetComponent<Animator>();
            _centerScreen = new Vector2(Screen.width / 2, Screen.height / 2);
        }

        private void Update()
        {
            _ray = Camera.main.ScreenPointToRay(_centerScreen);
            if (Physics.Raycast(_ray, out RaycastHit hitInfo, 999f, _aimLayerMask))
            {
                _mouseWorldPos = hitInfo.point;
                targetTransform.position = _mouseWorldPos;
            }

            _aimCamera.gameObject.SetActive(_starterAssetsInputs.aim);
            _animator.SetBool(_idAim, _starterAssetsInputs.aim);
            if (_starterAssetsInputs.aim)
            {
                _thirdPersonController.SetSensitivity(_aimSensitivity);
                _thirdPersonController.SetRotateOnMove(false);
                //look to aim
                _aimTargetPos = _mouseWorldPos;
                _aimTargetPos.y = transform.position.y;
                _aimDir = (_aimTargetPos - transform.position).normalized;
                transform.forward = Vector3.Lerp(transform.forward, _aimDir, Time.deltaTime * 20f);
                _aimRigWeight = 1f;
            }
            else
            {
                _aimRigWeight = 0;
                _thirdPersonController.SetSensitivity(_nomalSensitivity);
                _thirdPersonController.SetRotateOnMove(true);
            }

            if (_starterAssetsInputs.shoot)
            {
                _bulletDir = (_mouseWorldPos - _bulletSpawner.position).normalized;
                _bulletPool.SpawnObjectByDirection(_bulletSpawner, Quaternion.LookRotation(_bulletDir));
                //Instantiate(_projectilePrefab, _bulletSpawner.position, Quaternion.LookRotation(_bulletDir, Vector3.up));
                HitVFX.transform.position = _mouseWorldPos;
                HitVFX.Play();
                FlameVFX.Play();
                _starterAssetsInputs.shoot = false;
            }

            _aimRig.weight = Mathf.Lerp(_aimRig.weight, _aimRigWeight, Time.deltaTime * 20f);
        }
    }
}
