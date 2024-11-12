using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.InputSystem;
using UnityEngine;

public class MissionCoin : MonoBehaviour
{
    [SerializeField] private int speed;

    [SerializeField] private Vector3 startPosition;


    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        transform.Rotate(50 * Time.deltaTime,0 , 0);

        float newY = startPosition.y + Mathf.Sin(Time.time * speed) * 0.1f;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UImanger.Instance.CoinCount();
           this.gameObject.SetActive(false);
        }
    }
}
