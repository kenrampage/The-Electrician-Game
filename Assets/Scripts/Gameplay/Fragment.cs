using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fragment : MonoBehaviour
{
    private MeshRenderer mesh;
    private Rigidbody rb;

    // public float directionRangeMin;
    // public float directionRangeMax;

    // public float velocityRangeMin;
    // public float velocityRangeMax;

    // public float despawnTimerMin;
    // public float despawnTimerMax;
    private string beforeMask = "Smashable";
    private string afterMask = "Fixable";

    private string smasherTag = "Smasher";
    private string fixerTag = "Fixer";

    private void Awake()
    {
        mesh = GetComponent<MeshRenderer>();
    }

    // private void OnEnable()
    // {
    //     rb = GetComponent<Rigidbody>();
    // }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == smasherTag)
        {
            // rb.AddForce(CalcRandomDirection() * CalcRandomVelocity(), ForceMode.Impulse);
            // StartCoroutine(Despawn());
            // print(gameObject.name + " Destroyed");
            gameObject.layer = LayerMask.NameToLayer(afterMask);
            mesh.enabled = false;
        }
        else if (other.tag == fixerTag)
        {
            gameObject.layer = LayerMask.NameToLayer(beforeMask);
            // print(gameObject.name + " Repaired");
            mesh.enabled = true;
        }

    }

    // private Vector3 CalcRandomDirection()
    // {
    //     return new Vector3(Random.Range(directionRangeMin, directionRangeMax), Random.Range(directionRangeMin, directionRangeMax), Random.Range(directionRangeMin, directionRangeMax));
    // }

    // private float CalcRandomVelocity()
    // {
    //     return Random.Range(velocityRangeMin, velocityRangeMax);
    // }

    // private float CalcDespawnTimer()
    // {
    //     return Random.Range(despawnTimerMin, despawnTimerMax);
    // }

    // private IEnumerator Despawn()
    // {
    //     yield return new WaitForSecondsRealtime(CalcDespawnTimer());
    //     Destroy(this.gameObject);
    // }


}
