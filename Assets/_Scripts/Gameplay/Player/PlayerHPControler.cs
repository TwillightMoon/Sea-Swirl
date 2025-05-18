using UnityEngine;

public class PlayerHPControler : MonoBehaviour
{
    [SerializeField] private int hp;
    [SerializeField] private SceneSwitcher sceneSwitcher;
    [SerializeField] private string loseSceneName = "Menu";

    public void TakeDamage(int damage)
    {
        hp -= damage;
    }

    private void Update()
    {
        if (hp <= 0f)
        {
            enabled = false;
            sceneSwitcher.ChangeScene(loseSceneName);
        }
    }
}
