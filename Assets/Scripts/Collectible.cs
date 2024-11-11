using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{

    public ScoreManager ScoreManagerRef;
    // Start is called before the first frame update
    void Start()
    {
        ScoreManagerRef = FindObjectOfType<ScoreManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var Cube = other.gameObject.GetComponent<CubeMove>();
        var Ball = other.gameObject.GetComponent<MoveBall>();
        if(Cube != null)
        {
            ScoreManagerRef.Increment();
            Destroy(this.gameObject);
        }else{
            
        if(Ball != null)
        {
            ScoreManagerRef.Increment();
            Destroy(this.gameObject);
        }}
    }

   
}

        