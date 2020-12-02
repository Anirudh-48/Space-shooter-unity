
using System.Collections;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed=3.0f;
    private player _player;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("player").GetComponent<player>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * _speed);
        float randomx = Random.Range(-5.0f, 5.0f);
        if(transform.position.y<-5.0f)
        {
            transform.position = new Vector3(randomx, 7, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Player")
        {
            player player1 = other.transform.GetComponent<player>();
            if(player1!=null)
            {
                player1.damage();
            }
            Destroy(this.gameObject);
        }
        if(other.tag=="laser")
        {
            if(_player!=null)
            {
                _player.AddScore();
            }
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
