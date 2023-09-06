using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float _spinDirection = 1;
    [SerializeField] private float _spinSpeed = 500;
    [SerializeField] private int _damage = 10;


    private const int PLAYER_WEAPON_LAYER = 8,
        ENEMY_WEAPON_LAYER = 9;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, _spinDirection * _spinSpeed * Time.deltaTime));
    }

    /// <summary>
    /// This event will be called when this object's collider touch other object's collider
    /// </summary>
    /// <param name="other">Other game object's collider</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        int otherObjLayer = other.gameObject.layer;
        if (otherObjLayer == PLAYER_WEAPON_LAYER || otherObjLayer == ENEMY_WEAPON_LAYER)
        {
            // Handle when collide with other weapon
            // Switch spin direction
            _spinDirection *= -1;
            return;
        }

        // Find character's status
        var status = other.gameObject.GetComponent<CharacterStatus>();
        if (status != null)
            status.hp -= _damage;
    }
}
