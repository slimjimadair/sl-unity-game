using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    // Variables
    public Transform weaponHold;
    public Gun startingGun;
    Gun equippedGun;

    // Start is called before the first frame update
    private void Start()
    {
        if (startingGun != null)
        {
            EquipGun(startingGun);
        }
    }

    // EquipGun function
    public void EquipGun(Gun gunToEquip)
    {
        if (equippedGun != null)
        {
            Destroy(equippedGun.gameObject);
        }
        equippedGun = Instantiate(gunToEquip, weaponHold.position, weaponHold.rotation) as Gun;
        equippedGun.transform.parent = weaponHold;
    }

    // Shoot function
    public void Shoot()
    {
        if (equippedGun != null)
        {
            equippedGun.Shoot();
        }
    }

}
