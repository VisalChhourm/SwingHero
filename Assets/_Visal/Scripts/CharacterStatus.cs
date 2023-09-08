using UnityEngine;
using UnityEngine.UI;

public class CharacterStatus : MonoBehaviour
{
    [SerializeField] private int _baseHP = 100;
    [SerializeField] private Slider _hpBar = null;

    /// <summary>
    /// Current HP of this character
    /// </summary>
    public int hp { get; set; }

    /// <summary>
    /// Awake is call only once at the very begining of this game object's life cycle
    /// </summary>
    private void Awake()
    {
        hp = _baseHP;
        _hpBar.maxValue = hp;
    }

    /// <summary>
    /// Update is call every frame
    /// </summary>
    private void Update()
    {
        _hpBar.value = hp;
        if (hp <= 0)
        {
            // Destroy itself when its HP hit zero
            if (gameObject.layer == GameObjectLayers.ENEMY)
            {
                PlayerScore.kills++;
            }
            Destroy(gameObject);
        }
    }
}
