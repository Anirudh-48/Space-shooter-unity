using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triple_powerup : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;
    // Start is called before the first frame update
    [SerializeField]
    private int powerup_id;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if (transform.position.y < -4.5f)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            player _player=other.transform.GetComponent<player>();
            if(_player!=null)
            {
                switch (powerup_id)

                {
                    case 0:
                        _player.Triple();
                        break;
                    case 1:
                        _player.Speed();
                        break;
                    case 2:
                        _player.Shield();
                        break;
                }
            }
            Destroy(this.gameObject);
        }
        
    }
}
