using System;
using UnityEngine;

public class CatchableView : MonoBehaviour
{
    public Action onCatchCallback;
    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.gameObject.GetComponent<Weight>();
        if (onCatchCallback != null && player)
        {
            onCatchCallback?.Invoke();
            
            OnCatch(player);
        }
    }
    protected virtual void OnCatch(Weight player)
    {
        Destroy(gameObject);
    }
}