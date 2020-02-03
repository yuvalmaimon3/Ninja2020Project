using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeColider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            var player_hp = other.GetComponent<Health>();
            player_hp.Damage(-50);
        }
    }
}
