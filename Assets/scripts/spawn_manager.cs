
using System.Collections;
using UnityEngine;

public class spawn_manager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject _enemyprefab;
    [SerializeField]
    private GameObject _enemycontainer;
    private bool _stopspawn = false;
    [SerializeField]
    private GameObject[] powerup;
    void Start()
    {
        StartCoroutine(spawn());
        StartCoroutine(spawn_manage());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator spawn()
    {
        yield return null;

        while(_stopspawn==false)
        {
            Vector3 pos = new Vector3(Random.Range(-5f, 5f), 7, 0);
           GameObject newenemy= Instantiate(_enemyprefab,pos,Quaternion.identity);
            newenemy.transform.parent = _enemycontainer.transform;
            yield return new WaitForSeconds(4.0f);
        }
    }

    IEnumerator spawn_manage()
    {
        yield return null;
        while(!_stopspawn)
        {
            Vector3 pos = new Vector3(Random.Range(-8.0f, 8.0f), 7, 0);
            int powerup_id = Random.Range(0, 3);
            Instantiate(powerup[powerup_id], pos, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(3, 8));
        }
    }
    public void ondeath()
    {
        _stopspawn = true;
    }
}
