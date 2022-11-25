using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killable : MonoBehaviour
{
    public Collider HitCollider;
    public AudioSource KillSound;
    public ParticleSystem DeathParticles;
    public MeshRenderer KillableMesh;
    public delegate void OnKilledDelagate();

    public OnKilledDelagate OnKilled;

    private bool dying = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    public IEnumerator FinishDying()
    {
        while (KillSound.isPlaying)
        {
            yield return null;
        }
        Destroy(gameObject);
    }

    public void Die()
    {
        if (dying) { return; }
        KillableMesh.enabled = false;
        DeathParticles.Play();
        KillSound.Play();
        if (OnKilled != null)
        {
            Debug.Log(gameObject.name + " on killed invoke");
            OnKilled.Invoke();
        }
        StartCoroutine("FinishDying");
        //Destroy(gameObject);
        dying = true;

    }
}
