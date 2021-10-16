using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    Weapon leftWeapon;


    [SerializeField]
    Weapon rightWeapon;

    public Weapon LeftWeapon { get { return leftWeapon; } set { leftWeapon = value; } }

    public Weapon RightWeapon { get { return rightWeapon; } set { rightWeapon = value; } }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
