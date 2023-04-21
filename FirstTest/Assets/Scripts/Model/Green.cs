using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Green : MonoBehaviour
{
    [SerializeField] private Hole holePrefab;

    // Start is called before the first frame update
    void Start()
    {
        Hole hole = Instantiate(holePrefab, this.transform.position + GetHolePos(this.GetComponent<Collider>()), Quaternion.identity);
        hole.transform.SetParent(this.transform);
    }

    private Vector3 GetHolePos(Collider collider)
    {
        float a = Random.Range(0.1f, 0.9f) * 2 * Mathf.PI;
        
        return new Vector3(
        Mathf.Sqrt(collider.transform.localScale.x) * Mathf.Sin(a), 
        1f, 
        Mathf.Sqrt(collider.transform.localScale.z) * Mathf.Cos(a) );
    }
}
