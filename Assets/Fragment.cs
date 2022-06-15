using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fragment : MonoBehaviour
{
    private Rigidbody rb;

    public float directionRangeMin;
    public float directionRangeMax;

    public float velocityRangeMin;
    public float velocityRangeMax;

    public float despawnTimerMin;
    public float despawnTimerMax;

    public string smasherTag;

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == smasherTag)
        {
            rb.AddForce(CalcRandomDirection() * CalcRandomVelocity(), ForceMode.Impulse);
            StartCoroutine(Despawn());
        }

    }

    private Vector3 CalcRandomDirection()
    {
        return new Vector3(Random.Range(directionRangeMin, directionRangeMax), Random.Range(directionRangeMin, directionRangeMax), Random.Range(directionRangeMin, directionRangeMax));
    }

    private float CalcRandomVelocity()
    {
        return Random.Range(velocityRangeMin, velocityRangeMax);
    }

    private float CalcDespawnTimer()
    {
        return Random.Range(despawnTimerMin, despawnTimerMax);
    }

    private IEnumerator Despawn()
    {
        yield return new WaitForSecondsRealtime(CalcDespawnTimer());
        Destroy(this.gameObject);
    }


}
