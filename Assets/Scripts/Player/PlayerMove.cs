using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PlayerState
{
    walk,
    attack,
    interact,
    stagger,
    idle,
    ability
}


public class PlayerMove : MonoBehaviour
{
    public PlayerState currentState;
    public float speed;
    private Rigidbody2D playerRb;
    private Vector3 change;
    private Animator animator;


    public VectorValue startingPosition;

    //TODO INVENTORY break of inventory into own component
    public Inventory playerInventory;
    public SpriteRenderer receivedItemSprite;

    //TODO HEALTH player hit should be health system?
    public Signals playerHit;

    //TODO IFRAME break in own iframe script
    [Header("IFrames")]
    public Color flashColor;
    public Color regularColor;
    public float flashDuration;
    public int numberOfFlashes;
    public Collider2D triggerCollider;
    public SpriteRenderer playerSprite;

    private bool attacking;
    private bool secondary;


    [SerializeField] private GenericAbility currentAbility;
    [SerializeField] private Vector2 facingDirection = Vector2.down;

    void Start()
    {
        currentState = PlayerState.walk;
        playerRb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1);
        transform.position = startingPosition.initialValue;
    }

    private void Update()
    {
        if (currentState==PlayerState.interact)
        {
            return;
        }
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("Weapon"))
        {
            StartCoroutine(AttackBoolHelper());
        }
        //TODO ABILITY
        if (Input.GetButtonDown("Ability"))
        {
            StartCoroutine(SecondaryBoolHelper());
        }
        
    }

    void FixedUpdate()
    {
        if (currentState != PlayerState.interact)
        {
            if (attacking
        && !IsRestrictedState(currentState))
            {
                StartCoroutine(AttackCo());
            }
            //TODO ABILITY
            else if (secondary
                    && !IsRestrictedState(currentState))
            {
                StartCoroutine(AbilityCo(currentAbility.duration));
            }
            else if (currentState == PlayerState.walk
                || currentState == PlayerState.idle)
            {
                UpdateAnimationAndMove();
            }
        }
    }

    private bool IsRestrictedState(PlayerState currentState)
    {
        if (currentState==PlayerState.attack 
            || currentState==PlayerState.ability
            || currentState==PlayerState.stagger)
        {
            return true;
        }
        return false;
    }

    private IEnumerator AttackBoolHelper()
    {
        attacking = true;
        yield return new WaitForSeconds(0.1f);
        attacking = false;
    }

    //TODO ABILITY
    private IEnumerator SecondaryBoolHelper()
    {
        secondary = true;
        yield return new WaitForSeconds(0.1f);
        secondary = false;
    }


    public void RaiseItem()
    {
        if (playerInventory.currentItem!=null)
        {
            if (currentState!=PlayerState.interact)
            {
            animator.SetBool("receiveItem",true);
            currentState = PlayerState.interact;
            receivedItemSprite.sprite = playerInventory.currentItem.itemSprite;
            }
            else
            {
                animator.SetBool("receiveItem", false);
                currentState = PlayerState.idle;
                receivedItemSprite.sprite = null;
                playerInventory.currentItem = null;
            }

        }
    }



    private IEnumerator AttackCo()
    {
        animator.SetBool("attacking",true);
        currentState = PlayerState.attack;
        yield return null;
        animator.SetBool("attacking", false);
        yield return new WaitForSeconds(.3f);
        if (currentState!=PlayerState.interact)
        {
        currentState = PlayerState.walk;
        }
    }


    public IEnumerator AbilityCo(float duration)
    {
        currentState = PlayerState.ability;
        currentAbility.Ability(transform.position, facingDirection, animator, playerRb);
        yield return new WaitForSeconds(duration);
        currentState = PlayerState.idle;
    }


    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            MovePlayer();
            change.x = Mathf.Round(change.x);
            change.y = Mathf.Round(change.y);
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
            facingDirection = change;
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }

    void MovePlayer()
    {
        change.Normalize();
        playerRb.MovePosition(transform.position + change * speed * Time.deltaTime);
    }


    //TODO KOCKBACK move knockback to own script
    public void Knockback(float knockbackTime)
    {
        StartCoroutine(KnockCo(knockbackTime));

    }

    //TODO IFRAME to own script
    private IEnumerator FlashCo()
    {
        triggerCollider.enabled = false;
        for (int i = 0; i <= numberOfFlashes; i++)
        {
            playerSprite.color = flashColor;
            yield return new WaitForSeconds(flashDuration);
            playerSprite.color = regularColor;
            yield return new WaitForSeconds(flashDuration);
        }
        triggerCollider.enabled = true;

    }

    //TODO KNOCKBACK move to knockbackscript
    private IEnumerator KnockCo(float knockbackTime)
    {
        //TODO HEALTH
        playerHit.Raise();
        if (playerRb != null )
        {
            StartCoroutine(FlashCo());
            yield return new WaitForSeconds(knockbackTime);
            playerRb.velocity = Vector2.zero;
            currentState = PlayerState.idle;
            playerRb.velocity = Vector2.zero;

        }
    }



}
