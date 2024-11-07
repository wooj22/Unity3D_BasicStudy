using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    public GameObject bullet;
    public ParticleSystem cartridge;
    public Transform firePos;
    public AudioClip fireSound;

    private ParticleSystem muzzleFlash;
    private AudioSource _audio;

    private void Start()
    {
        muzzleFlash = firePos.GetComponentInChildren<ParticleSystem>();
        _audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Fire();
    }

    private void Fire()
    {
        Instantiate(bullet, firePos.position, firePos.rotation);
        cartridge.Play();
        muzzleFlash.Play();
        _audio.PlayOneShot(fireSound, 1.0f);
    }
}
