using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoint = 5;
    [SerializeField] int difficultyRamp = 1;
    int currentHitPoint = 0;

    Enemy enemy;
    void OnEnable()
    {
        currentHitPoint = maxHitPoint; // �ִ� ü��
    }
    void Start()
    {
        enemy = GetComponent<Enemy>();
    }
    private void OnParticleCollision(GameObject other)
    {
        processHit(); // ���� ��
    }
    void processHit()
    {
        currentHitPoint--; 
        if(currentHitPoint<=0)
        {
            gameObject.SetActive(false);
            maxHitPoint += difficultyRamp;
            enemy.RewardMoney();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
