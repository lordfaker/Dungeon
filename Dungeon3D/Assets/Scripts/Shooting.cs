using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Shooting : MonoBehaviour {

    public InventoryItem projectile;
    private Inventory inventory;
    private Text messageText;
    private string info = "Zum Angreifen brauchst Du etwas zum Werfen";
    private bool messageShown = false;
    private AudioSource audioSource;
    private PlayerHealth playerHealth;


    // Use this for initialization
    void Start()
    {
        inventory = transform.parent.GetComponent<Inventory>();
        audioSource = GetComponent<AudioSource>();
        playerHealth = transform.parent.GetComponent<PlayerHealth>();
        messageText = GameObject.FindGameObjectWithTag("Message").GetComponent<Text>();
    }

    void Shoot()
    {
        Instantiate(projectile.prefab, transform.position, transform.rotation);
        audioSource.Play();
    }
	
	// Update is called once per frame
	void Update () {
	    if (playerHealth.health > 0)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                if (inventory.RemoveItem(projectile))
                    Shoot();
                else if (!messageShown)
                {
                    StartCoroutine(ShowInfoText());
                }
            }
        }
	}

    IEnumerator ShowInfoText()
    {
        messageText.text = info;
        messageShown = true;
        yield return new WaitForSeconds(2);
        messageText.text = "";
    }
}
