using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject Canvas;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Clover"))
                {
                    Destroy(hit.collider.transform.parent.gameObject);
                    Canvas.SetActive(true);
                    return;
                }
                else if (hit.collider.CompareTag("Clover0"))
                {
                    this.GetComponent<AudioSource>().Play();
                    Destroy(hit.collider.transform.parent.gameObject);
                }
            }
        }
    }
}
