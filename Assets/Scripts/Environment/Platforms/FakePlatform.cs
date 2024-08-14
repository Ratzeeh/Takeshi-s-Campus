using System.Collections;
using UnityEngine;

public class FakePlatform : MonoBehaviour, IAmToggleable
{
    [SerializeField]
    private Collider _triggerCollider;
    [SerializeField]
    private float _deactivationTime = 1.0f;

    [field: SerializeField]
    public bool IsActive { get; protected set; }

    private void Start()
    {
        _triggerCollider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player") && this.IsActive)
            StartCoroutine(DeactivatePlatform());
    }

    private IEnumerator DeactivatePlatform()
    {
        yield return new WaitForSeconds(_deactivationTime);
        this.enabled = false;
    }

    public void SetToggleState(bool toggle)
    {
        _triggerCollider.enabled = toggle;
        this.IsActive = toggle;
    }
}
