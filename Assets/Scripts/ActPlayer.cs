using UnityEngine;
using UnityEngine.SceneManagement;

public class ActPlayer : MonoBehaviour
{

    public float dashGO;
    public float dashBACK;
    public float jumpGO;
    public float jumpBACK;

    private string state;

    private int limiar;

    private bool canJump;
    private bool canDash;
    private bool canDestroyObject;

    private Rigidbody2D rb;

    private Vector3 mouse;

    public Animator animator;

    private Points point;

    public GameObject MenuScored;
    public GameObject HighScored;
    public GameObject Restart;
    public GameObject ClearHighscore;
    public GameObject MainMenu;

    void Awake()
    {
        canJump = true;
        canDash = true;
    }

    void Start()
    {
        limiar = Screen.width / 15;

        rb = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();

        point = GameObject.FindGameObjectWithTag("Points").GetComponent<Points>();
    }

    void Update()
    {
        BasicFunction();
        Swipe();

        RealJumpPC();
        SwipeComputer();    

        switch (state)
        {
            case "up":
                if (transform.position.y < 0.5f)
                {
                    transform.position = new Vector2(transform.position.x, transform.position.y + jumpGO);
                }
                else
                {
                    state = "down";
                }
                break;

            case "down":
                if (transform.position.y >= -3.7f)
                {
                    transform.position = new Vector2(transform.position.x, transform.position.y - jumpBACK);
                }
                else
                {
                    if (transform.position.x > -7f)
                    {
                        state = "dashBack";
                    }
                    else
                    {
                        state = "stopped";
                    }

                }
                break;


            case "dashGo":
                if (transform.position.x <= 2f)
                {
                    transform.position = new Vector2(transform.position.x + dashGO, transform.position.y);
                    canDestroyObject = true;
                    animator.SetBool("jumpDash", true);
                }
                else
                {
                    state = "dashBack";
                    animator.SetBool("isDashing", false);
                }
                break;
            case "dashBack":
                if (transform.position.x >= -7f)
                {
                    transform.position = new Vector2(transform.position.x - dashBACK, transform.position.y);
                }
                else
                {
                    if (transform.position.y > -3.7)
                    {
                        state = "down";
                    }
                    else
                    {
                        state = "stopped";
                    }
                    canDestroyObject = false;

                    canDash = true;
                }
                break;
        }

        if (canJump == true)
        {
            EndAnimationJump();
        }
    }

    void BasicFunction()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouse = Input.mousePosition;

            Invoke("RealJump", 0.05f);
        }
    }

    #region fuctionsBases
   void RealJump()
    {
        if (canJump)
        {
            if (Input.GetMouseButton(0))
            {
                if (Input.mousePosition.x - mouse.x < limiar)
                {
                    animator.SetBool("isJumping", true);
                    canJump = false;
                    state = "up";

                }
            }
        }
    }


    void Swipe()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 touchDelta = Input.GetTouch(0).deltaPosition;

            if (touchDelta.x >= limiar && canDash)// Boni se isso não funcionar na Build tira esse "&& candash"
            {
                animator.SetBool("isDashing", true);
                state = "dashGo";
                canDash = false;
            }
        }
    }
    #endregion

    #region FuctinBasePC
    void RealJumpPC()
    {
        if (Input.GetKeyDown(KeyCode.W) && canJump|| Input.GetKeyDown(KeyCode.UpArrow ) && canJump)
        {
            animator.SetBool("isJumping", true);
            canJump = false;
            state = "up";
        }
    }

    void SwipeComputer()
    {
        if (Input.GetKeyDown(KeyCode.D) && canDash || Input.GetKeyDown(KeyCode.RightArrow) && canDash)
        {
            animator.SetBool("isDashing", true);
            state = "dashGo";
            canDash = false;
        }
    }
    #endregion

    #region EndAnims

    void EndAnimationDash()
    {
        animator.SetBool("isDashing", false);
    }

    void EndAnimationJump()
    {
        animator.SetBool("isJumping", false);
    }
    #endregion

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag.Equals("Ground"))
        {
            canJump = true;
        }

        if (coll.gameObject.tag.Equals("Barrel"))
        {
            if (coll.transform.gameObject.GetComponent<DestroyPettern>().GetCanDestroy() && canDestroyObject == true)
            {
                point.num += 100;
                Destroy(coll.gameObject);
            }
            else
            {
                GameObject.FindGameObjectWithTag("Points").GetComponent<Points>().SavePoints();
                Destroy(this.gameObject);
                MenuScored.SetActive(true);
                HighScored.SetActive(true);
                Restart.SetActive(true);
                ClearHighscore.SetActive(true);
                MainMenu.SetActive(true);
            }

        }
        if (coll.gameObject.tag.Equals("Coin"))
        {
            point.num += 500;
            Destroy(coll.gameObject);
        }
    }
}