using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : HealthController {

    public AudioClip hurtClip;
    public AudioClip deathClip;
    public Image healthGui;
    private LifePointController lpController;
    private float maxhealth;
    private Text messageText;
    private AudioSource audioSource;

    void UpdateView()
    {
        if (healthGui != null)
        {
            healthGui.fillAmount = health / maxhealth;
        }
    }

	// Use this for initialization
	void Start () {
        messageText = GameObject.FindGameObjectWithTag("Message").GetComponent<Text>();
        lpController = GameObject.FindGameObjectWithTag("GameController").GetComponent<LifePointController>();
        audioSource = GetComponent<AudioSource>();
        maxhealth = health;
        UpdateView();
	}

    public override void Damaging()
    {
        audioSource.clip = hurtClip;
        audioSource.Play();
        UpdateView();
    }

    public override void Dying()
    {
        audioSource.clip = deathClip;
        audioSource.Play();
        UpdateView();

        lpController.LifePoints -= 1;
        if (lpController.LifePoints > 0)
            Invoke("Restart", 1);
        else
            messageText.text = "Game Over";
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update () {
	
	}
}
