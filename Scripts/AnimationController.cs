using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Transform Target;
    public GameObject Plane;

    private Vector3 mousePosition;
    private Vector3 worldPosition;
    private Vector3 ObjScreenPos;
    private Vector3 TargetPos;

    private void Start()
    {
        ObjScreenPos = Camera.main.WorldToScreenPoint(Plane.transform.position);
    }

    void Update()
    {
        mousePosition = Input.mousePosition;
        mousePosition.z = ObjScreenPos.z;
        worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        TargetPos = new Vector3(worldPosition.x,0,worldPosition.z);

        Target.transform.position = TargetPos;

    }
}
