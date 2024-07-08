using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class OnPrefab : MonoBehaviour
{
    private GameObject target;
    public GameObject Constraint;
    public GameObject Rig;
    public float Radius = 0.2f;
    
    void Awake()
    {
        target = GameObject.FindWithTag("Target");

        if(target == null)
        {
            Debug.Log("Target not found.");
        }
        else
        {
            Constraint.GetComponent<ChainIKConstraint>().data.target = target.transform;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Target")
        {
            Rig.GetComponent<Rig>().weight = Radius;
            this.GetComponent<AudioSource>().Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Target")
        {
            Rig.GetComponent<Rig>().weight = 0;
        }
    }

}
