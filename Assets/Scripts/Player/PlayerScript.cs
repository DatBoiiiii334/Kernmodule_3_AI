using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : PlayerMovement, Idamagable, IRageble
{
    private float OldRageTime;
    private bool IsInRage;

    public Material myShader;
    public Text ScoreText;
    public Text LivesText;

    public int HP;
    public int score;
    public float RageTime;

    private void Start()
    {
        PlayerMovement_Check();
        OldRageTime = RageTime;
        myShader.SetColor("_Color", Color.cyan);
    }

    void Update()
    {
        ScoreText.text = "Score: " + score.ToString();
        LivesText.text = "Lives: " + HP.ToString();

        if (IsInRage == true) {
            RageTime -= Time.deltaTime;
            myShader.SetColor("_Color", Color.red);
        }
        else {
            myShader.SetColor("_Color", Color.yellow);
        }

        if (RageTime <= 0) {
            IsInRage = false;
            RageTime = OldRageTime;
        }

        if (HP <= 0) {
            SceneManager.LoadScene("LoseScreen");
        }
        else if (score >= 10) {
            SceneManager.LoadScene("WinScreen");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (IsInRage == true) {
        //if (collision.collider.tag == "Ghost") {
        //    //Debug.Log(collision.collider.name);
        //    collision.collider.GetComponent<Idamagable>().GiveDamage(10);
        //}
        //}
    }

    void Idamagable.GiveDamage(int damage)
    {
        if (IsInRage == false) {
            HP -= damage;
        }
    }

    public void Rage(bool startRaging)
    {
        IsInRage = startRaging;
        score = score + 1;
    }
}
