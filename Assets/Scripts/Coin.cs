using System.Collections;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private AudioSource m_AudioSource;

    private void OnTriggerEnter( Collider other )
    {
        BasePlayer pPlayer = other.GetComponent<BasePlayer>();
        if( pPlayer == null ) return;

        pPlayer.IncrementScore( 1 );

        m_AudioSource.Play();

        Destroy( this );
    }

    private void Start()
    {
        m_AudioSource = GetComponent< AudioSource >();
    }

    //private IEnumerator MoveCoinToPlayer( BasePlayer pPlayer, )

    private void FixedUpdate()
    {
        transform.eulerAngles += new Vector3( 0, 1, 0 );
    }
}
