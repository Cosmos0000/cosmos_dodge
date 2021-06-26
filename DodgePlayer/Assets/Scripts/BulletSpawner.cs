using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float spawnRateMin = 0.5f;
    public float spawnRateMax = 0.5f;

    private Transform target;
    private float spawnRate;
    private float timerAfterSpawn;

    public int hp = 100;
    public HPBar hpbar;
    public GameObject level;

    public bool isMoving = false; // ���� �������� �ƴϸ� �Ѿư��鼭 ���ݻ������� �Ǵ�
    private NavMeshAgent nvAgent; // �׺���̼��� ���� ����
    Animator animator; // �ִϸ��̼� ó���� ���� ����

    public AudioClip fireClip; // ��ź �߻� ���� Ŭ��
    AudioSource fireAudio; // ������ҽ� ������Ʈ

    // Start is called before the first frame update
    void Start()
    {
        timerAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        target = FindObjectOfType<PlayerController>().transform;
        StartCoroutine(MonsterAI());
        nvAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        fireAudio = GetComponent<AudioSource>();
    }
  
    // Update is called once per frame
    void Update()
    {
        if( hp<=0)
        {
            return;
        }

        timerAfterSpawn += Time.deltaTime;

        if(timerAfterSpawn >= spawnRate)
        {
            timerAfterSpawn = 0;
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.transform.LookAt(target);

            transform.LookAt(target);

            spawnRate = Random.Range(spawnRateMin, spawnRateMax);

            fireAudio.PlayOneShot(fireClip);
        }
    }

    IEnumerator MonsterAI()
    {
        while(hp > 0)
        {
            yield return new WaitForSeconds(0.2f);

            if(isMoving)
            {
                nvAgent.destination = target.position;
                nvAgent.isStopped = false;
                animator.SetBool("isMoving", true);
            }
            else
            {
                nvAgent.isStopped = true;
                animator.SetBool("isMoving", false);
            }
        }
    }

    public void GetDamage(int damage)
    {
        hp -= damage;
        hpbar.SetHP(hp);
        Debug.Log("BulletSpawner:" + hp);

        if (hp <= 0)
        {
            animator.SetTrigger("Die");
            GameManager2 gamemanager = FindObjectOfType<GameManager2>();
            gamemanager.DieBulletSpawner(gameObject);
            Destroy(gameObject, 5f); // 5�� �ڿ� ����
        }
    }
}
