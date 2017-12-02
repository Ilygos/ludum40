using UnityEngine;
using UnityEngine.UI;

namespace Game {
	public class QuitButton : MonoBehaviour {

		void Start() {
			GetComponent<Button>().onClick.AddListener(OnQuit);
		}

		public void OnQuit() {
			GameManager.Instance.QuitGame();
		}

	}
}
