using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballCaster : MonoBehaviour
{
    [Range(0.1f, 10f)]
    public float fireRate = 1.305f;
    public int Damage = 50;
    public LayerMask whatToHit;
    public KeyCode specialMove;

    public Transform fireballPrefab;
    public float spawnDelay = 0.5f;

    Player player;
    private Animator anim;

    float timeToHit = 1;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(specialMove) && Time.time > timeToHit)
        {
            timeToHit = Time.time + 1 / fireRate;
            StartCoroutine(CreateFireball());
        }
    }

    public IEnumerator CreateFireball()
    {
        anim.SetBool("Attacking", true);
        yield return new WaitForSeconds(spawnDelay);
        Transform target = GetComponentInParent<Transform>();
        Vector3 pos = target.position;
        Quaternion rotation = target.rotation;
        Vector3 scale = target.localScale;
        Transform fireBall = Instantiate(fireballPrefab, pos, rotation);
        fireBall.localScale = target.localScale;
        anim.SetBool("Attacking", false);
    }
}


/*

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

*/
