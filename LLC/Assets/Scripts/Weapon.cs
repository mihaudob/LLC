using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float hitRate = 0;
    public int Damage = 50;
    public LayerMask whatToHit;

    Player player;

    float timeToHit = 1;
    Transform hitPoint;

    //Use this for initialization

    private void Awake()
    {
        hitPoint = transform.FindChild("HitPoint");
        if (hitPoint == null)
        {
            Debug.LogError("No hitPoint");
        }

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hitRate == 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                player.gameObject.GetComponent<Animator>().Play("Attack");
                Hit();
            }
        }
        else
        {
            if (Input.GetButton ("Fire1") && Time.time > timeToHit)
            {
                timeToHit = Time.time + 1 / hitRate;
                Hit();
            }
        }
    }

    void Hit()
    {
        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 hitPointPosition = new Vector2(hitPoint.position.x, hitPoint.position.y);
        RaycastHit2D hit = Physics2D.Raycast(hitPointPosition, mousePosition - hitPointPosition, 1, whatToHit);
        Debug.DrawLine(hitPointPosition, (mousePosition - hitPointPosition) * 1, Color.cyan);
        if (hit.collider != null)
        {
            Debug.DrawLine(hitPointPosition, hit.point, Color.red);
            Debug.Log("We hit " + hit.collider.name + " and did " + Damage + " damage.");
            Enemy enemy = hit.collider.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.DamageEnemy(Damage);
            }
        }
    }
}
