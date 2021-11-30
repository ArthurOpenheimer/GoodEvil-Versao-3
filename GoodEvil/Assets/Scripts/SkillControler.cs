using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillControler : MonoBehaviour
{
    public string facing;
    public Animator playerAnimator;
    public Stats stats;
    public bool Healing;
    public GameObject fireBallSmall;
    public GameObject fireBallBig;
    public Vector2 skillDirection;
    private Vector3 pos;
    public List<string> listAllies = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<Stats>();
        listAllies.Add(gameObject.tag);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) InstanciateSkill(fireBallSmall);
        if (Input.GetKeyDown(KeyCode.Mouse1)) InstanciateSkill(fireBallBig);
        if (Input.GetKeyDown(KeyCode.F)) SetBuff();
        if (Input.GetKeyDown(KeyCode.G)) playerAnimator.SetTrigger("ExitHeal"); ;
    }

    private void SetBuff()
    {
        playerAnimator.SetTrigger("Heal");
        stats.Heal(20);
    }

    void ExitAnim()
    {
        Healing = false;
    }
    void InstanciateSkill(GameObject skillPrefab)
    {
        //Pega a mana da skill
        int manaCost = skillPrefab.GetComponent<Skills>().manaCost;

        stats.ReduceMana(manaCost);        

        facing = gameObject.GetComponent<PlayerMoveController>().facing;

        //Instancia com uma posição ajustada
        pos = CreateSkillPosition();
        GameObject skills = Instantiate(skillPrefab, pos, Quaternion.identity);

        //Move a skill com a direção que o player esta olhando
        skills.GetComponent<Skills>().Init(skillDirection, listAllies);
    }

    Vector3 CreateSkillPosition()
    {
        Vector3 curPosition = transform.position;

        switch (facing)
        {
            case "up":
                skillDirection = new Vector2(0, 1);
                return curPosition + new Vector3(0, 0.9f);

            case "down":
                skillDirection = new Vector2(0, -1);
                return curPosition + new Vector3(0, -1.2f);

            case "right":
                skillDirection = new Vector2(1, 0);
                return curPosition + new Vector3(1.1f, 0);

            case "left":
                skillDirection = new Vector2(-1, 0);
                return curPosition + new Vector3(-1.05f, 0);

            default:
                skillDirection = new Vector2(0, 1);
                return curPosition + new Vector3(1, 0);
        }
    }
}
