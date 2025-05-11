using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerGun : MonoBehaviour
{
    public SpriteRenderer thisSprite;
    public bool shotDoor = false;
    public UnityEvent shootDoor;

    public float flashDuration;
    public float fireRate;
    float nextShot;
    Image flash;

    void Start()
    {
        thisSprite = GetComponent<SpriteRenderer>();
        flash = GameObject.Find("Flash").GetComponent<Image>();
    }

    
    void Update()
    {
        thisSprite.enabled = InventoryManager.instance.armed;
        if (InventoryManager.instance.armed && Input.GetAxisRaw("Jump") != 0 && Time.time > nextShot)
            {
            StartCoroutine(MuzzleFlash());
            nextShot = Time.time + fireRate;
            if (!thisSprite.flipX && !shotDoor)
                {
                shotDoor = true;
                shootDoor.Invoke();
                }
            }
    }
    IEnumerator MuzzleFlash()
        {
        flash.enabled = true;
        yield return new WaitForSeconds(flashDuration);
        flash.enabled = false;
        }
}
