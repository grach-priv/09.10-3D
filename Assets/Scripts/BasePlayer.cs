using JetBrains.Rider.Unity.Editor;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class BasePlayer : MonoBehaviour
{
    [SerializeField] private float m_flSpeed;
    [SerializeField] private float m_flSensitivity;
    [SerializeField] private Camera m_Camera;

    private Rigidbody m_Rb;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        m_Rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector3 vecVelocity = Vector3.zero;

#if FALSE
        vecVelocity.z = ( Input.GetAxisRaw("Vertical") * m_Camera.transform.forward ) * m_flSpeed;
        vecVelocity.x = Input.GetAxisRaw("Horizontal") * m_flSpeed;
#else
        vecVelocity = m_Camera.transform.forward * Input.GetAxisRaw( "Vertical" ) + m_Camera.transform.right * Input.GetAxisRaw( "Horizontal" );
        vecVelocity.z *= m_flSpeed;
        vecVelocity.x *= m_flSpeed;
#endif
        m_Rb.velocity = vecVelocity;
         
        float flMx = ( Input.GetAxis( "Mouse X" ) * m_flSensitivity );

        //m_Rb.transform.Rotate(0, flMx, 0);
        m_Camera.transform.Rotate(0, flMx, 0);
    }
}
