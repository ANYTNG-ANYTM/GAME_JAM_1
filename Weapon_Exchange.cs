using UnityEngine;

public class Weapon_Exchange : MonoBehaviour
{
    public Transform weaponHolder;
    public float pickupRadius = 10f;
    public string playerTag = "Player";
    public string weaponTag = "Weapon";
    public string currentWeaponTag = "Current_Weapon";
    private GameObject player;
    private GameObject weapon;
    private GameObject currentWeapon;
    private Collider2D col;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        currentWeapon = GameObject.FindWithTag(currentWeaponTag);
    }

    void FixedUpdate()
    {
        GameObject[] weapons = GameObject.FindGameObjectsWithTag(weaponTag);
        foreach (GameObject weapon in weapons)
        {
            float distance_player = Vector2.Distance(player.transform.position, weapon.transform.position);
            if (Input.GetKeyDown(KeyCode.RightShift) || Input.GetKeyDown(KeyCode.LeftShift))
            {
                if (distance_player <= pickupRadius)
                {
                    DropCurrentWeapon();
                    PickUpWeapon(weapon);
                }
            }
        }
    }

    void PickUpWeapon(GameObject weapon)
    {
        // Set the picked up weapon as the current weapon
        currentWeapon = weapon;
        currentWeapon.tag = currentWeaponTag;

        // Set the weapon's parent to the weapon holder and reset its position and rotation
        currentWeapon.transform.SetParent(weaponHolder);
        currentWeapon.transform.localPosition = Vector2.zero; // Reset position
        currentWeapon.transform.localRotation = Quaternion.identity; // Reset rotation

        // Disable physics interactions by setting the Rigidbody2D as kinematic and making the collider a trigger
        Rigidbody2D weaponRb = currentWeapon.GetComponent<Rigidbody2D>();
        if (weaponRb != null)
        {
            weaponRb.isKinematic = true; // Set kinematic to true
        }

        Collider2D col = currentWeapon.GetComponent<Collider2D>();
        if (col != null)
        {
            col.isTrigger = true; // Set collider as trigger
        }

        // Enable the Gun script when picked up
        Weapon gunScript = currentWeapon.GetComponent<Weapon>();
        if (gunScript != null)
        {
            gunScript.enabled = true;
        }
    }

    void DropCurrentWeapon()
    {
        // Remove the weapon from its parent and apply physics properties
        currentWeapon.transform.SetParent(null);

        Rigidbody2D weaponRb = currentWeapon.GetComponent<Rigidbody2D>();
        if (weaponRb == null)
        {
            weaponRb = currentWeapon.AddComponent<Rigidbody2D>();
        }
        col = currentWeapon.GetComponent<Collider2D>();
        if (weaponRb != null)
        {
            col.isTrigger = false;
            weaponRb.AddForce(transform.right * 5f, ForceMode2D.Impulse); // Apply a small force to drop it to the right
        }

        // Disable the Weapon script when dropped
        Weapon gunScript = currentWeapon.GetComponent<Weapon>();
        if (gunScript != null)
        {
            gunScript.enabled = false;
        }

        // Reset the tag to the original weapon tag
        currentWeapon.tag = weaponTag;
    }
}