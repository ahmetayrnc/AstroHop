using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

	public static MenuManager Instance;

	void Awake()
	{
		Instance = this;
	}
	
	public void StartGame()
	{
		SceneManager.LoadScene(1);
	}
}
