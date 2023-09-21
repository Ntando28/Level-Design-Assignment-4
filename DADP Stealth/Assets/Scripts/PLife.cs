using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PLife : MonoBehaviour
{

    public int Health;

    // Start is called before the first frame update
    void Start()
    {
        Health = 20;
    }

    // Update is called once per frame
    void Update()
    {
        if (Health == 0)
        {
            SceneManager.LoadScene("room");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Health = -2;
        }
    }
}
