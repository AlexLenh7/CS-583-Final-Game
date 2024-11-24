using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSource : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float lifeTime; //time before pivot point self destructs naturally

    void Start()
    {

        if (gameObject)
        {
            Destroy(gameObject, lifeTime);
        }

    }

}
