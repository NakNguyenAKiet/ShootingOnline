using Cinemachine;
using deVoid.Utils;
using StarterAssets;
using System.Collections.Generic;
using System.Security.Claims;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.InputSystem;
using UnityEngine.VFX;
using static UnityEditor.Progress;

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
        [SerializeField] private Transform _spellCasting;
        [SerializeField] private VisualEffect HitVFX;
        [SerializeField] private VisualEffect FlameVFX;
        [SerializeField] private PoolsHelper _bulletPool;
        [SerializeField] private float _energy;
        [SerializeField] private float _curWeponEnergy = 1;
        [SerializeField] private Projectile _spell1Prefab;
        [SerializeField] private float _spell1Energy = 5;

        public Vector3 MouseWorldPos = Vector3.zero;
        private Vector3 _aimTargetPos;
        private Vector3 _aimDir;
        private Vector2 _centerScreen;
        private Ray _ray;

        private string _idAim = "Aim";
        private float _aimRigWeight = 0;

        public float MaxEnergy = 8;

        private void Awake()
        {
            _starterAssetsInputs = GetComponent<StarterAssetsInputs>();
            _thirdPersonController = GetComponent<ThirdPersonController>();
            _animator = GetComponent<Animator>();
            _centerScreen = new Vector2(Screen.width / 2, Screen.height / 2);

            _energy = MaxEnergy;
        }

        private void Update()
        {
            GetMouseWorldPos();

            HandleAim();

            ShootingCheck();

            if (_energy <= MaxEnergy)
            {
                _energy += Time.deltaTime;
            }

            Signals.Get<UpdateEnergy>().Dispatch(_energy);
        }

        private void ShootingCheck()
        {
            if (_starterAssetsInputs.shoot && _energy >= _curWeponEnergy)
            {
                _energy -= _curWeponEnergy;
                Vector3 _bulletDir = (MouseWorldPos - _bulletSpawner.position).normalized;
                _bulletPool.SpawnObjectByDirection(_bulletSpawner, Quaternion.LookRotation(_bulletDir));

                VisualEffect Vfx = Instantiate(HitVFX, MouseWorldPos, Quaternion.identity);

                FlameVFX.Play();
                _starterAssetsInputs.shoot = false;
            }

            if (_starterAssetsInputs.castSpell_1 && _energy >= _spell1Energy)
            {
                _animator.SetTrigger("Spell1");
                _starterAssetsInputs.castSpell_1 = false;
                _energy -= _spell1Energy;
                Vector3 _bulletDir2 = (MouseWorldPos - _bulletSpawner.position).normalized;
                Projectile spell =  Instantiate(_spell1Prefab);
                spell.SetDestination(_bulletSpawner.position, _bulletDir2);
            }
        }
        private void GetMouseWorldPos()
        {
            _ray = Camera.main.ScreenPointToRay(_centerScreen);
            if (Physics.Raycast(_ray, out RaycastHit hitInfo, 999f, _aimLayerMask))
            {
                MouseWorldPos = hitInfo.point;
                targetTransform.position = MouseWorldPos;
            }
        }

        private void HandleAim()
        {
            _aimCamera.gameObject.SetActive(_starterAssetsInputs.aim);
            _animator.SetBool(_idAim, _starterAssetsInputs.aim);
            if (_starterAssetsInputs.aim)
            {
                _thirdPersonController.SetSensitivity(_aimSensitivity);
                _thirdPersonController.SetRotateOnMove(false);
                //look to aim
                _aimTargetPos = MouseWorldPos;
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
            _aimRig.weight = Mathf.Lerp(_aimRig.weight, _aimRigWeight, Time.deltaTime * 20f);
        }
    }
}
