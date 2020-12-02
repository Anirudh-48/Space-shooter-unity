using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading;
using UnityEngine;

public class laser : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float _speed = 8f;
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {   
        transform.Translate(Vector3.up * Time.deltaTime * _speed);
        if(transform.position.y>8f)
        {
            Destroy(this.gameObject);
        }
    }
}
