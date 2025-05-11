using UnityEngine;

public class Door : MonoBehaviour
{
    SpriteRenderer thisSprite;
    public Sprite closedDoor;
    public Sprite openDoor;
    void Start()
    {
        thisSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
