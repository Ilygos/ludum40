using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviourSingleton<UIManager> {

    [SerializeField]
    private Image[] lives;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		foreach (Image img in lives)
        {
            img.gameObject.SetActive(false);
        }

        for (int i = 0; i < GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().healtPoints; i++)
        {
            lives[i].gameObject.SetActive(true);
        }
	}
}
