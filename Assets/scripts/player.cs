using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float _speed = 3.5f;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _triplePrefab;
    [SerializeField]
    private GameObject _shield;
     private float _rate = 0.5f;
    [SerializeField]
    private float _can_fire = -1f;
    [SerializeField]
    private int _score;
    [SerializeField]
    private int _lives = 3;
    private float mul = 2.0f;
    private bool _activate_triple=false;
    private bool speed_b = false;
    private bool _activeshield = false;
    private spawn_manager sp;
    private UI_Manager _ui;
    void Start()
    {
        transform.position=new Vector3(0,0,0);
        sp = GameObject.Find("spawn_manager").GetComponent<spawn_manager>();
        _ui = GameObject.Find("Canvas").GetComponent<UI_Manager>();
        if(sp==null)
        {
            Debug.LogError("Spawn manager is null");
        }
        if(_ui==null)
        {
            Debug.LogError("UI manager is null");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Calcpos();
        if(Input.GetKeyDown(KeyCode.Space) && Time.time>_can_fire)
        {
            fire();
            
        }
    }
    void Calcpos()
    {
        float horizontalinput = Input.GetAxis("Horizontal");
        float verticalinput = Input.GetAxis("Vertical");
        if (speed_b == true)
        {
            transform.Translate(Vector3.right * horizontalinput * (_speed * mul) * Time.deltaTime);
            transform.Translate(Vector3.up * verticalinput * (_speed * mul) * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.right * horizontalinput * _speed * Time.deltaTime);
            transform.Translate(Vector3.up * verticalinput * _speed * Time.deltaTime);
        }
        if (transform.position.y >= 3.8f)
        {
            transform.position = (new Vector3(transform.position.x, 3.8f, 0));
        }
        else if (transform.position.y <= -3.8f)
        {
            transform.position = (new Vector3(transform.position.x, -3.8f, 0));
        }
        if (transform.position.x > 11.3f)
        {
            transform.position = new Vector3(-11.3f, transform.position.y, 0);
        }
        else if (transform.position.x < -11.3f)
        {
            transform.position = new Vector3(11.3f, transform.position.y, 0);
        }
    }
    void fire()
    {
        _can_fire = Time.time + _rate;
        if(_activate_triple==true)
        {
            Instantiate(_triplePrefab, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(_laserPrefab, transform.position + new Vector3(0, 1.05f, 0), Quaternion.identity);
        }
    }
    public void damage()
    {
        if(_activeshield==true)
        {
            _shield.SetActive(false);
            _activeshield = false;
            return;
            
        }
        _lives--;
        _ui.UpdateLives(_lives);

        if (_lives<1)
        {
            sp.ondeath();
            Destroy(gameObject);
        }
    }
    public void Triple()
    {
        _activate_triple = true;
        StartCoroutine(triple_shot());
    }

    public void Speed()
    {
        speed_b = true;
        StartCoroutine(speed_boost());
    }

    public void Shield()
    {
        _activeshield = true;
        _shield.SetActive(true);
        StartCoroutine(shield());
    }
    IEnumerator triple_shot()
    {
        yield return new WaitForSeconds(5.0f);
        _activate_triple = false;
    }
    IEnumerator speed_boost()
    {
        yield return new WaitForSeconds(5.0f);
        speed_b = false;
    }
    IEnumerator shield()
    {
        yield return new WaitForSeconds(5.0f);
        _activeshield = false;
    }
    public void AddScore()
    {
        _score += 100;
        _ui.UpdateScore(_score);
    }
   
}
