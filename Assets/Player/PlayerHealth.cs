using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float health = 200f;
    
    public void damagePlayer(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}
