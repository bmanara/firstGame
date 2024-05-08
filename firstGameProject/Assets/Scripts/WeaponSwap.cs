using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class WeaponSwap : MonoBehaviour
{
    public Transform weaponSlot;
    public GameObject activeWeapon;
    public GameObject currWeapon;

    // Start is called before the first frame update
    void Start()
    {
        var weapon = Instantiate(activeWeapon, weaponSlot.transform.position, weaponSlot.transform.rotation);
        currWeapon = weapon;
        weapon.transform.parent = weaponSlot.transform;
    }

    public void UpdateWeapon(GameObject newWeapon)
    {
        // TODO: Add a way to drop the current weapon  
        // Instantiate(activeWeapon, weaponSlot.transform.position - Vector3.down, Quaternion.identity);
        Destroy(currWeapon);
        activeWeapon = newWeapon;

        var weapon = Instantiate(activeWeapon, weaponSlot.transform.position, weaponSlot.transform.rotation);
        weapon.transform.parent = weaponSlot.transform;
    }
}
