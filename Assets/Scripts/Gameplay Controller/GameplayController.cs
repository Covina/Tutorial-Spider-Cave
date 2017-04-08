using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour {


	[SerializeField] private GameObject pausePanel;

	[SerializeField] private Button resumeGameButton;
	[SerializeField] private Button mainMenuButton;



	public void PauseGame() 
	{

		// pause the game
		Time.timeScale = 0f;

		// show pause panel
		pausePanel.SetActive(true);

		resumeGameButton.onClick.RemoveAllListeners();
		resumeGameButton.onClick.AddListener( () => ResumeGame() );



	}


	public void ResumeGame ()
	{

		Time.timeScale = 1f;
		pausePanel.SetActive(false);

	}

	public void RestartGame ()
	{

		Time.timeScale = 1f;
		pausePanel.SetActive(false);
		SceneManager.LoadScene("Gameplay");
	}


	public void GoToMenu ()
	{
		Time.timeScale = 1f;
		pausePanel.SetActive(false);
		SceneManager.LoadScene("MainMenu");
	}


	public void PlayerDied ()
	{
		// pause the game
		Time.timeScale = 0f;

		// show pause panel
		pausePanel.SetActive(true);

		resumeGameButton.onClick.RemoveAllListeners();
		resumeGameButton.onClick.AddListener( () => RestartGame() );


	}


}
