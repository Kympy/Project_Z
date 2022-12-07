using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    private static object _lock = new object();
    private static PlayerHandler instance;
    public static PlayerHandler Instance
    {
        get
        {
            lock (_lock)
            {
                if (instance == null)
                {
                    instance = GameObject.FindObjectOfType<PlayerHandler>();
                }
            }
            return instance;
        }
    }
    public Character myPlayer { get; private set; } = null;
    private void Awake()
    {
        instance = this;
        myPlayer ??= GameObject.FindObjectOfType<Character>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchWeapon(WeaponMode.Bow);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchWeapon(WeaponMode.Normal);
        }

        if (weaponMode == WeaponMode.Bow)
        {
            if (Input.GetMouseButtonDown(0))
            {
                IsAim = true;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                IsAim = false;
            }
        }
    }
    private void OnDestroy()
    {
        if (instance != null)
        {
            instance = null;
        }
    }
    public enum WeaponMode
    {
        Normal,
        Bow,
    }
    public WeaponMode weaponMode { get; private set; }
    public bool IsAim { get; private set; }

    public void SwitchWeapon(WeaponMode weapon)
    {
        weaponMode = weapon;
    }

    public float playerSpeed { get; private set; } = 6f;
    public float rotateSpeed { get; private set; } = 6f;

    public int HP = 100;
}
