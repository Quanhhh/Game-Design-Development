using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    //Di chuyen
    public Rigidbody2D rb; 
    public Animator anima;
    public int tocDo = 4; 
    public float lucNhay = 6; 
    private float traiPhai; 
    public bool isdaoChieu = true; 
    private bool duocPhepNhay = false; 
    public Transform _duocPhepNhay; 
    public LayerMask san; 
    private bool nhayDoi; 

    public int maxLives = 3; 
    int currentLives;
    bool invincible = false; 
    public float invincibleTime = 2.0f; 
    float invincibleCounter; 

    public int Lives { get { return currentLives; } set { currentLives = Mathf.Clamp(value, 0, maxLives); } }

    void Start()
    {
        Lives = maxLives; // Khởi tạo số mạng
        invincibleCounter = invincibleTime;
    }

    void Update()
    {
        // Kiểm tra tiếp đất
        duocPhepNhay = Physics2D.OverlapCircle(_duocPhepNhay.position, 0.2f, san);

        // Nhập hướng di chuyển
        traiPhai = Input.GetAxisRaw("Horizontal");

        // Lật hình nhân vật
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (traiPhai < 0) 
        {
            spriteRenderer.flipX = true;
            isdaoChieu = false;
        }
        else if (traiPhai > 0) 
        {
            spriteRenderer.flipX = false;
            isdaoChieu = true;
        }

        // xử lý nhảy
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            if (duocPhepNhay || !nhayDoi) 
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, lucNhay);
                if (!duocPhepNhay) nhayDoi = true; // cho phép nhảy đôi
                anima.SetBool("duocPhepNhay", true);
            }
        }

        if (duocPhepNhay) // Reset trạng thái nhảy khi tiếp đất
        {
            nhayDoi = false;
            anima.SetBool("duocPhepNhay", false);
        }

       
        anima.SetFloat("diChuyen", Mathf.Abs(traiPhai));

        // Bất tử
        if (invincible)
        {
            invincibleCounter -= Time.deltaTime; 
            if (invincibleCounter < 0) 
            {
                invincible = false; 
                invincibleCounter = invincibleTime; 
            }
        }
    }

    void FixedUpdate()
    {
        // Áp dụng vận tốc để di chuyển
        rb.linearVelocity = new Vector2(traiPhai * tocDo, rb.linearVelocity.y);
    }

    // Mất mạng
    public void TakeDamage()
    {
        if (invincible) // Nếu đang bất tử
        {
            return;
        }
        Lives--;
        LivesCounter.instance?.AdjustLivesCounter(Lives); 
        invincible = true;
        if (Lives <= 0) 
        {
            Die();
        }
    }

    public void Die()
    {
        anima.SetBool("IsDead", true);
        Destroy(gameObject, 1.0f); // Phá hủy nhân vật sau 1 giây
    }
}