using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private void OnTriggerEnter( Collider other )
    {
        BasePlayer player = other.GetComponent<BasePlayer>();

        player.m_WallHitAudioSource.Play();
    }
}
