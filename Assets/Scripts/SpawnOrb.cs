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
            float y = Random.Range(-4.5f, 4.5f);    //高さのランダム
            int direction = Random.Range(0, 2);     //0か1かのランダム

            if (direction == 0)
            {   //右から出現
                orb.transform.position = new Vector3(3.0f, y, 0);
            }
            else
            {   //左から出現
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
}
