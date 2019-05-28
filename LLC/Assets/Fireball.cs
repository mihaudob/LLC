using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 10;
    public int damage = 50;
    public List<string> tagsToIgnore;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(this.transform.localScale.x, 0, 0) * Time.deltaTime * speed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            enemy.DamageEnemy(damage);
        }
        if (tagsToIgnore.Contains(other.tag))
        {
            return;
        } else
        {
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
