using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicdoll : MonoBehaviour
{
    // Start is called before the first frame update

    //public AudioClip eaten;
    //AudioSource audiosource;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Destroy(gameObject);
            //audiosource.PlayOneShot(eaten);
        }
    }

    public void destroyself()
    {
        Destroy(gameObject);
        //audiosource.Play();
    }

}
