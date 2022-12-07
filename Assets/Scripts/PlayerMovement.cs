using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : Character
{
    private void Start()
    {
        if(desiredForward == null)
            desiredForward = GameObject.Find("Forward").transform;
        //upper = GetAnimator().GetBoneTransform(HumanBodyBones.Spine);
    }
    private void FixedUpdate()
    {
        Movement();
        Jump();
        //rotateAngle += Input.GetAxis("Mouse Y");
        if (PlayerHandler.Instance.HP < 0)
        {
            Destroy(this.gameObject);
            Invoke(nameof(Reload), 3f);
        }
    }
    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    protected float horizontal = 0f;
    protected float vertical = 0f;
    protected bool isMove = false;
    protected Vector3 moveDir;
    protected Transform desiredForward;
    protected float playerSpeed;
    protected float rotateSpeed;
    public virtual void Movement()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        isMove = !Mathf.Approximately(horizontal, 0f) || !Mathf.Approximately(vertical, 0f);

        moveDir = horizontal * desiredForward.right + vertical * desiredForward.forward;
        moveDir.Normalize();

        if (isMove)
        {
            playerSpeed = PlayerHandler.Instance.playerSpeed;
            rotateSpeed = PlayerHandler.Instance.rotateSpeed;
            switch (PlayerHandler.Instance.weaponMode)
            {
                case PlayerHandler.WeaponMode.Normal:
                    {
                        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDir), Time.deltaTime * rotateSpeed);
                        break;
                    }
                case PlayerHandler.WeaponMode.Bow:
                    {
                        if (PlayerHandler.Instance.IsAim)
                        {
                            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredForward.forward), Time.deltaTime * rotateSpeed * 2f);
                            playerSpeed = playerSpeed * 0.5f;
                        }
                        else
                        {
                            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDir), Time.deltaTime * rotateSpeed);
                        }
                        this.GetAnimator().SetFloat("Horizontal", horizontal);
                        this.GetAnimator().SetFloat("Vertical", vertical);
                        break;
                    }
            }
            this.GetRigidbody().MovePosition(this.GetRigidbody().position + Time.deltaTime * playerSpeed * moveDir);
        }
        else
        {
            if (PlayerHandler.Instance.IsAim)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredForward.forward), Time.deltaTime * rotateSpeed * 2f);
            }
        }
        this.GetAnimator().SetBool("IsMove", isMove);
    }
    public void Jump()
    {
        if (IsGround() && Input.GetKeyDown(KeyCode.Space))
        {
            GetRigidbody().AddForce(Vector3.up * 500f, ForceMode.Impulse);
        }
    }
    public bool IsGround()
    {
        return Physics.CheckSphere(transform.position - new Vector3(0f, 0.2f, 0f), 0.3f , 1 << LayerMask.NameToLayer("Terrain"));
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position - new Vector3(0f, 0.2f, 0f), 0.3f);
    }
    [SerializeField] private Transform upper = null;
    private float rotateAngle = 0f;
    [SerializeField] private Vector3 rot;
    public void UpperRotation()
    {
        upper.rotation *= Quaternion.Euler(rot);
        upper.rotation *= Quaternion.Euler(0f, 0f, rotateAngle);
    }
}
