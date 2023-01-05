using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JoystickController : MonoBehaviour
{
    private Image circle;
    private float range;
    private Player player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        circle = transform.GetChild(0).gameObject.GetComponent<Image>();
        range = circle.rectTransform.rect.width/2;
        EventTrigger trigger = GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerDown;
        entry.callback.AddListener((data) => Move());
        trigger.triggers.Add(entry);
    }
    private void Move()
    {
        StartCoroutine("MoveCoroutine");
    }
    IEnumerator MoveCoroutine()
    {
        while (Input.GetMouseButton(0))
        {
            Vector3 MousePos = Input.mousePosition;
            Vector3 offset = MousePos - transform.position;
            if (offset.magnitude > range)
                offset = range * offset.normalized;
            circle.transform.position = transform.position + offset;
            player.currentDirection = offset.normalized;
            player.OnMove = true;
            yield return null;
        }
        player.currentDirection = Vector3.zero;
        player.OnMove = false;
        circle.transform.localPosition = Vector3.zero;
        
    }
}
