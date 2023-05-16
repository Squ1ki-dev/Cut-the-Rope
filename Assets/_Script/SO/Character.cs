using UnityEngine;

[CreateAssetMenu(fileName = "Character",menuName = "GameObjects/Character")]
public class Character : ScriptableObject
{
    [SerializeField] private Sprite _picture;
    [SerializeField] private Sprite _silhouette;
    [SerializeField] private string _name;

    public Sprite Picture() => _picture;
    public Sprite Silhouette() => _silhouette;
    public string Name() => _name;
}
