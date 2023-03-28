using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEventHandler : MonoBehaviour
{
    // This script is a basic example of setting up and using C# events
    public static int damageToPlayer;
    public delegate void PlayerDamage(int damage);
    public static event PlayerDamage playerDamaged;

    public delegate void PlayerMoving();
    public static event PlayerMoving playerMoved;

    public delegate void PlayerShooting();
    public static event PlayerShooting playerShot;

    public static void PlayerDamaged(int damage)
    {
        playerDamaged?.Invoke(damage);
        //Debug.Log("Damage player event Triggered");
    }
    public static void PlayerMoved()
    {
        playerMoved?.Invoke();
        //Debug.Log("Player moved event triggered");
    }
    public static void PlayerShot()
    {
        playerShot?.Invoke();
        //Debug.Log("player shot event Triggered");
    }
}
