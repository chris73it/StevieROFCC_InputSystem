using UnityEngine;

public class GameManager
{
    private GameObject gameObject;

    private static GameManager m_instance;
    public static GameManager Instance
    {
        get {
            if (m_instance == null)
            {
                m_instance = new GameManager();
                m_instance.gameObject = new GameObject("_gameManager");
            }
            return m_instance;
        }
    }

    public void OnMoveInput()
    {

    }
}
