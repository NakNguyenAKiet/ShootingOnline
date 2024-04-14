using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Play_UNI_VFX : MonoBehaviour
{
    [SerializeField] VisualEffect VFX;
    private void Start()
    {
        VFX.SendEvent("create");
    }
    private void OnTriggerEnter(Collider other)
    {
        VisualEffect hit = Instantiate(VFX, transform.position, Quaternion.identity);
        hit.SendEvent("hit");
    }
}
