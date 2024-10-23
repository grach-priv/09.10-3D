using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private Rigidbody m_Rb;

    private void Start()
    {
        m_Rb = GetComponent<Rigidbody>();
        StartCoroutine( VelocityLoop() );
    }

    IEnumerator VelocityLoop()
    {
        while( true )
        {
            yield return new WaitForSeconds( 5 );
            m_Rb.velocity = new Vector3( 100, 100, 100 );
        }
    }
}
