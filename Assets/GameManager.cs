using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject leftWarpNode;
    public GameObject rightWarpNode;

    public AudioSource siren;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        siren.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
