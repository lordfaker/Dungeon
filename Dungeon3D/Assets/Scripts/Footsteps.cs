using UnityEngine;
using System.Collections;

public class Footsteps : MonoBehaviour {

    public AudioClip audioClip;
    public float stepLength = .4F;
    public float volume = .7F;
    private CharacterController controller;
    private float delay = 0;

	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (controller.velocity.sqrMagnitude > .2F && controller.isGrounded)
        {
            if (delay >= stepLength)
            {
                AudioSource.PlayClipAtPoint(audioClip, transform.position, volume);
                delay = 0;
            }
        }
        delay += Time.deltaTime;
	}
}
