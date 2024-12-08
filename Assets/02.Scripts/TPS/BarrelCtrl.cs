using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelCtrl : MonoBehaviour
{
    public GameObject expEffect;
    int hitCout;
    Rigidbody rb;

    // mesh
    public Mesh[] meshes;
    MeshFilter meshFilter;

    // texture
    public Texture[] textures;
    MeshRenderer meshRender;

    // sound
    public AudioClip expSfx;
    AudioSource audioSrc;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        meshFilter = GetComponent<MeshFilter>();
        meshRender = GetComponent<MeshRenderer>();
        meshRender.material.mainTexture = textures[Random.Range(0, textures.Length)];
        audioSrc = GetComponent<AudioSource>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "BULLET")
        {
            if (++hitCout == 3)
                ExpBarrel();
        }
    }

    /// 드럼통 폭발
    void ExpBarrel()
    {
        GameObject effect = Instantiate(expEffect, transform.position, Quaternion.identity);

        Destroy(effect, 2f);

        rb.mass = 1f;
        rb.AddForce(Vector3.up * 1000f);

        // 찌그러진 메쉬
        int idx = Random.Range(0, meshes.Length);
        meshFilter.sharedMesh = meshes[idx];

        audioSrc.PlayOneShot(expSfx, 1f);
    }
}
