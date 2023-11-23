using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadSpecificScene : MonoBehaviour
{
	public string sceneName;
	private Animator fadeSystem;

	private void Awake()
	{
		fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.CompareTag("Player"))
		{
			//Disable player movement when end level is reached
			PlayerMovement.instance.DisablePlayerInteractions();
			PlayerMovement.instance.animator.SetTrigger("Win");
			StartCoroutine(LoadNextScene());
		}
	}

	public IEnumerator LoadNextScene()
	{
		LoadAndSaveData.instance.SaveData();
		yield return new WaitForSeconds(2f);
		fadeSystem.SetTrigger("FadeIn");
		yield return new WaitForSeconds(1f);
		SceneManager.LoadScene(sceneName);
		//Enable player movement when next level is loaded
		PlayerMovement.instance.EnablePlayerInteractions();
	}
}
