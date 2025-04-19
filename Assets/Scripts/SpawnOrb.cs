using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOrb : MonoBehaviour
{
    public GameObject orb;
    public GameObject boom;
    private bool isAlive = true;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        while (isAlive)
        {
            float y = Random.Range(-4.5f, 4.5f);    //�����̃����_��
            int direction = Random.Range(0, 2);     //0��1���̃����_��

            if (direction == 0)
            {   //�E����o��
                orb.transform.position = new Vector3(3.0f, y, 0);
            }
            else
            {   //������o��
                orb.transform.position = new Vector3(-3.0f, y, 0);
            }

            Instantiate(orb);
            yield return new WaitForSeconds(1.0f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Player"))
        {
            GameObject effect = Instantiate(boom, 
                collision.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(effect, 3);
            isAlive = false;
        }
    }

    void Update()
    {
        
    }
}
