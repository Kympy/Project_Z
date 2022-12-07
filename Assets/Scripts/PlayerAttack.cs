using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : Character
{
    private void Start()
    {
        arrowSpawn ??= GameObject.Find("ArrowSpawn").transform;
        arrowPrefab ??= Resources.Load<GameObject>("Arrow");
    }
    private void Update()
    {
        Attack();
    }
    private void Attack()
    {
        switch (PlayerHandler.Instance.weaponMode)
        {
            case PlayerHandler.WeaponMode.Bow:
                {
                    this.GetAnimator().SetBool("IsAim", PlayerHandler.Instance.IsAim);
                    Bow();
                    break;
                }
            default:
                {
                    break;
                }
        }
    }
    private Transform arrowSpawn = null;
    [SerializeField] private Transform stringPos = null;
    private GameObject tempArrow = null;
    private GameObject arrowPrefab = null;
    private float shootPower = 0f;
    private void Bow()
    {
        if (PlayerHandler.Instance.IsAim)
        {
            if (shootPower < 80f)
            {
                shootPower += Time.deltaTime * 30f;
            }

            stringPos.position = GetAnimator().GetBoneTransform(HumanBodyBones.RightHand).position;
            if (tempArrow == null)
            {
                tempArrow = Instantiate(arrowPrefab, arrowSpawn);
                tempArrow.transform.SetParent(arrowSpawn);
            }
        }
        else
        {
            if (tempArrow != null)
            {
                stringPos.localPosition = new Vector3(0f, -0.01f, 0f);
                tempArrow.transform.SetParent(null);
                tempArrow.GetComponent<Arrow>().FlyArrow(shootPower);
                tempArrow = null;
                shootPower = 0f;
            }
        }
    }
}
