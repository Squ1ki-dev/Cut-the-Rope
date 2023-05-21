using System;
using UnityEngine;

public class Candy : MonoBehaviour
{
    public static Candy Instance;
    public Action<Transform> onEnter;
    private void OnCollisionEnter2D(Collision2D other) => onEnter?.Invoke(other.transform);
}
