using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyuncuHareket : MonoBehaviour
{
    Rigidbody2D body;
    Animator animator;

    Vector2 velocity;
    Vector3 defaultLocalScale;

    [SerializeField]
    float hiz = default;

    [SerializeField]
    float hizlanma = default;

    [SerializeField]
    float yavaslama = default;

    [SerializeField]
    float ziplamaGucu = default;

    [SerializeField]
    int ziplamaLimiti;

    int ziplamaSayisi;

    Joystick Joystick;

    JoystickButon joystickButon;

    bool zipliyor;

    [SerializeField]
    int suruklemeSpeed;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        defaultLocalScale = transform.localScale;
        Joystick = FindObjectOfType<Joystick>();
        joystickButon = FindObjectOfType<JoystickButon>();
    }
    private void Update()
    {


#if UNITY_ANDROID
        TouchControl();

#elif UNITY_EDITOR
        //KlavyeKontrol();
        MergeControls();

#elif UNITY_STANDALONE_WIN
        KlavyeKontrol();
#elif UNITY_WEBGL
        MergeControls();
#endif

    }
    void KlavyeKontrol()
    {
        float hareketInput = Input.GetAxisRaw("Horizontal");
        if (hareketInput > 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, hareketInput * hiz, hizlanma * Time.deltaTime);
            animator.SetBool("Walk", true);
            transform.localScale = new Vector3(defaultLocalScale.x, defaultLocalScale.y, defaultLocalScale.z);
        }
        else if (hareketInput <0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, hareketInput * hiz, hizlanma * Time.deltaTime);
            animator.SetBool("Walk", true);
            transform.localScale = new Vector3(-defaultLocalScale.x, defaultLocalScale.y, defaultLocalScale.z);
        }
        else
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, yavaslama * Time.deltaTime);
            animator.SetBool("Walk", false);
        }
        transform.Translate(velocity * Time.deltaTime);

        if (Input.GetKeyDown("space"))
        {
            ZiplamayiBaslat();
        }
        if (Input.GetKeyUp("space")) 
        {
            ZiplamayiDurdur();
        }
    }

    void JoystickKontrol()
    {
        float hareketInput = Joystick.Horizontal;
        if (hareketInput > 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, hareketInput * hiz, hizlanma * Time.deltaTime);
            animator.SetBool("Walk", true);
            transform.localScale = new Vector3(defaultLocalScale.x, defaultLocalScale.y, defaultLocalScale.z);
        }
        else if (hareketInput < 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, hareketInput * hiz, hizlanma * Time.deltaTime);
            animator.SetBool("Walk", true);
            transform.localScale = new Vector3(-defaultLocalScale.x, defaultLocalScale.y, defaultLocalScale.z);
        }
        else
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, yavaslama * Time.deltaTime);
            animator.SetBool("Walk", false);
        }
        transform.Translate(velocity * Time.deltaTime);

        if (joystickButon.tusaBasildi && !zipliyor)
        {
            zipliyor = true;
            ZiplamayiBaslat();
        }
        if (!joystickButon.tusaBasildi && zipliyor)
        {
            zipliyor = false;
            ZiplamayiDurdur();
        }
    }
    void MergeControls()
    {
        float hareketInput = Input.GetAxisRaw("Horizontal");
        float hareketInputJoystick = Joystick.Horizontal;
        if (hareketInput > 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, hareketInput * hiz, hizlanma * Time.deltaTime);
            animator.SetBool("Walk", true);
            transform.localScale = new Vector3(defaultLocalScale.x, defaultLocalScale.y, defaultLocalScale.z);
        }
        else if (hareketInput < 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, hareketInput * hiz, hizlanma * Time.deltaTime);
            animator.SetBool("Walk", true);
            transform.localScale = new Vector3(-defaultLocalScale.x, defaultLocalScale.y, defaultLocalScale.z);
        }
        else if (hareketInputJoystick > 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, hareketInputJoystick * hiz, hizlanma * Time.deltaTime);
            animator.SetBool("Walk", true);
            transform.localScale = new Vector3(defaultLocalScale.x, defaultLocalScale.y, defaultLocalScale.z);
        }
        else if (hareketInputJoystick < 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, hareketInputJoystick * hiz, hizlanma * Time.deltaTime);
            animator.SetBool("Walk", true);
            transform.localScale = new Vector3(-defaultLocalScale.x, defaultLocalScale.y, defaultLocalScale.z);
        }
        else
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, yavaslama * Time.deltaTime);
            animator.SetBool("Walk", false);
        }
        transform.Translate(velocity * Time.deltaTime);

        if (Input.GetKeyDown("space"))
        {
            ZiplamayiBaslat();
        }
        if (Input.GetKeyUp("space"))
        {
            ZiplamayiDurdur();
        }
        if (joystickButon.tusaBasildi && !zipliyor)
        {
            zipliyor = true;
            ZiplamayiBaslat();
        }
        if (!joystickButon.tusaBasildi && zipliyor)
        {
            zipliyor = false;
            ZiplamayiDurdur();
        }
    }

    void TouchControl()
    {
        Vector3 position = transform.position;
        if (Input.touchCount > 0)
        {
            // kaç parmak ile basýldýðý ve ilk parmaðýn deðeri
            Touch finger = Input.GetTouch(0);
            //Debug.Log(Camera.main.ScreenToWorldPoint( finger.deltaPosition));
            if (finger.deltaPosition.x > suruklemeSpeed)
            {
                //Debug.Log("saða gidiyor");
                velocity.x = Mathf.MoveTowards(velocity.x, 1 * hiz, hizlanma * Time.deltaTime);
                animator.SetBool("Walk", true);
                transform.localScale = new Vector3(defaultLocalScale.x, defaultLocalScale.y, defaultLocalScale.z);

            }
            if (finger.deltaPosition.x < (-1)*suruklemeSpeed )
            {
                //Debug.Log("sola gidiyor");
                velocity.x = Mathf.MoveTowards(velocity.x, (-1) * hiz, hizlanma * Time.deltaTime);
                animator.SetBool("Walk", true);
                transform.localScale = new Vector3(-defaultLocalScale.x, defaultLocalScale.y, defaultLocalScale.z);

            }

            if (finger.phase == TouchPhase.Ended)
            {
                velocity.x = Mathf.MoveTowards(velocity.x, 0, yavaslama * Time.deltaTime);
                animator.SetBool("Walk", false);
            }

            transform.Translate(velocity * Time.deltaTime);

            if (Input.touchCount > 1 )
            {

                Touch finger2 = Input.GetTouch(1);
                if (finger2.phase == TouchPhase.Began)
                {
                    ZiplamayiBaslat();
                }
                if(finger2.phase == TouchPhase.Ended)
                {
                    ZiplamayiDurdur();
                }
            }
        }
    }
    void ZiplamayiBaslat()
    {
        if (ziplamaSayisi < ziplamaLimiti)
        {
            FindObjectOfType<SesKontrol>().ZiplamaSes();
            body.AddForce(new Vector2(0, ziplamaGucu), ForceMode2D.Impulse);
            animator.SetBool("Jump", true);
            FindObjectOfType<SliderKontrol>().SliderDeger(ziplamaLimiti, ziplamaSayisi);
        }
    }
    void ZiplamayiDurdur()
    {
        animator.SetBool("Jump", false);
        ziplamaSayisi++;
        FindObjectOfType<SliderKontrol>().SliderDeger(ziplamaLimiti, ziplamaSayisi);
    }
    public void ZiplamayiSifirla()
    {
        ziplamaSayisi = 0;
        FindObjectOfType<SliderKontrol>().SliderDeger(ziplamaLimiti, ziplamaSayisi);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Olum"))
        {
            FindObjectOfType<OyunKontrol>().OyunuBitir();
        }
    }

    public void OyunBitti()
    {
        Destroy(gameObject);
    }

}
