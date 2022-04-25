using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "Data/AddPlayerStats", order = 1)]
public class AddPlayerStats : ScriptableObject
{
    public float hp = 0;
    public float dashCD = 0;
    public float dashSpeed = 0;
    public float  shootSpeed = 0;
    public float bulletDamage = 0;
    public int numberOfBullets = 0;
    public bool upgradeRadius = false; 
}
