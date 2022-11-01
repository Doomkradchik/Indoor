using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverView : MonoBehaviour
{
    [SerializeField]
    private SimpleAITester _enemy;

    [SerializeField]
    private Camera _gameOver;

    private const float TIME = 5f;

    private void OnEnable()
    {
        _gameOver.gameObject.SetActive(false);
        _enemy.GameEnded += () => StartCoroutine(Perform());
    }

    private IEnumerator Perform()
    {
        GameManager.Pause();

        _gameOver.gameObject.SetActive(true);

        yield return new WaitForSeconds(TIME);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
