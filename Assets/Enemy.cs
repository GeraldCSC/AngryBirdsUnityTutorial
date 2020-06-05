﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _cloudparticlePrefab;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<Bird>() != null)
        {
            Instantiate(_cloudparticlePrefab,transform.position,Quaternion.identity);
            Destroy(gameObject);
            return;
        }
        if (collision.collider.GetComponent<Enemy>() != null)
            return;
        if (collision.contacts[0].normal.y < -0.5)
        {
            Instantiate(_cloudparticlePrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            return;
        }
    }
}
