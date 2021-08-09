using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float bulletlifeTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bulletlifeTime -= Time.deltaTime;
        if (bulletlifeTime <= 0)
        {
            Destroy(this.gameObject);
        }

    }
}
