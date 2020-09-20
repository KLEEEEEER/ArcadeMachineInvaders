using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class DeathEffect : MonoBehaviour
{
    ParticleSystem deathEffectParticleSystem;
    WaitForSeconds waitHalfSecond = new WaitForSeconds(0.5f);

    private void Start()
    {
        deathEffectParticleSystem = GetComponent<ParticleSystem>();
    }

    private void OnEnable()
    {
        GetComponent<ParticleSystem>().Play();
        StartCoroutine(DisableParticles());
    }

    IEnumerator DisableParticles()
    {
        yield return waitHalfSecond;
        gameObject.SetActive(false);
    }
}
