using JetBrains.Rider.Unity.Editor;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class BasePlayer : MonoBehaviour
{
    private int m_iScore = 0;

    [SerializeField] private float m_flSpeed;
    [SerializeField] private float m_flSensitivity;
    [SerializeField] private Camera m_Camera;
    [SerializeField] private TMP_Text m_ScoreText;
    // [SerializeField] private AudioSource m_WalkSource;

    private Rigidbody m_Rb;
    public AudioSource m_WallHitAudioSource;

    public void IncrementScore( int i )
    {
        m_iScore += i;
        m_ScoreText.text = "Punkty: " + m_iScore.ToString();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        m_Rb = GetComponent<Rigidbody>();
        m_WallHitAudioSource = GetComponent<AudioSource>();
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
