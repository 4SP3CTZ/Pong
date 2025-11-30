using UnityEngine;

public enum PowerUpType
{
    ChangeDirection,
    DoublePoints,
    SpeedUp
}

public class PowerUp : MonoBehaviour
{
    public PowerUpType type;
}