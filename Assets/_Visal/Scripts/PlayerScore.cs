using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public static int kills { get; set; }

    private void Start()
    {
        kills = 0;
    }
}