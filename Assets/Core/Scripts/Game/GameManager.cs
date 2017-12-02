using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Game {
	public class GameManager : MonoBehaviourSingletonPersistent<GameManager> {

		public string titleScene;
		public string gameScene;

		bool gameLoading;

		// MyManager myManager;

		//----------------------------------------------------------------------------
		// Lifecycle
		//----------------------------------------------------------------------------

		void Start() {
			if (SceneManager.GetActiveScene().name == "Scene-01") {
				// NewGame();
				InitGame();
			}
		}

		//----------------------------------------------------------------------------
		// New Game
		//----------------------------------------------------------------------------

		// Method called when the "New Game" button is clicked on the title screen ("Start" scene).
		public void NewGame() {
			Debug.Log("[GameManager] NewGame");

			if (!gameLoading) {
				gameLoading = true;

				SceneManager.sceneLoaded -= OnGameSceneLoaded;
				SceneManager.sceneLoaded += OnGameSceneLoaded;
				SceneManager.LoadSceneAsync(gameScene);
			}
		}

		public void QuitGame() {
			// In most cases termination of application under iOS should be left at the user discretion.
			// https://developer.apple.com/library/content/qa/qa1561/_index.html
			#if !UNITY_IPHONE
				Application.Quit(); // Do not work in editor mode.
			#endif
		}

		//----------------------------------------------------------------------------
		// Game States
		//----------------------------------------------------------------------------

		// Called by SceneManager.LoadSceneAsync when the scene is loaded (but not active yet).
		void OnGameSceneLoaded(Scene scene, LoadSceneMode mode) {
			SceneManager.sceneLoaded -= OnGameSceneLoaded;
			StartCoroutine(OnGameSceneActive());
		}

		// Called when the scene is loaded and active.
		IEnumerator OnGameSceneActive() {
			yield return null; // Wait one frame

			gameLoading = false;

			Debug.Log("[GameManager] Scene Loaded");

			InitGame();
		}

		// Doing the initialization of the managers here can solve some problems of precedence.
		// It can also be done in 'Edit/Project Settings/Script Execution Order'
		void InitGame() {
			// myManager = GameObject.Find("/Managers/myManager").GetComponent<MyManager>();
			// myManager.Init();
		}

		//----------------------------------------------------------------------------
		// Methods
		//----------------------------------------------------------------------------

		public void Clean() {

		}
			
		//----------------------------------------------------------------------------
		// Accessors
		//----------------------------------------------------------------------------

		// The managers can be get in the code using:
		//   GameManager.Instance.GetMyManager();
		//
		// public MyManager GetMyManager() {
		//   return myManager;
		//}

	}
}
