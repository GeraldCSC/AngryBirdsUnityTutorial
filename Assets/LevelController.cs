using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelController : MonoBehaviour
{
    private static int _nextLevelIndex = 1;
    private Enemy[] _enemies;
    // Update is called once per frame
    void Update()
    {
        foreach(Enemy e in _enemies)
        {
            if (e != null)
                return;
        }
        Debug.Log("You killed all enemies");
        _nextLevelIndex++;
        string nextLevelName = "Level" + _nextLevelIndex;
        SceneManager.LoadScene(nextLevelName);
    }
    private void OnEnable()
    {
        _enemies = FindObjectsOfType<Enemy>();
    }
}
