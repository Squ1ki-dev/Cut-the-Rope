using System;
using UnityEngine;


public class CatchableView : MonoBehaviour
{
    public Action onCatchCallback;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (onCatchCallback != null && other.gameObject.GetComponent<Weight>())
        {
            onCatchCallback?.Invoke();
            OnCatch();
        }
    }
    protected virtual void OnCatch()
    {
        Destroy(gameObject);
    }
}
