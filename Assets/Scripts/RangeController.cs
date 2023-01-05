using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeController : MonoBehaviour
{
    private GameObject playerObject;
    private Player player;
    public NPC target = null;
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        player = playerObject.GetComponent<Player>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        var character = collision.GetComponent<NPC>();
        if(character != null)
        {
            if(player.transform.localScale.x*(character.transform.position.x-player.transform.position.x)>0)
            {
                if (target == null || Vector3.Distance(player.transform.position, character.transform.position) < Vector3.Distance(player.transform.position, target.transform.position))
                    target = character;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        var character = collision.GetComponent<NPC>();
        if (character != null)
        {
            if (character == target)
            {
                target = null;
            }
        }
    }
}
